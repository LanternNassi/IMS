using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Abbey_Trading_Store.UI;
using Abbey_Trading_Store.Configurations;
using System.Data.SqlClient;
using System.ServiceProcess;
using Abbey_Trading_Store.DAL.DAL_Properties;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    public partial class frmSetup : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
       (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse

        );

        private static WebClient wc = new WebClient();
        private static WebClient wc_2 = new WebClient();
        private static ManualResetEvent handle = new ManualResetEvent(true);
        private static string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static string pathUser_2 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static Thread thread;
        private BackgroundWorker worker = null;
        public string derived_conn_str = null;
        public frmSetup()
        {

            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        }

        private void Username_Click(object sender, EventArgs e)
        {

        }
        private void navigate()
        {
            this.Hide();
            Login_form form = new Login_form();
            form.Show();
        }

        public bool Create_database()
        {
            bool isSuccess = false;
            try
            {
                //SqlConnection conn = new SqlConnection(derived_conn_str);
                //conn.Open();
                string location = @"C:\Users\" + Environment.UserName + @"\Documents\SS12_Script.sql";
                string script = File.ReadAllText(location);
                //SqlCommand cmd = new SqlCommand(script, conn);
                //cmd.ExecuteNonQuery();


                //using (SqlConnection conn = new SqlConnection(derived_conn_str))
                //{
                //    Server db = new Server(new ServerConnection(conn));
                //    string script_txt = File.ReadAllText(script);
                //    db.ConnectionContext.ExecuteNonQuery(script_txt);
                //}

                string strComputerName = Environment.MachineName.ToString();
                string computed_server_name = strComputerName + @"\SQLSERVER2012";
                SqlConnection conn = new SqlConnection(derived_conn_str);
                Server db = new Server(new ServerConnection(computed_server_name));
                //Server db = new Server(computed_server_name);
                db.ConnectionContext.ExecuteNonQuery(script);

                //server.ConnectionContext.ExecuteNonQuery(script);



                isSuccess = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " From Create database");
            }
            finally
            {

            }
            return isSuccess;
        }

        void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                
                decimal total_mbs = UnitsNet.Information.FromBytes(e.TotalBytesToReceive).Megabytes;
                decimal current_mbs = UnitsNet.Information.FromBytes(e.BytesReceived).Megabytes;

                double percentage = bytesIn / totalBytes * 100;
                label_1.Text = decimal.Round(current_mbs,2) + " MB / " + decimal.Round(total_mbs,2) + " MB";
                P_b_1.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }

        public void DownloadSQL()
        {
            string output = string.Empty;
            pathUser = pathUser.Replace("\\", "/");
            string filePath = "https://www.almsysinc.com/soft/files/microsoft/SQLEXPR_x86_ENU_2012.exe";
            //string filePath = "http://192.168.43.90:8080/SQLEXPR_x86_ENU_2012.exe";
            var files = filePath.Split('/');
            pathUser = pathUser + @"/" + files[files.Count() - 1];
            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadSS12);
            Console.WriteLine("Downloading SQL server file....");
            wc.DownloadFileAsync(new Uri(filePath), pathUser);
            handle.WaitOne();
           
        }

        //object sender, AsyncCompletedEventArgs e

        public void DownloadSS12(object sender, AsyncCompletedEventArgs e)
        {
            string output = string.Empty;
            pathUser_2 = pathUser_2.Replace("\\", "/");
            string filePath = "https://mulapp.s3.eu-west-2.amazonaws.com/IMS/SS12_Script.sql";
            var files = filePath.Split('/');
            pathUser_2 = pathUser_2 + @"/" + files[files.Count() - 1];
            wc_2.DownloadFileCompleted += new AsyncCompletedEventHandler(Client_DownloadFileCompleted);
            Console.WriteLine("Downloading SQ server file structure....");
            wc_2.DownloadFileAsync(new Uri(filePath), pathUser_2);
            handle.WaitOne(); 
            // wait for the async event to complete
                              //thread = new Thread(() =>
                              //{

            //});
            //thread.Start();
        }

        public void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.box_1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Dat_action.Visible = true;
            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Console.WriteLine("Installing SQL server file....");
            string new_path = pathUser + @"\SQLEXPR_x86_ENU_2012.exe";
            P_b_2.Value = 10;
            Process processobj = Process.Start(new_path, @"/q /Action=Install /IACCEPTSQLSERVERLICENSETERMS /Hideconsole /Features=SQLEngine /InstanceName=SQLSERVER2012 /UPDATEENABLED=false /SQLSYSADMINACCOUNTS=""NT AUTHORITY\SYSTEM"" /SQLSVCACCOUNT=""NT AUTHORITY\SYSTEM"" /BROWSERSVCSTARTUPTYPE=""Automatic""");
            processobj.WaitForExit();
            //Adding animations
            this.Dat_action.Visible = false;
            P_b_2.Value = 20;
            System.Threading.Thread.Sleep(800);
            P_b_2.Value = 40;
            System.Threading.Thread.Sleep(1000);
            P_b_2.Value = 80;
            System.Threading.Thread.Sleep(1800);
            P_b_2.Value = 100;
            System.Threading.Thread.Sleep(2000);
            this.box_2.CheckState = System.Windows.Forms.CheckState.Checked;

            Console.WriteLine("Done installing SQL server file....");
            //bool database_created = Create_database();

            // Create a database with the respective schema
            DatabaseUpdater db_updater = new DatabaseUpdater();
            db_updater.UpdateOrCreateDatabase();

            //Adding animations
            P_b_3.Value = 20;
            System.Threading.Thread.Sleep(800);
            P_b_3.Value = 40;
            System.Threading.Thread.Sleep(1000);
            P_b_3.Value = 80;
            System.Threading.Thread.Sleep(3000);
            P_b_3.Value = 100;
            System.Threading.Thread.Sleep(1500);
            this.box_3.CheckState = System.Windows.Forms.CheckState.Checked;


            DAL.Users user = new DAL.Users();
            user.user = "User";
            user.password = "0000";
            user.gender = "Male";
            user.added_by = "admin";
            user.type = "admin";
            bool user_created = user.insert_2();
            if (user_created)
            {
                //Adding animations
                P_b_4.Value = 20;
                System.Threading.Thread.Sleep(800);
                P_b_4.Value = 40;
                System.Threading.Thread.Sleep(800);
                P_b_4.Value = 80;
                System.Threading.Thread.Sleep(1000);
                P_b_4.Value = 100;
                System.Threading.Thread.Sleep(500);
                this.box_4.CheckState = System.Windows.Forms.CheckState.Checked;


                this.Hide();
                Login_form Lform = new Login_form();
                Lform.Show();
            }

        }

        private void frmSetup_Load(object sender, EventArgs e)
        {

            

        }

        private void frmSetup_Shown(object sender, EventArgs e)
        {
            

        }

        private void frmSetup_Activated(object sender, EventArgs e)
        {
            
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            if (this.start_btn.Text == "Start Setup")
            {
                start_btn.Text = "Cancel Setup";
                DownloadSQL();
            }
            else
            {
                this.Close();
            }
        }
    }
}
