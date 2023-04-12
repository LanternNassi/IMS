using System;
using System.Collections.Generic;
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
        public static string local_database_conn_string = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
        public static string local_server_database_conn_string = "Data Source=127.0.0.1,1433;Initial Catalog=Test1;Integrated Security=True";
     
    }
}
