using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Abbey_Trading_Store.DAL.DAL_Properties;
using System.IO;
//using Microsoft.SqlServer;
using Microsoft.ReportingServices.Diagnostics.Internal;
//using Microsoft.SqlServer.Management.Common;
//using Microsoft.SqlServer.Management.Smo;
//using Microsoft.SqlServer.Management.Sdk.Sfc;
//using Microsoft.SqlServer.ConnectionInfo;

using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Abbey_Trading_Store.UI;

namespace Abbey_Trading_Store.Configurations
{
    class Install_SQL
    {
        private static WebClient wc = new WebClient();
        private static ManualResetEvent handle = new ManualResetEvent(true);
        private static string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private static Thread thread;
        private BackgroundWorker worker = null;
        public string derived_conn_str = null;
        public dynamic form = null;


        

        public bool test_connection()
        {
            bool isSuccess = false;
            SqlConnection conn =new SqlConnection();
            try
            {
                string strComputerName = Environment.MachineName.ToString();
                string computed_server_name = strComputerName + @"\SQLSERVER2012";
                string derived_conn_string = "Data Source="+ computed_server_name + ";Initial Catalog=master;Integrated Security=True";
                conn = new SqlConnection(derived_conn_string);
                conn.Open();
                isSuccess = true;
                derived_conn_str = derived_conn_string;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " From test connection");
            }finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        public bool Write_conn_string()
        {
            bool isSuccess = false;
            try
            {
                string fullPath = @"C:\Users\" + Environment.UserName + @"\ConnString.txt";
                using (StreamWriter writer = new StreamWriter(fullPath))
                {
                    writer.WriteLine(derived_conn_str);
                   
                }
                isSuccess = true;

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

       

        public void teporal_install()
        {
            
        }

        private void ProcessObj_Exited(object sender, EventArgs e)
        {

        }

        
    }
}
