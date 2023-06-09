﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abbey_Trading_Store.DAL.DAL_Properties
{
    static class Env
    {
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
        
        public static string local_server_database_conn_string = File.ReadLines(file_path).First();
        //public static string local_server_database_conn_string = "Data Source=Nessim;Initial Catalog=Test1;Integrated Security=True";



    }
}
