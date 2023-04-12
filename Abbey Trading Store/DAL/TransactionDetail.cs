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

        // Declaring the new HTTP client
        HttpClient client = new HttpClient();

        //Global uri
        string uri = Env.debug_enabled ? (Env.debug_url) : (Env.live_url);

        #region Insert Transaction Details
        public bool Insert()
        {
            bool isSuccess = false;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
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
#endregion

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
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Getting transaction Details
       

        #region Returning all transaction details
        public DataTable GetAllTransactionDetails(string Name , int transaction_id)
        {
            DataTable dt = new DataTable();
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
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
        #endregion
        #endregion
        public DataTable QueryTransactions(DateTime start_date, DateTime end_date, string type, string product_name = null, string customer_name = null, int quantity = 0, string added_by = null)
        {
            DataTable dt = new DataTable();
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
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





    }
}
