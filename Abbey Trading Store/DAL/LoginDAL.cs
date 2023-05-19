using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Abbey_Trading_Store.DAL
{
    class LoginDAL
    {
        // fields
        private string username;
        private string password;
        private string usertype;

        // properties
        public string Username { get { return username; } set { username = value; } }
        public string Password { get { return password; } set { password = value; } }
        public string Usertype { get { return usertype; } set {
            if (value == "admin")
            {
                usertype = value;
            }
            else if (value == "normal")
            {
                usertype = value;
            }
            else
            {
                usertype = "normal";
            }
        } }

        public string[] login()
        {
            string[] result = new string[2];
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(DAL_Properties.Env.local_database_conn_string);
            conn.Open();
            string cmds = "SELECT * FROM `Users` WHERE `User` = @User AND `Usertype` = @Usertype AND `Contact` = @Password ";
            OleDbCommand cmd = new OleDbCommand(cmds, conn);
            cmd.Parameters.AddWithValue("@User", username);
            cmd.Parameters.AddWithValue("@Usertype", usertype);
            cmd.Parameters.AddWithValue("@Password", password);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable();
            
            adapter.Fill(dt);
            
            if (dt.Rows.Count > 0)
            {
                string type;
                type = dt.Rows[0][5].ToString();
                isSuccess = true;
                result[0] = isSuccess.ToString();
                result[1] = type;
            }
            else
            {
                isSuccess = false;

            }
            conn.Close();
 
            
            return result;
        }

        public string[] login_2()
        {
            string[] result = new string[2];
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(DAL_Properties.Env.local_server_database_conn_string);
            conn.Open();
            string cmds = "SELECT * FROM Users WHERE [User] = @User AND Type = @Usertype AND Contact = @Password ";
            SqlCommand cmd = new SqlCommand(cmds, conn);
            cmd.Parameters.AddWithValue("@User", username);
            cmd.Parameters.AddWithValue("@Usertype", usertype);
            cmd.Parameters.AddWithValue("@Password", password);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                string type;
                type = dt.Rows[0][5].ToString();
                isSuccess = true;
                result[0] = isSuccess.ToString();
                result[1] = type;
            }
            else
            {
                isSuccess = false;

            }
            conn.Close();


            return result;
        }

        public string[] LoginAppropriately()
        {
            if(DAL_Properties.Env.mode == 1)
            {
                return login();
            } else
            {
                return login_2();
            }
        }


    }
}
