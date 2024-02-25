using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;
using AfricasTalkingCS;
using System.Windows.Forms;
using System.ServiceProcess;
using Microsoft.SqlServer.Management.Smo;

namespace Abbey_Trading_Store.DAL.DAL_Properties
{
    static class Env
    {


        private static string get_conn_string()
        {
            

            string conn_str = Environment.GetEnvironmentVariable("IMS_conn_string");
            if (conn_str != null)
            {
                return conn_str;
            }
            else
            {
                string strComputerName = Environment.MachineName.ToString();
                string computed_server_name = strComputerName + @"\SQLSERVER2012";
                return "Data Source=" + computed_server_name + ";Initial Catalog=IMSProd;Integrated Security=True;TrustServerCertificate=True";
            }


        }


        public static string live_url = "http://localhost:8000";
        public static string debug_url = "http://localhost:8000";
        public static bool debug_enabled = false;

        public static int mode = 2;
        public static int layout = 2;
        public static string local_database_conn_string = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
        public static string installation_type = "";
        //public static string local_server_database_conn_string = "Data Source=192.168.43.6,1433;User ID=Nessim;password=bukasa;Initial Catalog=master;Integrated Security=True;";
        //public static string local_server_database_conn_string = "Data Source=DESKTOP-GJ3SJ11;Initial Catalog=\"Production 3\";Persist Security Info=True;User ID=sa;Password=bukasa;";

        //Getting the file from the specified location
        private static string file_path = @"C:\Users\" + Environment.UserName + @"\ConnString.txt";
        
        //public static string local_server_database_conn_string = File.ReadLines(file_path).First();
        static string strComputerName = Environment.MachineName.ToString();
        static string computed_server_name = strComputerName + @"\SQLSERVER2012";
        //public static string local_server_database_conn_string = "Data Source=" + computed_server_name + ";Initial Catalog=Tes2;Integrated Security=True;TrustServerCertificate=True";
        public static string local_server_database_conn_string = get_conn_string();

        //Loading the account information

        //public statsic SqlDataAdapter account_adapter = BusinessAccount.Select();

        //AfricasTalking info
        public static string AppVersion = "";
        public static string Messages = "";
        public static string MessageLiveUri = "https://api.africastalking.com/version1/messaging";
        public static string MessageAPIKey = "";
        public static string MessageUsername = "";
        public static string MessageFrom = null;
        public static dynamic MessageGateway = "";
        public static string Active = "";
        public static DateTime Date_configured = DateTime.Now;
        public static string ClientId = "";
        public static DateTime ValidTill;

        public static string OrgUrl = "https://imscontroller-1.onrender.com";



        public static string BusinessName = "";
        public static string BusinessDescription = "";
        public static string Tel_1 = "";
        public static string Tel_2 = "";
        public static string Tel_3 = "";
        public static string Valid = "";
        public static string Location = "";


    }
}
