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
using System.Collections;
using System.Configuration.Install;
using System.Net.Sockets;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using System.Net.NetworkInformation;
using System.Net.Http;
//using Microsoft.Office.Interop.Excel;
//using Microsoft.Office.Interop.Excel;

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
        public static string IPAddress = "";
        private object lockObject = new object(); // Used for synchronization
        private static string selected_server_ip = "";
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


        public void create_firewall_entry_port()
        {
            int portNumber = 9000;
            string protocol = "TCP";
            // Run the netsh command to add a firewall rule allowing remote connections
            string command = $"netsh advfirewall firewall add rule name=\"Allow Port {portNumber}\" dir=in action=allow protocol={protocol} localport={portNumber}";

            // Start a new process to run the netsh command
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe")
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process process = new Process { StartInfo = processStartInfo };
            process.Start();

            // Execute the netsh command
            process.StandardInput.WriteLine(command);
            process.StandardInput.WriteLine("exit");
            process.WaitForExit();
        }


        public string GetNetworkIPAddress()
        {
            try
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("8.8.8.8", 65530);  // Google's public DNS server
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    return endPoint?.Address.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting local IP address: {ex.Message}");
                return null;
            }
        }

        public async Task<DataTable> GetNetworkConnectedMachinesAsync()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("IP Address");
            dt.Columns.Add("IMS Installation");
            dt.Columns.Add("Type of installation");
            dt.Columns.Add("Connection String");

            // local function to ping the machines 
            bool PingHost(string ipAddress)
            {
                try
                {
                    using (Ping ping = new Ping())
                    {
                        PingReply reply = ping.Send(ipAddress, 1000); // 1500 milliseconds (1.5 second) timeout
                        return (reply != null && reply.Status == IPStatus.Success);
                    }
                }
                catch (PingException)
                {
                    return false;
                }
            }

            async Task<string> CHECK_IMS(string serverUrl)
            {
                string cont = "";
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        // Send a GET request to the server
                        HttpResponseMessage response = await client.GetAsync(serverUrl);

                        // Check if the request was successful (status code in the 200 range)
                        if (response.IsSuccessStatusCode)
                        {
                            // Read the response content as a string
                            string responseContent = await response.Content.ReadAsStringAsync();
                            return responseContent;
                            
                        }
                        else
                        {
                            Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                return cont;
            }

            string base_ip_address = "";
            int lastDotIndex = GetNetworkIPAddress().LastIndexOf('.');
            Console.WriteLine(GetNetworkIPAddress());
            if (lastDotIndex != -1)
            {
                // Trim off the characters after the last "."
                string trimmedIpAddress = GetNetworkIPAddress().Substring(0, lastDotIndex+1);
                base_ip_address = trimmedIpAddress;
            }
            else
            {
                Console.WriteLine("Invalid IP Address format");
            }
            Console.WriteLine(base_ip_address);


            async void get_machines(int first_ip , int last_ip)
            {
                // Carrying out a search on the network for any maichines
                for (int i = first_ip; i <= last_ip; i++)
                {
                    string ipAddress = base_ip_address + i.ToString();
                    if (PingHost(ipAddress))
                    {
                        //Checking whether there is any IMS installation

                        string response = await CHECK_IMS("http://" + ipAddress + ":9000");
                        if (response == "Server State")
                        {
                            lock (lockObject)
                            {
                                dt.Rows.Add(i, ipAddress, "Installed", "Server");

                            }

                        }
                        else if (response == "Client State")
                        {
                            lock (lockObject)
                            {
                                dt.Rows.Add(i, ipAddress, "Installed", "Client");
                            }
                        }
                        else
                        {
                            lock (lockObject)
                            {
                                dt.Rows.Add(i, ipAddress, "Not Installed", "N/A");
                            }
                        }

                        // Invoke the UI thread to update the DataGridView
                        Invoke(new System.Action(() =>
                        {
                            Machines.DataSource = null; // Clear previous data
                            Machines.DataSource = dt; // Update with new data
                        }));


                    }
                }

            }
            //get_machines(50, 150);
            Thread third_thread = new Thread(async () => get_machines(1, 62));
            Thread fourth_thread = new Thread(async () => get_machines(63, 125));

            System.Threading.Thread first_thread = new System.Threading.Thread(async () => get_machines(126, 187));
            Thread second_thread = new Thread(async () => get_machines(188, 254));

            first_thread.Start();
            second_thread.Start();
            third_thread.Start();
            fourth_thread.Start();


            first_thread.Join();
            second_thread.Join();
            third_thread.Join();
            fourth_thread.Join();



            return dt;
        }

        public void DownloadService( string service_type)
        {
            string output = string.Empty;
            pathUser = pathUser.Replace("\\", "/");
            string filePath = "";
            if (service_type == "Server")
            {
                filePath = "";
            }
            else
            {
                filePath = "";
            }
            //string filePath = "http://192.168.43.90:8080/SQLEXPR_x86_ENU_2012.exe";
            var files = filePath.Split('/');
            pathUser = pathUser + @"/" + files[files.Count() - 1];
            //wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(Install_service);
            Console.WriteLine("Downloading Windows server....");
            wc.DownloadFileAsync(new Uri(filePath), pathUser);
            handle.WaitOne();

        }

        public async void Create_conn_env_variable(string ip_address)
        {
            async Task<string> GET_Conn_string(string serverUrl)
            {
                string cont = "";
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        // Send a GET request to the server
                        HttpResponseMessage response = await client.GetAsync(serverUrl);

                        // Check if the request was successful (status code in the 200 range)
                        if (response.IsSuccessStatusCode)
                        {
                            // Read the response content as a string
                            string responseContent = await response.Content.ReadAsStringAsync();
                            return responseContent;

                        }
                        else
                        {
                            Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                }
                return cont;
            }
            string variableName = "IMS_conn_string";
            string variableValue = await GET_Conn_string("http://" + ip_address + ":9000/Connection/");

            // Set the environment variable
            Environment.SetEnvironmentVariable(variableName, variableValue, EnvironmentVariableTarget.Machine);

        }


        // Install the microservice
        public void Install_service(object sender, AsyncCompletedEventArgs e)
        {
            string service_path = "";
            try
            {
                // Create a TransactedInstaller and set its properties
                using (TransactedInstaller transactedInstaller = new TransactedInstaller())
                {
                    // Create instances of the installer classes
                    ServiceInstaller serviceInstaller = new ServiceInstaller();
                    ServiceProcessInstaller processInstaller = new ServiceProcessInstaller();

                    // Set the properties of the service installer
                    serviceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
                    serviceInstaller.ServiceName = "WindowsService1"; // Change this to your service name
                    serviceInstaller.Description = "This windows service is mant to facilitate all IMS related connections"; // Change this to your service description
                    serviceInstaller.DisplayName = "WindowsService1"; // Change this to your service display name
                    //serviceInstaller.DelayedAutoStart = true;

                    // Set the properties of the process installer
                    processInstaller.Account = ServiceAccount.LocalSystem;

                    // Set the installers for the transacted installer
                    transactedInstaller.Installers.Add(serviceInstaller);
                    transactedInstaller.Installers.Add(processInstaller);

                    // Set the path to your service executable
                    IDictionary savedState = new Hashtable();
                    AssemblyInstaller assemblyInstaller = new AssemblyInstaller(service_path, null);
                    assemblyInstaller.UseNewContext = true;

                    // Install the service
                    transactedInstaller.Context = new InstallContext("Install.log", null);
                    transactedInstaller.Install(savedState);

                    Console.WriteLine("Service installed successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error installing service: {ex.Message}");
            }
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
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(Client_DownloadFileCompleted);
            Console.WriteLine("Downloading SQL server file....");
            wc.DownloadFileAsync(new Uri(filePath), pathUser);
            handle.WaitOne();
           
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

            


            DAL.Users user = new DAL.Users();
            user.user = "User";
            user.password = "0000";
            user.gender = "Male";
            user.added_by = "admin";
            user.type = "admin";
            bool user_created = user.insert_2();
            if (user_created)
            {
                
                

                
                //Creating the firewall rule to allow connections through port 9000
                create_firewall_entry_port();

                //Starting the service installation
                DownloadService("Server");


                this.Hide();
                Login_form Lform = new Login_form();
                Lform.Show();
            }

        }

        private async void frmSetup_Load(object sender, EventArgs e)
        {
            //Loading all machines on the network

            DataTable dt = await GetNetworkConnectedMachinesAsync();
            //Machines.DataSource = dt;

            //System.Threading.Timer timer = new System.Threading.Timer((object state) => { Machines.DataSource = dt; }, null, 0, 2000);
            
            //timer.Dispose();
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

                //Check if the computer is connected to the network and any type of installations that exist
                if (client.CheckState.ToString() == "Checked" && (selected_server_ip != ""))
                {
                    //Creating the firewall rule to allow connections through port 9000
                    create_firewall_entry_port();

                    //Starting the service installation
                    DownloadService("Client");

                    Create_conn_env_variable(selected_server_ip);

                    this.Hide();
                    Login_form Lform = new Login_form();
                    Lform.Show();


                }
                else
                {
                    DownloadSQL();

                }
            }
            else
            {
                this.Close();
            }
        }

        private void server_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void Machines_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            string type = Machines.Rows[row].Cells[3].Value.ToString();
            if (client.CheckState.ToString() == "Checked" && type == "Server")
            {
                selected_server_ip = Machines.Rows[row].Cells[1].Value.ToString();
                selected_server.Text = "Connect to " + Machines.Rows[row].Cells[1].Value.ToString();
            }
            else
            {
                MessageBox.Show("A client option and server machine should be selected.");
            }
        }
    }
}
