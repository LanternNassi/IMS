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



namespace Abbey_Trading_Store.DAL.DAL_Properties
{
    static class Env
    {


        private static string get_conn_string()
        {
            // Replace "YOUR_ENV_VARIABLE_NAME" with the actual name of the environment variable
            string variableName = "IMS_conn_string";

            // Retrieve the value of the environment variable
            string variableValue = Environment.GetEnvironmentVariable(variableName);
            if (variableValue != null)
            {
                return variableValue;
            }
            else
            {
                string strComputerName = Environment.MachineName.ToString();
                string computed_server_name = strComputerName + @"\SQLSERVER2012";
                string local_server_database_conn_string = "Data Source=" + computed_server_name + ";Initial Catalog=Tes2;Integrated Security=True;TrustServerCertificate=True";
                return local_server_database_conn_string;
            }

        }

        


        public static string live_url = "http://localhost:8000";
        public static string debug_url = "http://localhost:8000";
        public static bool debug_enabled = false;

        public static int mode = 2;
        public static int layout = 2;
        public static string local_database_conn_string = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";

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
        public static string MessageLiveUri = "https://api.africastalking.com/version1/messaging";
        public static string MessageAPIKey = "db368250139725030ff5413c68f65ac1d3817c80990679741d5a32f1f35ba8c6";
        public static string MessageUsername = "MMAK";
        public static string MessageFrom = null;

        public static dynamic MessageGateway = new AfricasTalkingGateway(MessageUsername, MessageAPIKey);

        private static DataRow Get_business_details()
        {
            SqlDataAdapter adapter = BusinessAccount.Select();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt.Rows[0];
        }

        // Business Details
        private static DataRow business_dr = Get_business_details();

        public static string BusinessName = business_dr[1].ToString();
        public static string BusinessDescription = business_dr[2].ToString();
        public static string Tel_1 = business_dr[3].ToString();
        public static string Tel_2 = business_dr[4].ToString();
        public static string Tel_3 = business_dr[5].ToString();
        public static string Valid = business_dr[6].ToString();
        public static string Location = business_dr[7].ToString();




    }
}
