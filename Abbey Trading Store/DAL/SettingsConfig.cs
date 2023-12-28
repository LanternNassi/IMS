using Abbey_Trading_Store.DAL.DAL_Properties;
using Abbey_Trading_Store.UI.Advanced.Screen_forms;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
            Settings settings= new Settings();
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
                const string cmds = "INSERT INTO Settings(AppVersion,Messages,MessageAPIKey,MessageUsername,MessageFrom,Active,Date_configured)VALUES(@AppVersion,@Messages,@MessageAPIKey,@MessageUsername,@MessageFrom,@Active,@Date_configured);";
                SqlCommand cmd = new SqlCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@AppVersion", settings.AppVersion);
                cmd.Parameters.AddWithValue("@Messages", settings.Messages);
                cmd.Parameters.AddWithValue("@MessageAPIKey", settings.MessageAPIKey);
                cmd.Parameters.AddWithValue("@MessageUsername", settings.MessageUsername);
                cmd.Parameters.AddWithValue("@MessageFrom", settings.MessageFrom);
                cmd.Parameters.AddWithValue("@Active", settings.Active);
                cmd.Parameters.AddWithValue("@Date_configured", settings.Date_configured);



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


        public static bool UpdateSettings(int id , Settings settings)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {

                const string cmds = "UPDATE Settings SET AppVersion = @AppVersion,Messages=@Messages,MessageAPIKey=@MessageAPIKey,MessageUsername=@MessageUsername,MessageFrom=@MessageFrom,Active=@Active,Date_configured=@Date_configured WHERE id = @id";
                SqlCommand cmd = new SqlCommand(cmds, conn);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@AppVersion", settings.AppVersion);
                cmd.Parameters.AddWithValue("@Messages", settings.Messages);
                cmd.Parameters.AddWithValue("@MessageAPIKey", settings.MessageAPIKey);
                cmd.Parameters.AddWithValue("@MessageUsername", settings.MessageUsername);
                cmd.Parameters.AddWithValue("@MessageFrom", settings.MessageFrom);
                cmd.Parameters.AddWithValue("@Active", settings.Active);
                cmd.Parameters.AddWithValue("@Date_configured", settings.Date_configured);



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
            catch(Exception ex)
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
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = service_pathUser,
                    UseShellExecute = true,
                    Arguments = "/SILENT", // Use silent mode for Inno Setup
                };

                using (Process process = new Process { StartInfo = startInfo })
                {
                    process.Start();
                    process.WaitForExit(); // Wait for the installer to finish
                }

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


                MessageBox.Show("The update process is done . You might consider restarting your application for the update to take effect");
                form_screen.Hide();
                
                // Optionally, you may want to restart your application after the update
                Process.Start("Abbey Trading Store.exe");
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

        public static async void Download_install_update(UpdateScreen form , MaterialSkin.Controls.MaterialProgressBar progress , Label label)
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
            
            var files = filePath.Split('/');
            service_pathUser = service_pathUser + @"/" + files[files.Count() - 1];
            update_wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
            update_wc.DownloadFileCompleted += new AsyncCompletedEventHandler(Install_update);
            Console.WriteLine("Downloading Windows server....");
            update_wc.DownloadFileAsync(new Uri(filePath), service_pathUser);
            handle.WaitOne();
        }



        


    }
}
