using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Data.OleDb;
using Abbey_Trading_Store.DAL.DAL_Properties;
using System.Windows.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Data.SqlClient;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Abbey_Trading_Store.DAL
{
    class TransactionDetail
    {
        //Fields
        private int ID;
        private string product_name;
        private decimal rate;
        private decimal Qty;
        private decimal total;
        private string dea_cust_name;
        private DateTime added_date;
        private string added_by;
        private int Invoice_id;
        private int Profit;
        private string Type;
        private int Server_id;

        TransactionDetailProps detail = new TransactionDetailProps();
        //Properties
        public int id { get { return ID; } set {
                ID = value;
                detail.id = value;
            }
        }
        public string Product_name { get { return product_name; } set {
                product_name = value;
                detail.Product_name = value;
            }
        }
        public decimal Rate { get { return rate; } set {
                rate = value;
                detail.Rate = value;
            }
        }
        public decimal qty { get { return Qty; } set {
                Qty = value;
                detail.qty = value;
            }
        }
        public decimal Total { get { return total; } set {
                total = value;
                detail.Total = value;
            }
        }
        public string Dea_Cust_name { get { return dea_cust_name; } set {
                dea_cust_name = value;
                detail.Dea_Cust_name = value;
            }
        }
        public DateTime Added_date { get { return added_date; } set {
                added_date = value;
                detail.Added_date = value;
            }
        }
        public string Added_by { get { return added_by; } set {
                added_by = value;
                detail.Added_by = value;
            }
        }
        public int invoice_id { get { return Invoice_id; } set {
                Invoice_id = value;
                detail.invoice_id = value;
            }
        }
        public int profit { get { return Profit; } set {
                Profit = value;
                detail.profit = value;
            }
        }
        public string type {get{ return Type; } set {
                Type = value;
                detail.type = value;
            } 
        }
        public int server_id { get { return Server_id; } set {
                Server_id = value;
                detail.server_id = value;
            }
        }

        // Declaring the new HTTP client
        HttpClient client = new HttpClient();

        //Global uri
        string uri = Env.debug_enabled ? (Env.debug_url) : (Env.live_url);

        
        public bool Insert()
        {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            string cmdstring = "INSERT INTO `Transaction Details`(`product_name`,`rate`,`Qty`,`total`,`dea_cust_name`,`added_by`,`Invoice_id`,`Profit`,`Type`)VALUES(@product_name,@rate,@Qty,@total,@dea_cust_name,@added_by,@Invoice_id,@Profit,@Type)";


            try
            {
                OleDbCommand cmd = new OleDbCommand(cmdstring, conn);
                //cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@product_name",product_name);
                cmd.Parameters.AddWithValue("@rate", rate);
                cmd.Parameters.AddWithValue("@Qty", Qty);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@dea_cust_name", dea_cust_name);
                cmd.Parameters.AddWithValue("@added_by", added_by);
                cmd.Parameters.AddWithValue("@Invoice_id", Invoice_id);
                cmd.Parameters.AddWithValue("@Profit", Profit);
                cmd.Parameters.AddWithValue("@Type", Type);
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
                MessageBox.Show(ex.Message+"TD");

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        public async Task<bool> insert2()
        {
            string derived_uri = uri + "/createdetail/";
            var stringPayload = JsonConvert.SerializeObject(detail);

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
        public DataTable GetAllTransactionDetails(string Name , int transaction_id)
        {
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            string cmdstring = "SELECT product_name,rate,Qty,Total,dea_cust_name,added_date,added_by,Profit,Type FROM `Transaction Details` WHERE `dea_cust_name` = @dea_cust_name AND `Invoice_id` = @Invoice_id";
            try
            {
                OleDbCommand cmd = new OleDbCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@dea_cust_name", Name);
                cmd.Parameters.AddWithValue("Invoice_id", transaction_id);
                OleDbDataAdapter adapter = new OleDbDataAdapter() { SelectCommand = cmd };
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
        public DataTable QueryTransactions(DateTime start_date, DateTime end_date, string type, string product_name = null, string customer_name = null, decimal quantity = 0, string added_by = null)
        {
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            try
            {
                string cmd_text = "SELECT * FROM `Transaction Details` WHERE `type` = '" + type + "' AND `added_date` >= @start_date AND `added_date` <= @end_date " + ((product_name != null) ? ("AND `product_name` = '" + product_name + "' ") : ("")) + ((quantity != 0) ? ("AND `Qty`=@Qty ") : ("")) + ((added_by != null) ? ("AND `added_by`='" + added_by + "' ") : ("") + ((customer_name != null) ? ("AND `dea_cust_name`='" + customer_name + "' ") : ("")));
                OleDbCommand cmd = new OleDbCommand(cmd_text, conn);
                cmd.Parameters.AddWithValue("@start_date", start_date.ToString());
                cmd.Parameters.AddWithValue("@end_date", end_date.ToString());
                //cmd.Parameters.AddWithValue("@product_name", product_name);
                cmd.Parameters.AddWithValue("@Qty", quantity);
                //cmd.Parameters.AddWithValue("@dea_cust_name", "Osho");
                //cmd.Parameters.AddWithValue("@added_by", added_by);
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                // Checking for the type
                //for(var i =0; i<=(dt.Rows.Count-1); i++)
                //{
                //    DataRow dr = dt.Rows[i];
                //    string trans_type = Get_type(dr[8].ToString());
                //    if (trans_type != type)
                //    {
                //        dr.Delete();
                //    }

                //}

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

        public OleDbDataAdapter GetTransaction(int id)
        {
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            conn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            string cmds = "SELECT * FROM Transactions WHERE ID = @id";
            OleDbCommand cmd = new OleDbCommand(cmds, conn);
            cmd.Parameters.AddWithValue("@id", id);
            adapter.SelectCommand = cmd;
            conn.Close();
            return adapter;

        }

        public OleDbDataAdapter Getdetails(int id)
        {
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            conn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            string cmds = "SELECT * FROM `Transaction Details` WHERE Invoice_id = @id";
            OleDbCommand cmd = new OleDbCommand(cmds, conn);
            cmd.Parameters.AddWithValue("@id", id);
            adapter.SelectCommand = cmd;
            conn.Close();
            return adapter;
        }


        

        #region Local server functions
        public bool Insert_2()
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            string cmdstring = "INSERT INTO [Transaction Details](product_name,rate,Qty,total,dea_cust_name,added_by,Invoice_id,Profit,Type,Server_id)VALUES(@product_name,@rate,@Qty,@total,@dea_cust_name,@added_by,@Invoice_id,@Profit,@Type,@Server_id)";


            try
            {
                SqlCommand cmd = new SqlCommand(cmdstring, conn);
                //cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@product_name", product_name);
                cmd.Parameters.AddWithValue("@rate", rate);
                cmd.Parameters.AddWithValue("@Qty", Qty);
                cmd.Parameters.AddWithValue("@total", total);
                cmd.Parameters.AddWithValue("@dea_cust_name", dea_cust_name);
                cmd.Parameters.AddWithValue("@added_by", added_by);
                cmd.Parameters.AddWithValue("@Invoice_id", Invoice_id);
                cmd.Parameters.AddWithValue("@Profit", Profit);
                cmd.Parameters.AddWithValue("@Type", Type);
                cmd.Parameters.AddWithValue("@Server_id", Server_id);
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
                MessageBox.Show(ex.Message + "TD");

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        public DataTable GetAllTransactionDetails_2(string Name, int transaction_id)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            string cmdstring = "SELECT product_name,rate,Qty,Total,dea_cust_name,added_date,added_by,Profit,Type FROM [Transaction Details] WHERE dea_cust_name = @dea_cust_name AND Invoice_id = @Invoice_id";
            try
            {
                SqlCommand cmd = new SqlCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@dea_cust_name", Name);
                cmd.Parameters.AddWithValue("Invoice_id", transaction_id);
                SqlDataAdapter adapter = new SqlDataAdapter() { SelectCommand = cmd };
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

        public DataTable QueryTransactions_2(DateTime start_date, DateTime end_date, string type, string product_name = null, string customer_name = null, decimal quantity = 0, string added_by = null)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                string cmd_text = "SELECT * FROM [Transaction Details] WHERE type = '" + type + "' AND added_date >= @start_date AND added_date <= @end_date " + ((product_name != null) ? ("AND product_name = '" + product_name + "' ") : ("")) + ((quantity != 0) ? ("AND Qty=@Qty ") : ("")) + ((added_by != null) ? ("AND added_by='" + added_by + "' ") : ("") + ((customer_name != null) ? ("AND dea_cust_name='" + customer_name + "' ") : ("")));
                SqlCommand cmd = new SqlCommand(cmd_text, conn);
                cmd.Parameters.AddWithValue("@start_date", start_date);
                cmd.Parameters.AddWithValue("@end_date", end_date);
                //cmd.Parameters.AddWithValue("@product_name", product_name);
                cmd.Parameters.AddWithValue("@Qty", quantity);
                //cmd.Parameters.AddWithValue("@dea_cust_name", "Osho");
                //cmd.Parameters.AddWithValue("@added_by", added_by);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                // Checking for the type
                //for(var i =0; i<=(dt.Rows.Count-1); i++)
                //{
                //    DataRow dr = dt.Rows[i];
                //    string trans_type = Get_type(dr[8].ToString());
                //    if (trans_type != type)
                //    {
                //        dr.Delete();
                //    }

                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " From Analysis");
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public SqlDataAdapter GetTransaction_2(int id)
        {
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string cmds = "SELECT * FROM Transactions WHERE ID = @id";
            SqlCommand cmd = new SqlCommand(cmds, conn);
            cmd.Parameters.AddWithValue("@id", id);
            adapter.SelectCommand = cmd;
            conn.Close();
            return adapter;

        }

        public SqlDataAdapter Getdetails_2(int id)
        {
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string cmds = "SELECT * FROM [Transaction Details] WHERE Invoice_id = @id";
            SqlCommand cmd = new SqlCommand(cmds, conn);
            cmd.Parameters.AddWithValue("@id", id);
            adapter.SelectCommand = cmd;
            conn.Close();
            return adapter;
        }

        #endregion

        #region Appropriates
        public async Task<bool> InsertAppropriately()
        {
            if (Env.mode == 1)
            {
                return Insert();

            } else if (Env.mode == 2)
            {
                return Insert_2();

            } else
            {
                bool result = await insert2();
                return Insert_2();
            }
        }

        public DataTable GetAllTransactionDetailsAppropriately(string Name, int transaction_id)
        {
            if (Env.mode == 1)
            {
                return GetAllTransactionDetails(Name , transaction_id);

            }
            else if (Env.mode == 2)
            {
                return GetAllTransactionDetails_2(Name , transaction_id);

            }
            else
            {
                return GetAllTransactionDetails_2(Name, transaction_id);
            }

        }

        public DataTable QueryTransactionsAppropriately(DateTime start_date, DateTime end_date, string type, string product_name = null, string customer_name = null, decimal quantity = 0, string added_by = null)
        {
            if (Env.mode == 1)
            {
                return QueryTransactions(start_date, end_date,type,product_name ,customer_name ,quantity ,added_by);

            }
            else if (Env.mode == 2)
            {
                return QueryTransactions_2(start_date, end_date, type, product_name, customer_name, quantity, added_by);

            }
            else
            {
                return QueryTransactions_2(start_date, end_date, type, product_name, customer_name, quantity, added_by);
            }

        }

        public dynamic GetTransactionAppropriately(int id)
        {
            if (Env.mode == 1)
            {
                return GetTransaction(id);

            } else if (Env.mode == 2)
            {
                return GetTransaction_2(id);

            } else
            {
                return GetTransaction_2(id);
            }
        }

        public dynamic GetdetailsAppropriately(int id)
        {
            if (Env.mode == 1)
            {
                return Getdetails(id);
            }
            else if (Env.mode == 2)
            {
                return Getdetails_2(id);
            }
            else
            {
                return Getdetails(id);
            }

        }

        #endregion



    }
}
