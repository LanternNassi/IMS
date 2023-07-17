using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL.DAL_Properties;
using Newtonsoft.Json;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace Abbey_Trading_Store.DAL
{
    class DealerAndCustomer
    {
        //fields
        private int id;
        private string type;
        private string name;
        private string email;
        private string contact;
        private string address;
        private string added_by;

        /// <summary>
        /// Instatiating the props class
        DealersCustProps cust = new DealersCustProps();
        /// </summary>

        // properties
        public int Id { get { return id; } set { 
                id = value; 
                cust.Id = value;
            }
        }
        public string Type { get { return type; } set { 
                type = value;
                cust.Type = value;
            }
        }
        public string Name { get { return name; } set { 
                name = value;
                cust.Name = value;
            }
        }
        public string Email { get { return email; } set { 
                email = value;
                cust.Email = value;
            }
        }
        public string Contact { get { return contact; } set { 
                contact = value;
                cust.Contact = value;
            }
        }
        public string Address { get { return address; } set { 
                address = value;
                cust.Address = value;
            }
        }
        public string Added_by { get { return added_by; } set { 
                added_by = value;
                cust.Added_by = value;
            }
        }

        // Declaring the new HTTP client
        HttpClient client = new HttpClient();



        //Global uri
        string uri = Env.debug_enabled ? (Env.debug_url) : (Env.live_url);



        #region Select
        public DataTable Select()
        {
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            const string cmd = "SELECT * FROM DealerCust";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd, conn);
            try
            {
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
        #endregion

        #region Insert
        public bool Insert()
        {
            
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            string command = "INSERT INTO DealerCust(`type`,`Name`,`Email`,`Contact`,`address`,`added_by`)VALUES(@type,@Name,@Email,@Contact,@address,@added_by)";

            try
            {
                OleDbCommand cmd = new OleDbCommand(command, conn);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@added_by", added_by);
                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected < 0)
                {
                    isSuccess = false;
                }
                else
                {
                    isSuccess = true;
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

        public async Task <bool> insert2()
        {
            //Posting to online server
            string derived_uri = uri + "/createCust/";
            var stringPayload = JsonConvert.SerializeObject(cust);

            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(derived_uri, httpContent);

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
               
                return true;
                
            }
            else
            {
                return false;
            }
        }

        #region Search
        public DataTable Search(string keywords)
        {
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            string cmd = "SELECT * FROM DealerCust WHERE ID LIKE '%"+keywords+"%' OR Name LIKE '%"+keywords+"%' ";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd, conn);
            try
            {
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
        #endregion

        #region Update
        public bool Update()
        {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            string command = "UPDATE DealerCust SET type = @type , Name = @Name , Email = @Email , Contact = @Contact , address = @address WHERE ID = @id";

            try
            {
                OleDbCommand cmd = new OleDbCommand(command, conn);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected < 0)
                {
                    isSuccess = false;
                }
                else
                {
                    isSuccess = true;
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

        public async Task<bool> update2()
        {
            string derived_uri = uri + "/updateCust/";
            //Serialize object
            var Stringpayload = JsonConvert.SerializeObject(cust);
            var httpContent = new StringContent(Stringpayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(derived_uri, httpContent);

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Delete
        public bool Delete()
        {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            string command = "DELETE * FROM DealerCust WHERE ID = @id";

            try
            {
                OleDbCommand cmd = new OleDbCommand(command, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected < 0)
                {
                    isSuccess = false;
                }
                else
                {
                    isSuccess = true;
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

        public async Task<bool> delete2()
        {
            string derived_uri = uri + "/deleteCust/" + id + "/";
            //Serialize object
            var Stringpayload = JsonConvert.SerializeObject(cust);
            var httpContent = new StringContent(Stringpayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.DeleteAsync(derived_uri);

            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Search customer or dealer during purchase 
        public string[] search(string keywords)
        {
            string[] results = new string[4];
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            try
            {
                DataTable dt = new DataTable();
                string cmdstring = "SELECT Name , Email , Contact , address FROM DealerCust WHERE ID LIKE '%" + keywords + "%' OR Name LIKE '%" + keywords + "%' ";
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmdstring, conn);
                conn.Open();
                adapter.Fill(dt);
                if(dt.Rows.Count >0){
                     //Filling in the values into the array for returning
                    results[0] = dt.Rows[0]["Name"].ToString();
                    results[1] = dt.Rows[0]["Email"].ToString();
                    results[2] = dt.Rows[0]["Contact"].ToString();
                    results[3] = dt.Rows[0]["address"].ToString();
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

            return results;

        }
        #endregion

        #region Method to check whether the dealer exists
        public bool checker(string name)
        {
            bool check = false;
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            DataTable dt = new DataTable();
            try
            {
                string cmds = "SELECT * FROM DealerCust WHERE Name = @Name ";
                OleDbCommand cmd = new OleDbCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                conn.Open();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    check = true;
                }
                else
                {
                    check = false;
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

            return check;
        }
        #endregion


        #region local server functions

        public DataTable Select_2()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            const string cmd = "SELECT * FROM DealerCust";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd, conn);
            try
            {
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

        public DataTable Search_2(string keywords)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            string cmd = "SELECT * FROM DealerCust WHERE ID LIKE '%" + keywords + "%' OR Name LIKE '%" + keywords + "%' ";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd, conn);
            try
            {
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

        public bool Insert_2()
        {

            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            string command = "INSERT INTO DealerCust(type,Name,Email,Contact,address,added_by)VALUES(@type,@Name,@Email,@Contact,@address,@added_by)";

            try
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@added_by", added_by);
                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected < 0)
                {
                    isSuccess = false;
                }
                else
                {
                    isSuccess = true;
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

        public bool Update_2()
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            string command = "UPDATE DealerCust SET type = @type , Name = @Name , Email = @Email , Contact = @Contact , address = @address WHERE ID = @id";

            try
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected < 0)
                {
                    isSuccess = false;
                }
                else
                {
                    isSuccess = true;
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

        public bool Delete_2()
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            string command = "DELETE  FROM DealerCust WHERE ID = @id";

            try
            {
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                int affected = cmd.ExecuteNonQuery();
                if (affected < 0)
                {
                    isSuccess = false;
                }
                else
                {
                    isSuccess = true;
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

        // Search for customer at purchase time
        public string[] search_2(string keywords)
        {
            string[] results = new string[4];
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                DataTable dt = new DataTable();
                string cmdstring = "SELECT Name , Email , Contact , address FROM DealerCust WHERE ID LIKE '%" + keywords + "%' OR Name LIKE '%" + keywords + "%' ";
                SqlDataAdapter adapter = new SqlDataAdapter(cmdstring, conn);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //Filling in the values into the array for returning
                    results[0] = dt.Rows[0]["Name"].ToString();
                    results[1] = dt.Rows[0]["Email"].ToString();
                    results[2] = dt.Rows[0]["Contact"].ToString();
                    results[3] = dt.Rows[0]["address"].ToString();
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

            return results;

        }

        public bool checker_2(string name)
        {
            bool check = false;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            DataTable dt = new DataTable();
            try
            {
                string cmds = "SELECT * FROM DealerCust WHERE Name = @Name ";
                SqlCommand cmd = new SqlCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                SqlDataAdapter adapter = new SqlDataAdapter();
                conn.Open();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    check = true;
                }
                else
                {
                    check = false;
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

            return check;
        }

        private string Contact_Cleaner(string Contact)
        {
            if (Contact.Contains("/"))
            {
                Contact = Contact.Substring(0,10);
            }
            return "+256" + Contact.Remove(0, 1);
        }

        public DataTable BulkSendCustomerContacts()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);


            try
            {
                string contact = "SELECT Contact FROM DealerCust WHERE type = 'Customer' AND NOT (Contact = '0753103488' OR Contact = '')";
                SqlDataAdapter adapter = new SqlDataAdapter(contact, conn);
                adapter.Fill(dt);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public bool SendMessage(DataTable dt , string Message)
        {
            bool sent = false;
            try
            {
                //Converting to a string 
                string phonebook = "";
                foreach (DataRow row in dt.Rows)
                {
                    if (phonebook == "")
                    {
                        phonebook += Contact_Cleaner(row[0].ToString());
                    }
                    else
                    {
                        phonebook += ("," + Contact_Cleaner(row[0].ToString()));

                    }
                }
                MessageBox.Show(phonebook);


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return sent;
        }

         

        #endregion

        #region Appropriates
        public DataTable SearchAppropriately(string keywords)
        {
            if (Env.mode == 1)
            {
                DataTable dt = Search(keywords);
                return dt;

            }
            else if (Env.mode == 2)
            {
                DataTable dt = Search_2(keywords);
                return dt;

            }
            else
            {
                DataTable dt = Search_2(keywords);
                return dt;

            }
        }

        public DataTable SelectAppropriately()
        {
            if (Env.mode == 1)
            {
                DataTable dt = Select();
                return dt;

            }
            else if (Env.mode == 2)
            {
                DataTable dt = Select_2();
                return dt;

            }
            else
            {
                DataTable dt = Select_2();
                return dt;

            }

        }

        public async Task<bool> InsertAppropriately()
        {
            if (Env.mode == 1)
            {
                bool result = Insert();
                return result;

            }
            else if (Env.mode == 2)
            {
                bool result = Insert_2();
                return result;

            }
            else
            {
                var success = await insert2();
                bool result = Insert_2();
                return result;

            }
        }

        public async Task<bool> UpdateAppropriately()
        {
            if (Env.mode == 1)
            {
                bool result = Update();
                return result;

            }
            else if (Env.mode == 2)
            {
                bool result = Update_2();
                return result;

            }
            else
            {
                var success = await update2();
                bool result = Update_2();
                return result;


            }
        }

        public async Task<bool> DeleteAppropriately()
        {
            if (Env.mode == 1)
            {
                bool result = Delete();
                return result;

            }
            else if (Env.mode == 2)
            {
                bool result = Delete_2();
                return result;
            }
            else
            {
                var success = await delete2();
                bool result = Delete_2();
                return result;

            }
        }

        public string[] searchAppropriately(string keywords)
        {
            if (Env.mode == 1)
            {
                return search(keywords);

            }
            else if (Env.mode == 2)
            {
                return search_2(keywords);

            }
            else
            {
                return search_2(keywords);

            }

        }

        public bool CheckerAppropriately(string name)
        {
            if (Env.mode == 1)
            {
                return checker(name);

            }
            else if (Env.mode == 2)
            {
                return checker_2(name);

            }
            else
            {
                return checker_2(name);

            }

        }
        #endregion

    }
}
