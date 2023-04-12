using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL.DAL_Properties;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace Abbey_Trading_Store.DAL
{
    class Users
    {
        //declaring fields
        private int Id;
        private string User;
        private string Password;
        private string Gender;
        private string Added_by;
        private string Type;
        private int Server_id = 0;

        //Getting props class 
        UsersProps userclass = new UsersProps();

        // declaring properties for the fields 
        public int id
        {
            get { return Id; }
            set
            {
                Id = value;
                userclass.id = value;
            }
        }
        public string user { get { return User; } set { 
                User = value;
                userclass.user = value;
            } 
        }
        public string password { get { return Password; } set {
                Password = value;
                userclass.contact = value;
            } 
        }
        public string gender { get { return Gender; } set {
                Gender = value;
                userclass.gender = value;
            } 
        }
        public string added_by { get { return Added_by; } set { 
                Added_by = value;
                userclass.added_by = value;
            } 
        }
        public string type { get { return Type; } set { 
                Type = value;
                userclass.type = value;
            } 
        }
        public int server_id { get { return Server_id; } set { 
                Server_id = value; 
            }
        }



        // Declaring the new HTTP client
        HttpClient client = new HttpClient();

        

        //Global uri
        string uri = Env.debug_enabled ? (Env.debug_url) : (Env.live_url);

        public DataTable select()
        {
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            try
            {
                const string command = "SELECT * FROM Users";
                OleDbDataAdapter adapter = new OleDbDataAdapter(command, conn);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
               

            }

            return dt;

        }


        public bool insert()
        {
            bool isSuccess = true;
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "INSERT INTO `Users` (`User`, `Contact`, `Gender`, `Added_by`, `Type`) VALUES (@User, @Password, @Gender, @Added_by, @Type)";
            cmd.Parameters.AddWithValue("@User", User);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Added_by", Added_by);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Connection = conn;
            try
            {
                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
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

        public async Task<bool> insert2()
        {
            //Posting to online server
            string derived_uri = uri + "/createUser/";
            var stringPayload = JsonConvert.SerializeObject(userclass);

            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(derived_uri, httpContent);

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                dynamic response_content = await response.Content.ReadAsStringAsync();
                dynamic deserialized = JsonConvert.DeserializeObject(response_content);
                server_id = Convert.ToInt32(deserialized.id);
                //MessageBox.Show(deserialized.id);
                return true;
            } else
            {
                return false;
            }
        }

        public DataTable search(string keywords)
        {
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            try
            {
                string command = "SELECT * FROM Users WHERE id LIKE '%" + keywords + "%' OR User LIKE '%" + keywords + "%'";
                OleDbDataAdapter adapter = new OleDbDataAdapter(command, conn);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;

        }


        public bool update(string id)
        {
            bool isSuccess = true;
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "UPDATE `Users` SET `User` = @User, `Contact` = @Password, `Gender` = @Gender, `Added_by` = @Added_by, `Type` = @Type WHERE `ID` = @id ";
            cmd.Parameters.AddWithValue("@User", User);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Added_by", Added_by);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = conn;
            try
            {
                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
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

        public async Task<bool> update2()
        {
            string derived_uri = uri + "/updateUser/";
            //Serialize object
            var Stringpayload = JsonConvert.SerializeObject(userclass);
            var httpContent = new StringContent(Stringpayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(derived_uri, httpContent);

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                dynamic response_content = await response.Content.ReadAsStringAsync();
                dynamic deserialized = JsonConvert.DeserializeObject(response_content);
                server_id = Convert.ToInt32(deserialized.id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool delete(string id)
        {
            bool isSuccess = true;
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "DELETE * FROM `Users` WHERE `ID` = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = conn;
            try
            {
                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
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

        public async Task<bool> delete2(int User)
        {
            string derived_uri = uri + "/deleteUser/"+User+"/";
            //Serialize object
            var Stringpayload = JsonConvert.SerializeObject(userclass);
            var httpContent = new StringContent(Stringpayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.DeleteAsync(derived_uri);

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                dynamic response_content = await response.Content.ReadAsStringAsync();
                dynamic deserialized = JsonConvert.DeserializeObject(response_content);
                server_id = Convert.ToInt32(deserialized.id);
                return true;
            }
            else
            {
                return false;
            }

        }


        // All modifier functions for the database server 

        public DataTable select_2()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                const string command = "SELECT * FROM Users";
                SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();


            }

            return dt;

        }

        public bool insert_2()
        {
            bool isSuccess = true;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "INSERT INTO Users([User], Contact, Gender, Added_by, Type , Server_id) VALUES (@User, @Password, @Gender, @Added_by, @Type , @Server_id);";
            cmd.Parameters.AddWithValue("@User", User);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Added_by", Added_by);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@Server_id", Server_id);
            cmd.Connection = conn;
            try
            {
                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
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

        public DataTable search_2(string keywords)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                string command = "SELECT * FROM Users WHERE id LIKE '%" + keywords + "%' OR User LIKE '%" + keywords + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;

        }

        public bool update_2(string id)
        {
            bool isSuccess = true;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATE Users SET [User] = @User, Contact = @Password, Gender = @Gender, Added_by = @Added_by, Type = @Type WHERE ID = @id ";
            cmd.Parameters.AddWithValue("@User", User);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Gender", Gender);
            cmd.Parameters.AddWithValue("@Added_by", Added_by);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = conn;
            try
            {
                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
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

        public bool delete_2(string id)
        {
            bool isSuccess = true;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM Users WHERE ID = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = conn;
            try
            {
                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected > 0)
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

        // End of all modeifier functions for the database server

        public DataTable SelectAppropriately()
        {
            if (Env.mode == 1)
            {
                DataTable dt = select();
                return dt;

            }else if (Env.mode == 2)
            {
                DataTable dt = select_2();
                return dt;

            }else
            {
                DataTable dt = select_2();
                return dt;

            }
        }

        public async Task<bool> InsertAppropriately()
        {
            if (Env.mode == 1)
            {
                bool result = insert();
                return result;

            }
            else if (Env.mode == 2)
            {
                bool result = insert_2();
                return result;

            }
            else
            {
                var success = await insert2();
                bool result_2 = insert_2();
                return true;

            }
        }

        public DataTable SearchAppropriately(string keywords)
        {
            if (Env.mode == 1)
            {
                DataTable dt = search(keywords);
                return dt;

            }
            else if (Env.mode == 2)
            {
                DataTable dt = search_2(keywords);
                return dt;

            }
            else
            {
                DataTable dt = search_2(keywords);
                return dt;

            }

        }

        public async Task<bool> UpdateAppropriately(string id)
        {
            if (Env.mode == 1)
            {
                bool result = update(id);
                return result;

            }
            else if (Env.mode == 2)
            {
                bool result = update_2(id);
                return result;

            }
            else
            {
                var success = await update2();
                bool result_2 = update_2(id);
                return true; 

            }
        }

        public async Task<bool> DeleteApprpriately(string id)
        {
            if (Env.mode == 1)
            {
                bool result = delete(id);
                return result;

            }
            else if (Env.mode == 2)
            {
                bool result = delete_2(id);
                return result;

            }
            else
            {
                var success = await delete2(Convert.ToInt32(id));
                bool result_2 = delete_2(id);
                return true;

            }

        }



    }
}
