using Abbey_Trading_Store.DAL.DAL_Properties;
using Abbey_Trading_Store.UI.Advanced.Screen_forms;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
//using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Net.Http;
using Azure.Storage.Blobs;
using Newtonsoft.Json;
using System.Security.Policy;
using System.Web;
using System.Windows.Forms;
using Cursor = System.Windows.Forms.Cursor;

namespace Abbey_Trading_Store.DAL
{
    public class SettingsConfig
    {
        Settings settings;
        private static WebClient update_wc = new WebClient();
        private static ManualResetEvent handle = new ManualResetEvent(true);
        static string service_pathUser = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        static UpdateScreen form_screen;
        static MaterialSkin.Controls.MaterialProgressBar progressbar;
        static Label progresslabel;


        public SettingsConfig(Settings fsettings)
        {
            settings = fsettings;
        }
        public SettingsConfig(int id)
        {

        }


        //Getting Settings 
        public static Settings GetSettings(int id)
        {
            DataTable dt = new DataTable();
            Settings settings = new Settings();
            const string command = "SELECT * FROM Settings";
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);

            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
                adapter.Fill(dt);

                settings.id = Convert.ToInt32(dt.Rows[0][0]);
                settings.AppVersion = dt.Rows[0][1].ToString();
                settings.Messages = dt.Rows[0][2].ToString();
                settings.MessageAPIKey = dt.Rows[0][3].ToString();
                settings.MessageUsername = dt.Rows[0][4].ToString();
                settings.MessageFrom = dt.Rows[0][5].ToString();
                settings.Active = dt.Rows[0][6].ToString();
                settings.Date_configured = Convert.ToDateTime(dt.Rows[0][7]);
                settings.ClientId = dt.Rows[0][8].ToString();
                settings.ValidTill = Convert.ToDateTime(dt.Rows[0][9].ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ".Settings");
            }
            finally
            {
                conn.Close();
            }
            return settings;
        }

        public static bool AddSettings(Settings settings)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                const string cmds = "INSERT INTO Settings(AppVersion,Messages,MessageAPIKey,MessageUsername,MessageFrom,Active,Date_configured,ClientId,ValidTill)VALUES(@AppVersion,@Messages,@MessageAPIKey,@MessageUsername,@MessageFrom,@Active,@Date_configured,@ClientId,@ValidTill);";
                SqlCommand cmd = new SqlCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@AppVersion", settings.AppVersion);
                cmd.Parameters.AddWithValue("@Messages", settings.Messages);
                cmd.Parameters.AddWithValue("@MessageAPIKey", settings.MessageAPIKey);
                cmd.Parameters.AddWithValue("@MessageUsername", settings.MessageUsername);
                cmd.Parameters.AddWithValue("@MessageFrom", settings.MessageFrom);
                cmd.Parameters.AddWithValue("@Active", settings.Active);
                cmd.Parameters.AddWithValue("@Date_configured", settings.Date_configured);
                cmd.Parameters.AddWithValue("@ClientId", settings.ClientId);
                cmd.Parameters.AddWithValue("@ValidTill", settings.ValidTill);


                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }



        public static bool UpdateSettings(int id, Settings settings)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {

                const string cmds = "UPDATE Settings SET AppVersion = @AppVersion,Messages=@Messages,MessageAPIKey=@MessageAPIKey,MessageUsername=@MessageUsername,MessageFrom=@MessageFrom,Active=@Active,Date_configured=@Date_configured,ClientId=@ClientId,ValidTill=@ValidTill WHERE id = @id";
                SqlCommand cmd = new SqlCommand(cmds, conn);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@AppVersion", settings.AppVersion);
                cmd.Parameters.AddWithValue("@Messages", settings.Messages);
                cmd.Parameters.AddWithValue("@MessageAPIKey", settings.MessageAPIKey);
                cmd.Parameters.AddWithValue("@MessageUsername", settings.MessageUsername);
                cmd.Parameters.AddWithValue("@MessageFrom", settings.MessageFrom);
                cmd.Parameters.AddWithValue("@Active", settings.Active);
                cmd.Parameters.AddWithValue("@Date_configured", settings.Date_configured);
                cmd.Parameters.AddWithValue("@ClientId", settings.ClientId);
                cmd.Parameters.AddWithValue("@ValidTill", settings.ValidTill);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return isSuccess;
        }


        public static async void Install_update(object sender, AsyncCompletedEventArgs e)
        {
            //form_screen.Hide();

            try
            {
                //Update the current version 
                dynamic latest_release_info = await frmSetup.FetchData("https://api.github.com/repos/LanternNassi/IMS/releases/latest");
                string numericPart = Regex.Replace(Convert.ToString(latest_release_info["tag_name"]), "[^0-9]", "");
                if (int.TryParse(numericPart, out int versionNumber))
                {
                    Settings setting = GetSettings(1);
                    setting.AppVersion = numericPart;
                    bool success = UpdateSettings(1, setting);
                    if (!success)
                    {
                        MessageBox.Show("An error happened while updating the versio code");
                    }
                }


                //Start the updator
                string installer = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "/IMSUpdate/IMSUpdate.exe";


                using (Process process = new Process())
                {
                    process.StartInfo.FileName = installer;
                    process.StartInfo.UseShellExecute = true; // Set to false if you want to redirect output
                    process.Start();
                }

                //Exit the application
                Application.Exit();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        static void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            form_screen.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());

                decimal total_mbs = UnitsNet.Information.FromBytes(e.TotalBytesToReceive).Megabytes;
                decimal current_mbs = UnitsNet.Information.FromBytes(e.BytesReceived).Megabytes;

                double percentage = bytesIn / totalBytes * 100;
                progresslabel.Text = decimal.Round(current_mbs, 2) + " MB / " + decimal.Round(total_mbs, 2) + " MB";
                progressbar.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }

        public static async void Download_install_update(UpdateScreen form, MaterialSkin.Controls.MaterialProgressBar progress, Label label)
        {
            form_screen = form;
            progressbar = progress;
            progresslabel = label;

            string output = string.Empty;
            service_pathUser = service_pathUser.Replace("\\", "/");
            string filePath = "";

            dynamic latest_release = await UI.Advanced.Screen_forms.frmSetup.FetchData("https://api.github.com/repos/LanternNassi/IMS/releases/latest");
            dynamic release_info = await UI.Advanced.Screen_forms.frmSetup.FetchData(Convert.ToString(latest_release["assets_url"]));

            filePath = Convert.ToString(release_info[0]["browser_download_url"]);

            //filePath = "http://127.0.0.1:8080/IMS.exe";


            var files = filePath.Split('/');
            service_pathUser = service_pathUser + @"/" + files[files.Count() - 1];
            update_wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
            update_wc.DownloadFileCompleted += new AsyncCompletedEventHandler(Install_update);
            Console.WriteLine("Downloading Update....");
            update_wc.DownloadFileAsync(new Uri(filePath), service_pathUser);
            handle.WaitOne();
        }

        public static async void RequestForPayment() {


        }


        static bool DeleteFile(string directoryPath, string fileName)
        {
            string filePath = Path.Combine(directoryPath, fileName);

            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting file: {ex.Message}");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("File not found.");
                return false;
            }
        }


        public static async void CreateBackUp(string clientId)
        {


            DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "IMSProd.bak");

            string strComputerName = Environment.MachineName.ToString();
            string computed_server_name = strComputerName + @"\SQLSERVER2012";

            // Create a new instance of the Server object
            Server server = new Server(new ServerConnection(computed_server_name));

            try
            {
                // Create a new Backup object
                Backup backup = new Backup
                {
                    Action = BackupActionType.Database,
                    Database = "IMSProd"
                };

                // Define the backup file location
                backup.Devices.AddDevice(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/IMSProd.bak", DeviceType.File);

                // Perform the backup
                backup.SqlBackup(server);
                Console.WriteLine("Backup completed successfully... Uploading the backup");

                // Uploading the backup store
                UploadBackUp(clientId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Backup failed: " + ex.Message);
            }
            finally
            {
                server.ConnectionContext.Disconnect();
            }
        }


        public static string[] GenerateRandomCombinations(int count, int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_=+[]{}|;:,.<>?";

            string[] combinations = new string[count];

            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var sb = new StringBuilder(length);

                for (int j = 0; j < length; j++)
                {
                    sb.Append(chars[random.Next(chars.Length)]);
                }

                combinations[i] = sb.ToString();
            }

            return combinations;
        }



        public static async Task<(string uri , long size)> UploadFileToAzure(string filePath , string blobName)
        {
            // Azure Storage connection string
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=imsbackups;AccountKey=9+/oR8w0B/8ckTq5wTxQnCTkR+Zd2nD0hc8EE/1pzLBNQQgCJ7/GdKf2Ye0hYLLktNDvViIj4mfn+AStKozyoA==;EndpointSuffix=core.windows.net";

            // Name of the container
            string containerName = "backups";

            
            try
            {
                // Create a BlobServiceClient
                BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

                // Get a reference to the container
                BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

                // Ensure the container exists
                await containerClient.CreateIfNotExistsAsync();

                // Get a reference to the blob
                BlobClient blobClient = containerClient.GetBlobClient(blobName);

                // Upload the file
                FileStream fileStream = File.OpenRead(filePath);
                await blobClient.UploadAsync(fileStream, overwrite: true);

                var properties = await blobClient.GetPropertiesAsync();

                Console.WriteLine($"File uploaded to blob: {blobClient.Uri}");

                return (blobClient.Uri.ToString() , properties.Value.ContentLength );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return ("" , 0);
            }

        }

        public static async void UploadBackUp(string clientId)
        {
            using (HttpClient client = new HttpClient())
            {
                using (MultipartFormDataContent formData = new MultipartFormDataContent())
                {
                    string backupFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/IMSProd.bak";


                    string UniqueBackUpKey = GenerateRandomCombinations(1, 10)[0];

                    string blobName = Path.GetFileName(backupFilePath);

                    blobName = UniqueBackUpKey + "@" + blobName;


                    var (uploaded_uri , backupSize) = await UploadFileToAzure(backupFilePath , blobName);


                    formData.Add(new StringContent(clientId), "ClientID");
                    formData.Add(new StringContent(blobName), "Name");
                    formData.Add(new StringContent(uploaded_uri), "Backup");
                    formData.Add(new StringContent(backupSize.ToString()), "Size");
                    formData.Add(new StringContent("0"), "Bill");


                    HttpResponseMessage response = await client.PostAsync(Env.OrgUrl + "/backups", formData);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Backup file uploaded successfully.");
                        MessageBox.Show("System BackUp completed successfully");
                        DeleteFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "IMSProd.bak");

                    }
                    else
                    {
                        Console.WriteLine("Failed to upload backup file. Status code: " + response.StatusCode);
                        MessageBox.Show("Failed to upload backup file. Status code: " + response.StatusCode);
                    }
                }
            }
        }

        public static async Task<dynamic> GetBillsByBillId(string billId)
        {

            try
            {

                HttpClient client = new HttpClient();

                string requestUri = Env.OrgUrl + "/backups/bill/" + billId;

                HttpResponseMessage response = await client.GetAsync(requestUri);

                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    dynamic response_content = await response.Content.ReadAsStringAsync();
                    dynamic deserialized = JsonConvert.DeserializeObject(response_content);
                    return deserialized;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }


        }



        public static async Task<dynamic> GetBackupsByClientId(string clientId)
        {

            try
            {

                HttpClient client = new HttpClient();

                string requestUri = Env.OrgUrl + "/backups/client/" + clientId;

                HttpResponseMessage response = await client.GetAsync(requestUri);

                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    dynamic response_content = await response.Content.ReadAsStringAsync();
                    dynamic deserialized = JsonConvert.DeserializeObject(response_content);
                    return deserialized;
                }
                else
                {
                    return null;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

            
        }








    }
}
