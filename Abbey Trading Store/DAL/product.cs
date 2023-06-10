
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL.DAL_Properties;
using Newtonsoft.Json;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System.Data.SqlClient;

namespace Abbey_Trading_Store.DAL
{
    class product
    {
        //Fields
        private int id;
        private string Product;
        private string category;
        private string description;
        private decimal rate;
        private decimal selling_price;
        private decimal wholesale_price = 0;
        private decimal quantity;
        private DateTime added_date;
        private string added_by;
        private int server_id = 0;

        ProductsProps productprop = new ProductsProps();

        // properties
        public int Id { get { return id; } set { 
                id = value; 
                productprop.Id = value;
            }
        }
        public string products { get { return Product; } set {
                Product = value;
                productprop.products = value;
            }
        }
        public string Category { get { return category; } set { 
                category = value;
                productprop.Category = value;
            }
        }
        public string Description { get { return description; } set { 
                description = value;
                productprop.Description = value;
            }
        }
        public decimal Rate { get { return rate; } set { 
                rate = value;
                productprop.Rate = value;
            }
        }
        public decimal Selling_price { get { return selling_price; } set { 
                selling_price = value;
                productprop.Selling_price = value;
            }
        }
        public decimal Wholesale_price { get { return wholesale_price; } set
            {
                wholesale_price = value;
                productprop.Wholesale_price = value;
            }
        }
        public decimal Quantity { get { return quantity; } set { 
                quantity = value;
                productprop.Quantity = value;
            }
        }
        public DateTime Added_date { get { return added_date; } set { 
                added_date = value;
                productprop.Added_date = value;
            }
        }
        public string Added_by { get { return added_by; } set { 
                added_by = value;
                productprop.Added_by = value;
            }
        }
        public int Server_id { get { return server_id; } set { 
                server_id = value; 
                productprop.Server_id = value;
            }
        }

        // Declaring the new HTTP client
        HttpClient client = new HttpClient();



        //Global uri
        string uri = Env.debug_enabled ? (Env.debug_url) : (Env.live_url);

        #region local functions Oledb
        public OleDbDataAdapter select (){
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            const string cmd = "SELECT * FROM Products";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd, conn);
            try
            {
                
                //conn.Open();
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
            return adapter;
        }
       
        public bool add()
        {
            bool checker = true ;
            OleDbConnection connector = new OleDbConnection(Env.local_database_conn_string);
            try
            {
                string command = "INSERT INTO Products(Product,Category,Description,Rate,Selling_price,Quantity,Added_by,Wholesale_price)values(@Product,@Category,@Description,@Rate,@Selling_price,@Quantity,@Added_by,@Wholesale_price)";
                OleDbCommand cmd = new OleDbCommand(command,connector);
                cmd.Parameters.AddWithValue("@Product",Product);
                cmd.Parameters.AddWithValue("@Category",category);
                cmd.Parameters.AddWithValue("@Description",description);
                cmd.Parameters.AddWithValue("@Rate",rate);
                cmd.Parameters.AddWithValue("@Selling_price", Selling_price);
                cmd.Parameters.AddWithValue("@Quantity",quantity);
                cmd.Parameters.AddWithValue("@Added_by",added_by);
                cmd.Parameters.AddWithValue("@Wholesale_price", Wholesale_price);
                connector.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    checker = true;
                }
                else
                {
                    checker = false;
                }
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            
            }
            finally{
                connector.Close();
            
            }

            return checker;
        }
        
        public bool update()
        {
            bool checker = true;
            OleDbConnection connector = new OleDbConnection(Env.local_database_conn_string);
            try
            {
                string command = "UPDATE Products SET Product = @Product , Category = @Category , Description = @Description , Rate = @Rate, Selling_price = @Selling_price, Added_by = @Added_by, Wholesale_price = @Wholesale_price WHERE id = @id ";
                OleDbCommand cmd = new OleDbCommand(command, connector);
                cmd.Parameters.AddWithValue("@Product", Product);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Rate", rate);
                cmd.Parameters.AddWithValue("@Selling_price", Selling_price);
                cmd.Parameters.AddWithValue("@Added_by", added_by);
                cmd.Parameters.AddWithValue("@Wholesale_price", Wholesale_price);
                cmd.Parameters.AddWithValue("@id", id);
                connector.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    checker = true;
                }
                else
                {
                    checker = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                connector.Close();

            }

            return checker;

        }
    
