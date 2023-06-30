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
        private static ManualResetEvent handle = new ManualResetEvent(true);
        private static string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
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
                string script = File.ReadAllText(@"C:\Users\SHANY\Documents\SS12_Script.sql");
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

        public void DownloadSQL()
        {
            string output = string.Empty;
            pathUser = pathUser.Replace("\\", "/");
            //string filePath = "http://www.almsysinc.com/soft/files/microsoft/SQLEXPR_x86_ENU_2012.exe";
            string filePath = "http://127.0.0.1:8080/SQLEXPR_x86_ENU_2012.exe";
            var files = filePath.Split('/');
            pathUser = pathUser + @"/" + files[files.Count() - 1];
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(Client_DownloadFileCompleted);
            Console.WriteLine("Downloading SQL server file....");
            wc.DownloadFileAsync(new Uri(filePath), pathUser);
            handle.WaitOne(); // wait for the async event to complete
            //thread = new Thread(() =>
            //{
                
            //});
            //thread.Start();
        }

        public void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            box_1.Checked = true;
            string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Console.WriteLine("Installing SQL server file....");
            string new_path = pathUser + @"\SQLEXPR_x86_ENU_2012.exe";
            Process processobj = Process.Start(new_path, @"/q /Action=Install /IACCEPTSQLSERVERLICENSETERMS /Hideconsole /Features=SQLEngine /InstanceName=SQLSERVER2012   /UPDATEENABLED=false /SQLSYSADMINACCOUNTS=""NT AUTHORITY\SYSTEM"" /SQLSVCACCOUNT=""NT AUTHORITY\SYSTEM"" /BROWSERSVCSTARTUPTYPE=""Automatic""");
            processobj.WaitForExit();
            box_2.Checked = true;
            Console.WriteLine("Done installing SQL server file....");
            bool database_created = Create_database();
            if (database_created)
            {
                box_3.Checked = true;
                DAL.Users user = new DAL.Users();
                user.user = "User";
                user.password = "0000";
                user.gender = "Male";
                user.added_by = "admin";
                user.type = "admin";
                bool user_created = user.insert_2();
                if (user_created)
                {
                    box_4.Checked = true;
                    this.Hide();
                    Login_form Lform = new Login_form();
                    Lform.Show();
                }

            }
            else
            {

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
