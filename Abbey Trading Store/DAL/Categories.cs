using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL.DAL_Properties;
using System.Threading.Tasks;
using System.Security.Policy;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System.Drawing;

namespace Abbey_Trading_Store.DAL
{
    class Categories
    {
        //Fields
        private string id;
        private string title;
        private string description;
        private string added_by;
        private int server_id = 0;

        //Instantiating a new props class
        CategoriesProps category = new CategoriesProps();

        // properties
        public string ID { get { return id; } set { 
                id = value; 
                category.ID= value;
            }
        }
        public string Title { get { return title; } set { 
                title = value;
                category.Title = value;
            }
        }
        public string Description { get { return description; } set { 
                description = value;
                category.Description = value;
                
            } }
        public string Added_by { get { return added_by; } set { 
                added_by = value;
                category.Added_by = value;
            }
        }
        public int Server_id { get { return server_id; } set
            {
                server_id = value;
                category.Server_id = value;
            } 
        }
        // Declaring the new HTTP client
        HttpClient client = new HttpClient();



        //Global uri
         string uri = Env.debug_enabled ? (Env.debug_url) : (Env.live_url);

        # region Select method
        public DataTable select()
        {
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            const string command = "SELECT * FROM Categories";
            try
            {
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(command, conn);
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
        #endregion

        #region Add method
        public bool insert()
        {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            try
            {
                const string cmds = "INSERT INTO Categories(`title`,`description`,`added_by`)VALUES(@title,@description,@added_by)";
                OleDbCommand cmd = new OleDbCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("added_by", added_by);
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
        #endregion
        public async Task<bool> insert2()
        {
            //Posting to online server
            string derived_uri = uri + "/createCategory/";
            var stringPayload = JsonConvert.SerializeObject(category);

            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(derived_uri, httpContent);

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                dynamic response_content = await response.Content.ReadAsStringAsync();
                dynamic deserialized = JsonConvert.DeserializeObject(response_content);
                Server_id = Convert.ToInt32(deserialized.id);
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Update
        public bool update()
        {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            try
            {
                const string cmds = "UPDATE `Categories` SET `title`=@title , `description`=@description WHERE `id` = @id";
                OleDbCommand cmd = new OleDbCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@id", id);
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
        #endregion

        public async Task <bool> Update2()
        {
            string derived_uri = uri + "/updateCategory/";
            //Serialize object
            var Stringpayload = JsonConvert.SerializeObject(category);
            var httpContent = new StringContent(Stringpayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(derived_uri, httpContent);

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                dynamic response_content = await response.Content.ReadAsStringAsync();
                dynamic deserialized = JsonConvert.DeserializeObject(response_content);
                Server_id = Convert.ToInt32(deserialized.id);
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Delete method
        public bool delete()
        {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            const string a = "Nassim";
            try
            {
                const string cmds = "DELETE * FROM `Categories` WHERE `id` = @id";
                OleDbCommand cmd = new OleDbCommand(cmds, conn);    
                cmd.Parameters.AddWithValue("@id", id);           
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

        #endregion

        public async Task <bool> Delete2()
        {
            string derived_uri = uri + "/deleteCategory/" + id + "/";
            //Serialize object
            var Stringpayload = JsonConvert.SerializeObject(category);
            var httpContent = new StringContent(Stringpayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.DeleteAsync(derived_uri);

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                dynamic response_content = await response.Content.ReadAsStringAsync();
                dynamic deserialized = JsonConvert.DeserializeObject(response_content);
                Server_id = Convert.ToInt32(deserialized.id);
                return true;
            }
            else
            {
                return false;
            }
        }

        # region Search method 
        public DataTable search(string search)
        {
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            string command = "SELECT * FROM Categories WHERE ID LIKE '%"+search +"%' OR title LIKE '%"+search +"%'";
            try
            {
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(command, conn);
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
        #endregion


        #region Local server functions
        public SqlDataAdapter select_2()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter dummy_adapter = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            const string command = "SELECT * FROM Categories";
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
                dummy_adapter = adapter;
                //adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dummy_adapter;
        }

        public DataTable search_2(string search)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            string command = "SELECT * FROM Categories WHERE ID LIKE '%" + search + "%' OR title LIKE '%" + search + "%'";
            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
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
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                const string cmds = "INSERT INTO Categories(title,description,added_by,Server_id)VALUES(@title,@description,@added_by,@Server_id);";
                SqlCommand cmd = new SqlCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@added_by", added_by);
                cmd.Parameters.AddWithValue("@Server_id", server_id);
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


        public bool update_2()
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                const string cmds = "UPDATE Categories SET title=@title , description=@description WHERE id = @id";
                SqlCommand cmd = new SqlCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@id", id);
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

        public bool delete_2()
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            const string a = "Nassim";
            try
            {
                const string cmds = "DELETE  FROM Categories WHERE id = @id";
                SqlCommand cmd = new SqlCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@id", id);
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

        #endregion


        #region Appropriates
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

        public DataTable SelectAppropriately()
        {

            if (Env.mode == 1)
            {
                DataTable dt = select();
                return dt;

            }
            else if (Env.mode == 2)
            {
                SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
                SqlDataAdapter adapter = select_2();
                DataTable dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);
                conn.Close();
                return dt;

            }
            else
            {
                SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
                SqlDataAdapter adapter = select_2();
                DataTable dt = new DataTable();
                conn.Open();
                adapter.Fill(dt);
                conn.Close();
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
                bool result = insert_2();
                return result;

            }
        }

        public async Task<bool> UpdateAppropriately()
        {
            if (Env.mode == 1)
            {
                bool result = update();
                return result;

            }
            else if (Env.mode == 2)
            {
                bool result = update_2();
                return result;

            }
            else
            {
                var success = await Update2();
                bool result = update_2();
                return result;


            }
        }

        public async Task<bool> DeleteAppropriately()
        {
            if (Env.mode == 1)
            {
                bool result = delete();
                return result;

            }
            else if (Env.mode == 2)
            {
                bool result = delete_2();
                return result;
            }
            else
            {
                var success = await Delete2();
                bool result = delete_2();
                return result;

            }
        }

        #endregion




    }
}
