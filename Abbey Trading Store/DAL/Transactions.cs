using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Data;
using System.Data.OleDb;
using System.Net.Http.Headers;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Abbey_Trading_Store.DAL.DAL_Properties;
using System.Runtime.CompilerServices;
using System.Data.SqlClient;
using System.Transactions;

namespace Abbey_Trading_Store.DAL
{
    class Transactions
    {
        // Fields
        private int ID;
        private string type;
        private string dea_cust_name;
        private int grandTotal;
        private DateTime transaction_date;
        private int discount;
        private string added_by;
        private int return_amount;
        private int paid_amount;
        private int total_profit;
        private string paid;
        private string taken;
        private int server_id = 0;

        // Instantiating a new object of TransactionsProps
        TransactionsProps newtransaction = new TransactionsProps();


        // properties
        public int id { get { return ID; } set { 
                ID = value;
                newtransaction.id = value;
            }
        }
        public string Type { get { return type; } set { 
                type = value;
                newtransaction.Type = value;
            }
        }
        public string Dea_Cust_name { get { return dea_cust_name; } set { 
                dea_cust_name = value;
                newtransaction.Dea_Cust_name = value;
            }
        }
        public int GrandTotal { get { return grandTotal; } set { 
                grandTotal = value;
                newtransaction.GrandTotal = value;
            }
        }
        public DateTime Transaction_date { get { return transaction_date; } set { 
                transaction_date = value;
                newtransaction.Transaction_date = value;
            }
        }
        public int Discount { get { return discount; } set { 
                discount = value;
                newtransaction.Discount = value;
            }
        }
        public string Added_by { get { return added_by; } set { 
                added_by = value;
                newtransaction.Added_by = value;
            }
        }
        public int Return_amount { get { return return_amount; } set { 
                return_amount = value;
                newtransaction.Return_amount = value;
            }
        }
        public int Paid_amount { get { return paid_amount; } set { 
                paid_amount = value; 
                newtransaction.Paid_amount = value;
            }
        }
        public int Total_Profit { get { return total_profit; } set { 
                total_profit = value;
                newtransaction.Total_Profit = value;
            }
        }
        public string Paid { get { return paid; } set { 
                paid = value;
                newtransaction.Paid = value;
            }
        }
        public string Taken { get { return taken; } set { 
                taken = value;
                newtransaction.Taken = value;
            }
        }
        public int Server_id { get { return server_id; } set { 
                server_id = value;
                newtransaction.Server_id = value;
            }
        }

        // Declaring the new HTTP client
        HttpClient client = new HttpClient();



        //Global uri
        string uri = Env.debug_enabled ? (Env.debug_url) : (Env.live_url);



        #region local functions
        public int Insert()
        {
            //TransactionID = -1;
            int transID = 0;
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            string cmdstring = "INSERT INTO `Transactions`(`type`,`dea_cust_name`,`grandTotal`,`discount`,`added_by`,`Paid_amount`,`Return_amount`,`Total_Profit`,`Paid`,`Taken`)VALUES(@type,@dea_cust_name,@grandTotal,@discount,@added_by,@Paid_amount,@Return_amount,@Total_Profit,@Paid,@Taken)";
            string cmdstring2 = "SELECT @@Identity";
            try
            {
                OleDbCommand cmd = new OleDbCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@dea_cust_name", dea_cust_name);
                cmd.Parameters.AddWithValue("@grandTotal", grandTotal);
                cmd.Parameters.AddWithValue("@discount", discount);
                cmd.Parameters.AddWithValue("@added_by", added_by);
                cmd.Parameters.AddWithValue("@Paid_amount", paid_amount);
                cmd.Parameters.AddWithValue("@Return_amount", return_amount);
                cmd.Parameters.AddWithValue("@Total_Profit", total_profit);
                cmd.Parameters.AddWithValue("@Paid", paid);
                cmd.Parameters.AddWithValue("@Taken", taken);
                conn.Open();
                // Inserting the data into the database
                cmd.ExecuteNonQuery();
                //returning an id of the input data
                cmd.CommandText = cmdstring2;
                transID = (int)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Transaction");

            }
            finally
            {
                conn.Close();
            }
            return transID;
        }
        public OleDbDataAdapter DisplayAllTransactions()
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            try
            {
                string cmds = "SELECT * FROM Transactions ORDER BY transaction_date desc";
                adapter = new OleDbDataAdapter(cmds, conn);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }

