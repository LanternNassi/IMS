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
using Newtonsoft.Json;
using System.Reflection;
using MaterialSkin.Controls;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using Abbey_Trading_Store.DAL;
using System.Data.SqlTypes;
//using Microsoft.Office.Interop.Excel;
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
        private static WebClient service_wc = new WebClient();


        private static ManualResetEvent handle = new ManualResetEvent(true);
        private static string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static string pathUser_2 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static string service_pathUser = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private static WebClient updator_wc = new WebClient();
        private static string updator_pathUser = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    

        private static Thread thread;
        private BackgroundWorker worker = null;
        public string derived_conn_str = null;
        public static string IPAddress = "";
        private object lockObject = new object(); // Used for synchronization
        private static string selected_server_ip = "";

       

        private static string selected_machine_conn_string = "";
        private static string selected_installation = "";

        private static string service_downloaded_path = "";


        private static Abbey_Trading_Store.Settings settings;


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


        public static HttpClient http_client = new HttpClient();

        

        public static async Task<dynamic> FetchData(string url , bool show_error=true)
        {
            try
            {

                string requestBody = "{\"key\": \"value\"}";
                HttpContent content = new StringContent(requestBody, Encoding.UTF8, "application/json");


                // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
                http_client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                http_client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");//Set the User Agent to "request"
                HttpResponseMessage response = await http_client.GetAsync(url);

                response.EnsureSuccessStatusCode();
                
                if (response.IsSuccessStatusCode)
                {
                    dynamic response_content = await response.Content.ReadAsStringAsync();
                    dynamic deserialized = JsonConvert.DeserializeObject(response_content);
                    //MessageBox.Show(deserialized.ToString());

                    return deserialized;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                if (show_error)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            finally
            {

            }
            return null;
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

        public static async Task<string> CHECK_IMS(string serverUrl)
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
                            string conn_string = await CHECK_IMS("http://" + ipAddress + ":9000/Connection/");
                            lock (lockObject)
                            {
                                dt.Rows.Add(i, ipAddress, "Installed", "Server" , Convert.ToString(conn_string));

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
                        try
                        {
                            // Invoke the UI thread to update the DataGridView
                            Invoke(new System.Action(() =>
                            {
                                Machines.DataSource = null; // Clear previous data
                                Machines.DataSource = dt; // Update with new data
                                Machines.Columns[4].Visible = false;

                            }));
                        }catch(Exception ex)
                        {

                        }
                        


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

        public async void DownloadService( string service_type)
        {
            string output = string.Empty;
            service_pathUser = service_pathUser.Replace("\\", "/");
            string filePath = "";
            if (service_type == "Server")
            {
                dynamic latest_release = await FetchData("https://api.github.com/repos/LanternNassi/Server-Service/releases/latest");
                dynamic release_info = await FetchData(Convert.ToString(latest_release["assets_url"]));

                filePath = Convert.ToString(release_info[0]["browser_download_url"]);
            }
            else
            {
                dynamic latest_release = await FetchData("https://api.github.com/repos/LanternNassi/IMS_Client_Service/releases/latest");
                dynamic release_info = await FetchData(Convert.ToString(latest_release["assets_url"]));
                //MessageBox.Show(Convert.ToString(release_info));
                filePath = Convert.ToString(release_info[0]["browser_download_url"]);
            }
            var files = filePath.Split('/');
            service_pathUser = service_pathUser + @"/" + files[files.Count() - 1];
            //wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
            service_wc.DownloadFileCompleted += new AsyncCompletedEventHandler(Install_service);
            Console.WriteLine("Downloading Windows server....");
            service_wc.DownloadFileAsync(new Uri(filePath), service_pathUser);
            handle.WaitOne();

        }


        public void Install_Updator(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                // Start the process
                using (Process process = new Process())
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    process.StartInfo.FileName = path + "/IMSUpdate.exe";
                    process.StartInfo.Arguments = "/silent /norestart";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;
                    process.StartInfo.CreateNoWindow = true;

                    // Start the process
                    process.Start();

                    // Read the output and errors (if needed)
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    // Wait for the process to exit
                    process.WaitForExit();

                    // Display output and errors (if needed)
                    Console.WriteLine("Output:\n" + output);
                    Console.WriteLine("Error:\n" + error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public async void DownloadUpdator()
        {

            string output = string.Empty;
            updator_pathUser = updator_pathUser.Replace("\\", "/");
            string filePath = "";

            // Getting the updater information
            dynamic latest_release = await FetchData("https://api.github.com/repos/LanternNassi/IMSUPDATE/releases/latest");
            dynamic release_info = await FetchData(Convert.ToString(latest_release["assets_url"]));

            filePath = Convert.ToString(release_info[0]["browser_download_url"]);

            var files = filePath.Split('/');
            updator_pathUser = updator_pathUser + @"/" + files[files.Count() - 1];
            //wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
            updator_wc.DownloadFileCompleted += new AsyncCompletedEventHandler(Install_Updator);
            Console.WriteLine("Downloading IMS updator....");
            updator_wc.DownloadFileAsync(new Uri(filePath), updator_pathUser);
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
            Environment.SetEnvironmentVariable(variableName, variableValue, EnvironmentVariableTarget.Process);

        }



        


        // Install the microservice

        
        public void Install_service(object sender, AsyncCompletedEventArgs e)
        //public void Install_service()
        {
            string service_path = service_pathUser;
            //string service_path = "C:/Users/SHANY/Downloads/Server.Service.exe";
            //string service_path = "C:/Users/SHANY/Desktop/IMS_Service/Server Service/bin/Release/Server Service.exe";
            try
            {
                Console.WriteLine("Service installation started.");
                // Set up the assembly installer
                using (AssemblyInstaller installer = new AssemblyInstaller(service_path, null))
                {
                    Console.WriteLine("Service installation started 2.");

                    installer.UseNewContext = true;

                    // Install the service
                    installer.Install(null);

                    // Commit the installation
                    installer.Commit(null);

                    Console.WriteLine("Service installed successfully.");
                }

                //Starting the service
                ServiceController service;

                if (selected_installation == "Client")
                {
                    service = new ServiceController("IMSClient");

                }
                else
                {
                    service = new ServiceController("IMSServer");

                }

                if ((service.Status.Equals(ServiceControllerStatus.Stopped)) ||

                    (service.Status.Equals(ServiceControllerStatus.StopPending)))
                {
                    service.Start();

                }

                else service.Stop();

                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error installing service: {ex.Message}");
                MessageBox.Show("An error occured during installation . Please consider starting the installation as an administator to clear some of the issues.");
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
            string filePath = "https://www.almsysinc.com/soft/files/microsoft/SQLEXPR_x64_ENU_2012.exe";
            //string filePath = " https://download.microsoft.com/download/3/8/d/38de7036-2433-4207-8eae-06e247e17b25/SQLEXPR_x64_ENU.exe";
            //string filePath = "http://127.0.0.1:8080/SQLEXPR_x86_ENU_2012.exe";
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

            string strComputerName = Environment.MachineName.ToString();
            string computed_server_name = strComputerName + @"\SQLSERVER2012";
            string local_server_database_conn_string = "Data Source=" + computed_server_name + ";Initial Catalog=IMSProd;Integrated Security=True;TrustServerCertificate=True";
            Environment.SetEnvironmentVariable("IMS_conn_string", local_server_database_conn_string, EnvironmentVariableTarget.Process);

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

                bool settings_success = SettingsConfig.AddSettings(settings);

                
                //Creating the firewall rule to allow connections through port 9000
                create_firewall_entry_port();

                //Starting the service installation
                DownloadService("Server");

                //Downloading the IMS UPdate
                DownloadUpdator();


                this.Hide();
                Screen_forms.frmCompany cform = new frmCompany();
                cform.Show();
                //Login_form Lform = new Login_form();
                //Lform.Show();
            }

        }

        private async void frmSetup_Load(object sender, EventArgs e)
        {
            //Loading all machines on the network

            DataTable dt = await GetNetworkConnectedMachinesAsync();
            //Machines.DataSource = dt;

            
        }

        private void frmSetup_Shown(object sender, EventArgs e)
        {
            

        }

        private void frmSetup_Activated(object sender, EventArgs e)
        {
            
        }


        private async void start_btn_Click(object sender, EventArgs e)
        {
            if (this.start_btn.Text == "Start Setup")
            {
                Cursor = Cursors.WaitCursor;

                start_btn.Text = "Cancel Setup";

                //Check if the computer is connected to the network and any type of installations that exist
                if (client.CheckState.ToString() == "Checked" && (selected_server_ip != ""))
                {
                    //Creating the firewall rule to allow connections through port 9000
                    create_firewall_entry_port();

                    //Starting the service installation
                    DownloadService("Client");
                    selected_installation = "Client";
                    DownloadUpdator();

                    string cnn = "";


                    void get_conn_str()
                    {

                        string conn_str = Interaction.InputBox("Server Connection String", "Enter the connection string of the server machine", selected_machine_conn_string);
                        SqlConnection conn = new SqlConnection();
                        try
                        {
                            conn = new SqlConnection(conn_str);
                            conn.Open();
                            MessageBox.Show("The connection string is valid.");
                            cnn = conn_str;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("The connection string is not valid in the context");
                            get_conn_str();
                        }
                        finally
                        {
                            conn.Close();
                        }

                    }

                    //Getting the connection string
                    get_conn_str();

                    try
                    {
                        

                        //This sets the environment variable in the current process
                        Environment.SetEnvironmentVariable("IMS_conn_string", cnn, EnvironmentVariableTarget.Process);

                        //This sets the environment variable in the system for subsquent processes
                        Environment.SetEnvironmentVariable("IMS_conn_string", cnn, EnvironmentVariableTarget.Machine);

                        Console.WriteLine($"Environment variable {cnn} set successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error setting environment variable: {ex.Message}");
                    }

                    //Create_conn_env_variable(selected_server_ip);
                    MessageBox.Show("Client Service installed");
                    this.Hide();
                    Login_form Lform = new Login_form();
                    Lform.Show();


                }
                else
                {
                    selected_installation = "Server";

                    if (this.client_id.Text.Trim() == "")
                    {
                        MessageBox.Show("Please Add your client id provided by the software provider");
                        Cursor = Cursors.Default;
                        return;

                    }

                    //Verifying the client id 
                    dynamic client_verification = await FetchData("https://org-latest.onrender.com/clients/" + this.client_id.Text.Trim());


                    if (client_verification == null)
                    {
                        MessageBox.Show("The client id provided doesnot exist . Please contact the software provider for more information");
                        Cursor = Cursors.Default;
                        return;
                    }


                    //Getting Settings configuration
                    if (MessageBox.Show("Do you have any configurations to set up for your system ?", "Configurations Set uo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // user clicked yes
                        Abbey_Trading_Store.Settings sett = new Abbey_Trading_Store.Settings();
                        string api_key = Interaction.InputBox("Messages", "Enter your account message API key", "");
                        if (api_key.Length > 40)
                        {
                            sett.MessageAPIKey = api_key;

                            sett.Messages = "true";
                        }
                        else
                        {
                            sett.MessageAPIKey = "";
                        }

                        sett.ClientId = this.client_id.Text.Trim();

                        DateTime dateTime = Convert.ToDateTime(client_verification.ValidTill);

                        if (dateTime < SqlDateTime.MinValue.Value)
                        {
                            dateTime = SqlDateTime.MinValue.Value;
                        }


                        sett.ValidTill = dateTime;
                        sett.MessageUsername = Interaction.InputBox("Enter your account message username", "Messages", "");
                        sett.MessageFrom = Interaction.InputBox("Enter your 'From' field according to your dashboard", "Messages", "");
                        sett.Active = "true";
                        sett.Date_configured = DateTime.Now;
                        dynamic latest_release_info = await FetchData("https://api.github.com/repos/LanternNassi/IMS/releases/latest");
                        string numericPart = Regex.Replace(Convert.ToString(latest_release_info["tag_name"]), "[^0-9]", "");
                        if (int.TryParse(numericPart, out int versionNumber))
                        {
                            sett.AppVersion = versionNumber.ToString();
                        }
                        else
                        {
                            sett.AppVersion = "0";
                        }

                        settings = sett;


                    }
                    else
                    {
                        
                        
                    }


                    DownloadSQL();
                    //Install_service();

                }

                Cursor = Cursors.Default;

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
            if (client.CheckState.ToString() == "Checked")
            {
                selected_server_ip = Machines.Rows[row].Cells[1].Value.ToString();
                selected_machine_conn_string = Machines.Rows[row].Cells[4].Value.ToString();
                selected_server.Text = "Connect to " + Machines.Rows[row].Cells[1].Value.ToString();
            }
            else
            {
                MessageBox.Show("A client option and server machine should be selected.");
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