        public DataTable search(string keywords)
        {
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            string cmd = "SELECT * FROM Products WHERE id LIKE '%"+keywords+"%' OR Product LIKE '%"+keywords+"%' OR Category LIKE '%"+keywords+"%' OR Added_by LIKE '%"+keywords+"%'";
            try
            {

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd, conn);
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
         
        public bool delete()
        {
            bool checker = true;
            OleDbConnection connector = new OleDbConnection(Env.local_database_conn_string);
            try
            {
                string command = "DELETE * FROM Products WHERE id = @id ";
                OleDbCommand cmd = new OleDbCommand(command, connector);
                cmd.Parameters.AddWithValue("@id", id);
                connector.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    checker = true;
                }
                else
                {
                    checker = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                connector.Close();

            }

            return checker;

        }
        
      //Search for product in transaction module
        public DataTable Search(string keywords)
        {
            string[] results = new string[5];
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            string cmdstring = "SELECT Product , Rate , Selling_price , Quantity , Wholesale_price FROM Products WHERE id LIKE '%" + keywords + "%' OR Product LIKE '%" + keywords + "%' ";
            DataTable dt = new DataTable();
            try
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmdstring,conn);
                conn.Open();
                adapter.Fill(dt);
                //if (dt.Rows.Count > 0)
                //{
                //    // Filling in the values into the array
                //    results[0] = dt.Rows[0]["Product"].ToString();
                //    results[1] = dt.Rows[0]["Selling_Price"].ToString();
                //    results[2] = dt.Rows[0]["Quantity"].ToString();
                //    results[3] = dt.Rows[0]["Rate"].ToString();
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
       
        public decimal GetProduct(string productName)
        {
            decimal qty = 0;
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            DataTable dt = new DataTable();
            try
            {
                string cmds = "SELECT Quantity FROM Products WHERE Product = @Product";
                OleDbCommand cmd = new OleDbCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@Product", productName);
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = cmd;
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    qty = decimal.Parse(dt.Rows[0][0].ToString());
                }
                else
                {
                    MessageBox.Show("Quantity not found");
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

            return qty;
        }
       
        public async Task<bool> QuantityUpdate(decimal quantity ,string productName )
        {
            bool success = false;
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            try
            {
                string cmds = "UPDATE Products SET Quantity = @Quantity WHERE Product = @product";
                OleDbCommand cmd = new OleDbCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@product", productName);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (Env.mode == 3)
                {
                    var server_side = await quantityupdate2(quantity, productName);
                }
                if (rows > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
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
            return success;
        }
       
       
        public async Task<bool> IncreaseProduct(decimal quantity, string Product_name)
        {
            bool success = false;
            try
            {
                //Getting the product from database
                decimal Qty = GetProductAppropriately(Product_name);

                //Calculations
                decimal result = Qty + quantity;

                //Updating the quantity in the database
                bool check = await QuantityUpdateAppropriately(result, Product_name);

                // verification
                if (check == true)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return success;
        }
        

        public async Task<bool> DecreaseProduct(decimal quantity, string Product_name)
        {
            bool success = false;
            try
            {
                //Getting the product from database
                decimal Qty = GetProductAppropriately(Product_name);

                //Calculations
                decimal result = Qty - quantity;

                //Updating the quantity in the database
                bool check = await QuantityUpdateAppropriately(result, Product_name);

                // verification
                if (check == true)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Error at Decrease product");
            }
            finally
            {

            }
            return success;

        }

        public OleDbDataAdapter DisplayProductsBasedOnCategory(string Name)
        {
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            string cmds = "SELECT * FROM Products WHERE Category = @Category ";
            OleDbCommand cmd = new OleDbCommand(cmds, conn);
            cmd.Parameters.AddWithValue("@Category", Name);
            OleDbDataAdapter adapter = new OleDbDataAdapter() { SelectCommand = cmd };
            try
            {
                
                //conn.Open();
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
            return adapter;
        }

        public DataTable ReadExcel(string filename, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            //dtexcel.Columns.Add("Product");
            //dtexcel.Columns.Add("Category");
            //dtexcel.Columns.Add("Description");
            //dtexcel.Columns.Add("Rate");
            //dtexcel.Columns.Add("Selling Rate");
            //dtexcel.Columns.Add("Quantity");
            //dtexcel.Columns.Add("Added_date");
            //dtexcel.Columns.Add("Added_by");

            if (fileExt.CompareTo(".xls")==0){
                conn = "provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';";
            } 
            else {
                conn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Extended Properties='Excel 12.0;HDR=No';";
            }
            using(OleDbConnection con = new OleDbConnection(conn)){
                try {
                    OleDbDataAdapter oledpt = new OleDbDataAdapter("select * from [Sheet1$]" , conn);
                    oledpt.Fill(dtexcel);
                } catch(Exception ex){
                    MessageBox.Show(ex.Message);
                }
            }
            return dtexcel;
        }

        public async Task<bool> Batchupload(List<ProductsProps>products)
        {
            //Posting to online server
            string derived_uri = uri + "/BatchUpload/";
            var stringPayload = JsonConvert.SerializeObject(products);

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

        public DataTable MostSellingProducts()
        {
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
            const string cmd = "SELECT product_name , COUNT(product_name) AS value_occurrence , SUM(CAST(Qty as int)) AS Total_quantity FROM `Transaction Details` GROUP BY product_name ORDER BY value_occurrence DESC";
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

        #region Api Requests
        public async Task<bool> insert2()
        {
            //Posting to online server
            string derived_uri = uri + "/createproduct/";
            var stringPayload = JsonConvert.SerializeObject(productprop);

            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(derived_uri, httpContent);

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

        public async Task<bool> update2()
        {
            string derived_uri = uri + "/updateProduct/";
            //Serialize object
            var Stringpayload = JsonConvert.SerializeObject(productprop);
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

        public async Task<bool> delete2()
        {
            string derived_uri = uri + "/deleteproduct/" + Id + "/";
            //Serialize object
            var Stringpayload = JsonConvert.SerializeObject(productprop);
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

        public async Task<bool> quantityupdate2(decimal quantity, string productName)
        {
            //Posting to online server
            string derived_uri = uri + "/updateQuantity/" + productName + "/" + quantity + "/";
            var stringPayload = JsonConvert.SerializeObject(productprop);

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

        #region Server functions

        public DataTable MostSellingProducts_2()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            const string cmd = "SELECT product_name , COUNT(product_name) AS value_occurrence , SUM(CAST(Qty as int)) AS Total_quantity FROM [Transaction Details] WHERE Type = 'Sales' GROUP BY product_name ORDER BY value_occurrence DESC;";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd, conn);
            try
            {

                conn.Open();
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Most selling product");
            }
            finally
            {
                conn.Close();
            }
            return dt;

        }

        public SqlDataAdapter select_2()
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            const string cmd = "SELECT * FROM Products";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd, conn);
            try
            {

                //conn.Open();
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
            return adapter;
        }

        public bool add_2()
        {
            bool checker = true;
            SqlConnection connector = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                string command = "INSERT INTO Products(Product,Category,Description,Rate,Selling_price,Wholesale_price,Quantity,Added_by,Server_id)values(@Product,@Category,@Description,@Rate,@Selling_price,@Wholesale_price,@Quantity,@Added_by,@Server_id)";
                SqlCommand cmd = new SqlCommand(command, connector);
                cmd.Parameters.AddWithValue("@Product", Product);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Rate", rate);
                cmd.Parameters.AddWithValue("@Selling_price", Selling_price);
                cmd.Parameters.AddWithValue("@Wholesale_price", Wholesale_price);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@Added_by", added_by);
                cmd.Parameters.AddWithValue("@Server_id", server_id);
                
                connector.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    checker = true;
                }
                else
                {
                    checker = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                connector.Close();

            }

            return checker;
        }

        public bool update_2()
        {
            bool checker = true;
            SqlConnection connector = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                string command = "UPDATE Products SET Product = @Product , Category = @Category , Description = @Description , Rate = @Rate, Selling_price = @Selling_price, Wholesale_price = @Wholesale_price , Added_by = @Added_by WHERE id = @id ";
                SqlCommand cmd = new SqlCommand(command, connector);
                cmd.Parameters.AddWithValue("@Product", Product);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Rate", rate);
                cmd.Parameters.AddWithValue("@Selling_price", Selling_price);
                cmd.Parameters.AddWithValue("@Wholesale_price", Wholesale_price);
                cmd.Parameters.AddWithValue("@Added_by", added_by);
                cmd.Parameters.AddWithValue("@id", id);
                connector.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    checker = true;
                }
                else
                {
                    checker = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                connector.Close();

            }

            return checker;

        }

        public bool delete_2()
        {
            bool checker = true;
            SqlConnection connector = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                string command = "DELETE * FROM Products WHERE id = @id ";
                SqlCommand cmd = new SqlCommand(command, connector);
                cmd.Parameters.AddWithValue("@id", id);
                connector.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    checker = true;
                }
                else
                {
                    checker = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                connector.Close();

            }

            return checker;

        }

        public DataTable Search_2(string keywords)
        {
            string[] results = new string[4];
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            string cmdstring = "SELECT * FROM Products WHERE id LIKE '%" + keywords + "%' OR Product LIKE '%" + keywords + "%' ";
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmdstring, conn);
                conn.Open();
                adapter.Fill(dt);
                //if (dt.Rows.Count > 0)
                //{
                //    // Filling in the values into the array
                //    results[0] = dt.Rows[0]["Product"].ToString();
                //    results[1] = dt.Rows[0]["Selling_Price"].ToString();
                //    results[2] = dt.Rows[0]["Quantity"].ToString();
                //    results[3] = dt.Rows[0]["Rate"].ToString();
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

        public DataTable search_2(string keywords)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            string cmd = "SELECT * FROM Products WHERE id LIKE '%" + keywords + "%' OR Product LIKE '%" + keywords + "%' OR Category LIKE '%" + keywords + "%' OR Added_by LIKE '%" + keywords + "%'";
            try
            {

                SqlDataAdapter adapter = new SqlDataAdapter(cmd, conn);
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

        public decimal GetProduct_2(string productName)
        {
            decimal qty = 0;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            DataTable dt = new DataTable();
            try
            {
                string cmds = "SELECT Quantity FROM Products WHERE Product = @Product";
                SqlCommand cmd = new SqlCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@Product", productName);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    qty = decimal.Parse(dt.Rows[0][0].ToString());
                }
                else
                {
                    MessageBox.Show("Quantity not found");
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

            return qty;
        }

        public async Task<bool> QuantityUpdate_2(decimal quantity, string productName)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            try
            {
                string cmds = "UPDATE Products SET Quantity = @Quantity WHERE Product = @product";
                SqlCommand cmd = new SqlCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@product", productName);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (Env.mode == 3)
                {
                    var server_side = await quantityupdate2(quantity, productName);
                }
                if (rows > 0)
                {
                    success = true;
                }
                else
                {
                    success = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Error at updating.");

            }
            finally
            {
                conn.Close();

            }
            return success;
        }

        public SqlDataAdapter DisplayProductsBasedOnCategory_2(string Name)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
            string cmds = "SELECT * FROM Products WHERE Category = @Category ";
            SqlCommand cmd = new SqlCommand(cmds, conn);
            cmd.Parameters.AddWithValue("@Category", Name);
            SqlDataAdapter adapter = new SqlDataAdapter() { SelectCommand = cmd };
            try
            {

                //conn.Open();
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
            return adapter;
        }

        #endregion

        #region Appropriates
        public DataTable MostSellingProductsAppropriatetly()
        {
            if (Env.mode == 1)
            {
                DataTable dt = MostSellingProducts();
                return dt;

            }
            else if (Env.mode == 2)
            {
                DataTable dt = MostSellingProducts_2();
                return dt;

            }
            else
            {
                DataTable dt = MostSellingProducts_2();
                return dt;

            }

        }

        public dynamic SelectAppropriately()
        {
            if (Env.mode == 1)
            {
                return select();
            }
            else if (Env.mode == 2)
            {
                return select_2();
            }
            else
            {
                return select_2();
            }
        }

        public DataTable searchAppropriately(string keywords)
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

        public DataTable SearchAppropriately(string keywords)
        {
            if (Env.mode == 1)
            {
                return Search(keywords);
            }
            else if (Env.mode == 2)
            {
                return Search_2(keywords);
            }
            else
            {
                return Search_2(keywords);
            }
        }

        public decimal GetProductAppropriately(string product_name)
        {
            if (Env.mode == 1)
            {
                return GetProduct(product_name);
            }
            else if (Env.mode == 2)
            {
                return GetProduct_2(product_name);
            }
            else
            {
                return GetProduct_2(product_name);
            }
        }

        public async Task<bool> AddAppropriately()
        {
            if (Env.mode == 1)
            {
                return add();

            }else if (Env.mode == 2)
            {
                return add_2();

            } else
            {
                var result = await insert2();
                return result;
            }
        }

        public async Task<bool> UpdateAppropriately()
        {
            if (Env.mode == 1)
            {
                return update();
            }
            else if (Env.mode == 2)
            {
                return update_2();
            }
            else
            {
                return (update_2() && await update2());
            }
        }

        public async Task<bool> DeleteAppropriately()
        {
            if (Env.mode == 1)
            {
                return delete();
            }
            else if (Env.mode == 2)
            {
                return delete_2();
            }
            else
            {
                return (delete_2() && await delete2());
            }
        }

        public async Task<bool> QuantityUpdateAppropriately(decimal quantity , string productName)
        {
            if (Env.mode == 1)
            {
                return await QuantityUpdate(quantity , productName);
            }
            else if (Env.mode == 2)
            {
                return await QuantityUpdate_2(quantity, productName);
            }
            else
            {
                return await QuantityUpdate_2(quantity, productName);
            }
        }


        public dynamic DisplayProductsBasedOnCategoryAppropriately(string Name)
        {
            if (Env.mode == 1)
            {
                return DisplayProductsBasedOnCategory(Name);
            }
            else if (Env.mode == 2)
            {
                return DisplayProductsBasedOnCategory_2(Name);
            }
            else
            {
                return DisplayProductsBasedOnCategory_2(Name);
            }
        }


        #endregion Appropriates


    }
}