            return adapter;
        }
        public bool UpdatePayment(int TransactionId, int amount, int paid_amount, bool cleared)
        {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            try
            {

                string cmds = "UPDATE Transactions SET Return_amount = @Return_amount , Paid_amount = @Paid_amount , Paid = @Paid WHERE id = @id";
                OleDbCommand cmd = new OleDbCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@Return_amount", amount);
                cmd.Parameters.AddWithValue("@Paid_amount", paid_amount);
                if (cleared)
                {
                    cmd.Parameters.AddWithValue("@Paid", "Cleared");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Paid", "False");
                }

                cmd.Parameters.AddWithValue("@id", TransactionId);
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
        public DataTable SearchCreditorsDebtors(string type, string keywords)
        {
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            try
            {
                string cmds = "SELECT * FROM Transactions WHERE ID LIKE '%" + keywords + "%' OR dea_cust_name LIKE '%" + keywords + "%' OR added_by LIKE '%" + keywords + "%' AND type = @type AND NOT Paid = @Paid OR Return_amount < 0 ";
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                OleDbCommand cmd = new OleDbCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@Paid", "True");
                adapter.SelectCommand = cmd;
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
        public bool InsertTransactionTrack(string[] args)
        {
            bool isSuccess = false;
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            try
            {
                string cmds = "INSERT INTO `Transaction Tracker`(`Transaction_id`,`Paid_amount`,`Added_date`,`Updated_by`)VALUES(@Transaction_id,@Paid_amount,@Added_date,@Updated_by)";
                OleDbCommand cmd = new OleDbCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@Transaction_id", args[0]);
                cmd.Parameters.AddWithValue("@Paid_amount", args[1]);
                cmd.Parameters.AddWithValue("@Added_date", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@Updated_by", args[2]);
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
        public OleDbDataAdapter GetAllDebtsCredits(string type)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            try
            {
                string cmds = "SELECT * FROM Transactions WHERE (type = @type AND NOT Paid = @Paid) OR Return_amount < 0";
                OleDbCommand cmd = new OleDbCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@Paid", "True");
                adapter.SelectCommand = cmd;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return adapter;
        }
        public OleDbDataAdapter GetAllTrackData(int id)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            try
            {
                string cmds = "SELECT * FROM `Transaction Tracker` WHERE Transaction_id = @id";
                OleDbCommand cmd = new OleDbCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@id", id);
                adapter.SelectCommand = cmd;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return adapter;
        }

        public static bool DeleteTransaction(int id)
        {
            bool success = true;
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            try
            {
                conn.Open();
                string cmd_text = "DELETE * FROM Transactions WHERE ID = @ID";
                OleDbCommand cmd = new OleDbCommand(cmd_text, conn);
                cmd.Parameters.AddWithValue("@ID", id);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    DataTable dt = new DataTable();
                    string cmd_text2 = "SELECT * FROM `Transaction Details` WHERE Invoice_id = @Invoice_id";
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    // Deleting the transaction details and updating the products
                    OleDbCommand cmd2 = new OleDbCommand(cmd_text2, conn);
                    cmd2.Parameters.AddWithValue("@Invoice_id", id);
                    adapter.SelectCommand = cmd2;
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach(DataRow dr in dt.Rows)
                        {
                            if (success == false)
                            {
                                return false;
                            }
                            string cmd_text3 = "UPDATE Products SET Quantity = Quantity + @Quantity WHERE Product = @Product";
                            OleDbCommand cmd3 = new OleDbCommand(cmd_text3, conn);
                            cmd3.Parameters.AddWithValue("@Quantity", Convert.ToInt32(dr[3]));
                            cmd3.Parameters.AddWithValue("@Product", dr[1].ToString());
                            int rows_affected = cmd3.ExecuteNonQuery();
                            if (rows_affected > 0)
                            {
                                string cmd_text4 = "DELETE * FROM `Transaction Details` WHERE ID = @ID";
                                OleDbCommand cmd4 = new OleDbCommand(cmd_text4, conn);
                                cmd4.Parameters.AddWithValue("@ID", Convert.ToInt32(dr[0]));
                                int rows_deleted = cmd4.ExecuteNonQuery();
                                if (rows_deleted <= 0)
                                {
                                    MessageBox.Show("Encoutered a problem with deleting the transaction details");
                                    success = false;
                                }
                            }


                        }
                    }else
                    {
                        MessageBox.Show("No transaction details exist for this transaction");
                    }
                    

                }
                else
                {
                    MessageBox.Show("Transaction doesnot exist");
                    return false;
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();

            }


            return success;
        }
        #endregion


        #region Api requests

        public async Task<bool> insert2()
        {
            //Posting to online server
            string derived_uri = uri + "/createTransaction/";
            var stringPayload = JsonConvert.SerializeObject(newtransaction);

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
    
        public async Task<bool> UpdatePayment2(int TransactionId, int amount, int paid_amount, bool cleared)
        {
            //Posting to online server
            string derived_uri = uri + "/updatetransaction/" + TransactionId + "/" + amount + "/" + paid_amount + "/" + cleared + "/";
            var stringPayload = JsonConvert.SerializeObject(newtransaction);

            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.GetAsync(derived_uri);

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

        public async Task<bool> InsertTransactionTrack2(string[] args)
        {
            //Posting to online server
            string derived_uri = uri + "/createtrack/" + args[0] + "/" + args[1] + "/" + args[2] + "/";
            var stringPayload = JsonConvert.SerializeObject(newtransaction);

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

        #endregion


        #region Local server functions 

        public int Insert_2()
        {
            //TransactionID = -1;
            int transID = 0;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            string cmdstring = "INSERT INTO Transactions(type,dea_cust_name,grandTotal,discount,added_by,Paid_amount,Return_amount,Total_Profit,Paid,Taken) VALUES(@type,@dea_cust_name,@grandTotal,@discount,@added_by,@Paid_amount,@Return_amount,@Total_Profit,@Paid,@Taken); SELECT @MyPK = SCOPE_IDENTITY()";
            //string cmdstring2 = "SELECT IDENT_CURRENT('Transactions')";
            //string cmdstring2 = "SELECT @MyPK = @@SCOPE_IDENTITY";
            try
            {
                SqlCommand cmd = new SqlCommand(cmdstring, conn);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@dea_cust_name", dea_cust_name);
                cmd.Parameters.AddWithValue("@grandTotal", grandTotal);
                cmd.Parameters.AddWithValue("@discount", discount);
                cmd.Parameters.AddWithValue("@added_by", added_by);
                cmd.Parameters.AddWithValue("@Paid_amount", paid_amount);
                cmd.Parameters.AddWithValue("@Return_amount", return_amount);
                cmd.Parameters.AddWithValue("@Total_Profit", total_profit);
                cmd.Parameters.AddWithValue("@Paid", paid);
                cmd.Parameters.AddWithValue("@Taken", taken);
                cmd.Parameters.Add("@MyPK", SqlDbType.Int);
                cmd.Parameters["@MyPK"].Direction = ParameterDirection.Output;
                conn.Open();
                // Inserting the data into the database
                cmd.ExecuteNonQuery();
                //returning an id of the input data
                transID = (int)cmd.Parameters["@MyPK"].Value;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Transaction");

            }
            finally
            {
                conn.Close();
            }
            return transID;
        }

        public SqlDataAdapter DisplayAllTransactions_2()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                string cmds = "SELECT * FROM Transactions ORDER BY transaction_date desc";
                adapter = new SqlDataAdapter(cmds, conn);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }

            return adapter;
        }

        public DataTable DisplayTransactionsBasedOnType_2(string type)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                string cmds = "SELECT * FROM Transactions WHERE type = @type ORDER BY transaction_date desc";
                SqlCommand cmd = new SqlCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@type", type);
                SqlDataAdapter adapter = new SqlDataAdapter();
                conn.Open();
                adapter.SelectCommand = cmd;
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

        public bool UpdatePayment_2(int TransactionId, int amount, int paid_amount, bool cleared)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {

                string cmds = "UPDATE Transactions SET Return_amount = @Return_amount , Paid_amount = @Paid_amount , Paid = @Paid WHERE id = @id";
                SqlCommand cmd = new SqlCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@Return_amount", amount);
                cmd.Parameters.AddWithValue("@Paid_amount", paid_amount);
                if (cleared)
                {
                    cmd.Parameters.AddWithValue("@Paid", "Cleared");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Paid", "False");
                }

                cmd.Parameters.AddWithValue("@id", TransactionId);
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

        public DataTable SearchCreditorsDebtors_2(string keywords)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                string cmds = "SELECT * FROM Transactions WHERE dea_cust_name LIKE '%" + keywords + "%' AND type = 'Customer' AND (Paid = 'False' OR Paid = 'Cleared') ";
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand(cmds, conn);
                //cmd.Parameters.AddWithValue("@type", type);
                //cmd.Parameters.AddWithValue("@Paid", "True");
                adapter.SelectCommand = cmd;
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

        public bool InsertTransactionTrack_2(string[] args)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                string cmds = "INSERT INTO [Transaction_Tracker](Transaction_id,Paid_amount,Added_date,Updated_by)VALUES(@Transaction_id,@Paid_amount,@Added_date,@Updated_by)";
                SqlCommand cmd = new SqlCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@Transaction_id", args[0]);
                cmd.Parameters.AddWithValue("@Paid_amount", args[1]);
                cmd.Parameters.AddWithValue("@Added_date", DateTime.Now);
                cmd.Parameters.AddWithValue("@Updated_by", args[2]);
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

        public SqlDataAdapter GetAllDebtsCredits_2(string type)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                string cmds = "SELECT * FROM Transactions WHERE (type = @type AND NOT Paid = @Paid) OR Return_amount < 0 ORDER BY transaction_date desc";
                SqlCommand cmd = new SqlCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@Paid", "True");
                adapter.SelectCommand = cmd;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return adapter;
        }

        public SqlDataAdapter GetAllTrackData_2(int id)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                string cmds = "SELECT * FROM Transaction_Tracker WHERE Transaction_id = @id";
                SqlCommand cmd = new SqlCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@id", id);
                adapter.SelectCommand = cmd;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return adapter;
        }


        public static bool DeleteTransaction_2(int id)
        {
            bool success = true;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                conn.Open();
                string cmd_text = "DELETE FROM Transactions WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(cmd_text, conn);
                cmd.Parameters.AddWithValue("@ID", id);
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    DataTable dt = new DataTable();
                    string cmd_text2 = "SELECT * FROM [Transaction_Detail] WHERE Invoice_id = @Invoice_id";
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    // Deleting the transaction details and updating the products
                    SqlCommand cmd2 = new SqlCommand(cmd_text2, conn);
                    cmd2.Parameters.AddWithValue("@Invoice_id", id);
                    adapter.SelectCommand = cmd2;
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (success == false)
                            {
                                return false;
                            }


                            string cmd_text3 = "";
                            if (dr[10].ToString() == "Sales")
                            {
                                cmd_text3 = "UPDATE Products SET Quantity = Quantity + @Quantity WHERE Product = @Product";
                            }else
                            {
                                cmd_text3 = "UPDATE Products SET Quantity = Quantity - @Quantity WHERE Product = @Product";
                            }

                            SqlCommand cmd3 = new SqlCommand(cmd_text3, conn);
                            cmd3.Parameters.AddWithValue("@Quantity", Convert.ToDecimal(dr[3]));
                            cmd3.Parameters.AddWithValue("@Product", dr[1].ToString());
                           
                            int rows_affected = cmd3.ExecuteNonQuery();
                            if (rows_affected > 0)
                            {
                                string cmd_text4 = "DELETE FROM [Transaction_Detail] WHERE ID = @ID";
                                SqlCommand cmd4 = new SqlCommand(cmd_text4, conn);
                                cmd4.Parameters.AddWithValue("@ID", Convert.ToInt32(dr[0]));
                                int rows_deleted = cmd4.ExecuteNonQuery();
                                if (rows_deleted <= 0)
                                {
                                    MessageBox.Show("Encoutered a problem with deleting the transaction details");
                                    success = false;
                                }
                            }


                        }
                    }
                    else
                    {
                        MessageBox.Show("No transaction details exist for this transaction");
                    }


                }
                else
                {
                    MessageBox.Show("Transaction doesnot exist");
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                success = true;

            }
            finally
            {
                conn.Close();

            }


            return success;
        }


        public SqlDataAdapter GetDebtorsOnly(string name = "")
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);

            try
            {
                conn.Open();
                string cmd_string = "SELECT * FROM Transactions WHERE type = 'Customer' AND Paid = 'False' ORDER BY transaction_date desc";
                if (name == "")
                {
                    cmd_string = "SELECT * FROM Transactions WHERE type = 'Customer' AND Paid = 'False' ORDER BY transaction_date desc";
                }
                else
                {
                    cmd_string = "SELECT * FROM Transactions WHERE type = 'Customer' AND Paid = 'False' AND dea_cust_name LIKE '%" + name + "%' ORDER BY transaction_date desc";

                }
                adapter = new SqlDataAdapter(cmd_string, conn);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return adapter;
        }





        #endregion

        #region Appropriates

        public async Task<int> InsertAppropriately()
        {
            if (Env.mode == 1)
            {
                return Insert();

            } else if (Env.mode == 2)
            {
                return Insert_2();
            } else
            {
                await insert2();
                return Insert_2();
            }

        }
        public dynamic DisplayAllTransactionsAppropriately()
        {
            if (Env.mode == 1)
            {
                return DisplayAllTransactions();

            }
            else if (Env.mode == 2)
            {
                return DisplayAllTransactions_2();
            }
            else
            {
                return DisplayAllTransactions_2();
            }

        }
        public async Task<bool> UpdatePaymentAppropriately(int TransactionId, int amount, int paid_amount, bool cleared)
        {
            if (Env.mode == 1)
            {
                return UpdatePayment(TransactionId,  amount, paid_amount,  cleared);

            }
            else if (Env.mode == 2)
            {
                return UpdatePayment_2(TransactionId, amount, paid_amount, cleared);
            }
            else
            {
                await UpdatePayment2(TransactionId, amount, paid_amount, cleared);
                return UpdatePayment_2(TransactionId, amount, paid_amount, cleared);
            }

        }
        public DataTable SearchCreditorsDebtorsAppropriately(string keywords)
        {
            if (Env.mode == 1)
            {
                return SearchCreditorsDebtors("type" , keywords);

            }
            else if (Env.mode == 2)
            {
                return SearchCreditorsDebtors_2(keywords);
            }
            else
            {
                return SearchCreditorsDebtors_2(keywords);
            }

        }
        public async Task<bool> InsertTransactionTrackAppropriately(string[] args)
        {
            if (Env.mode == 1)
            {
                return InsertTransactionTrack(args);

            }
            else if (Env.mode == 2)
            {
                return InsertTransactionTrack_2(args);
            }
            else
            {
                bool result = await InsertTransactionTrack2(args);
                return InsertTransactionTrack_2(args);
            }
        }
        public dynamic GetAllDebtsCreditsAppropriately(string type)
        {
            if (Env.mode == 1)
            {
                return GetAllDebtsCredits(type);

            }
            else if (Env.mode == 2)
            {
                return GetAllDebtsCredits_2(type);
            }
            else
            {
                return GetAllDebtsCredits_2(type);
            }
        }
        public dynamic GetAllTrackDataAppropriately(int id)
        {
            if (Env.mode == 1)
            {
                return GetAllTrackData(id);

            }
            else if (Env.mode == 2)
            {
                return GetAllTrackData_2(id);
            }
            else
            {
                return GetAllTrackData_2(id);
            }
        }


        #endregion

    }
}
