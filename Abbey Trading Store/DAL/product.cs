
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
        private decimal quantity;
        private DateTime added_date;
        private string added_by;

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

        // Declaring the new HTTP client
        HttpClient client = new HttpClient();



        //Global uri
        string uri = Env.debug_enabled ? (Env.debug_url) : (Env.live_url);
        

        #region SELECT
        public OleDbDataAdapter select (){
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(connection);
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
        #endregion

        #region ADD
        public bool add()
        {
            bool checker = true ;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection connector = new OleDbConnection(connection);
            try
            {
                string command = "INSERT INTO Products(Product,Category,Description,Rate,Selling_price,Quantity,Added_by)values(@Product,@Category,@Description,@Rate,@Selling_price,@Quantity,@Added_by)";
                OleDbCommand cmd = new OleDbCommand(command,connector);
                cmd.Parameters.AddWithValue("@Product",Product);
                cmd.Parameters.AddWithValue("@Category",category);
                cmd.Parameters.AddWithValue("@Description",description);
                cmd.Parameters.AddWithValue("@Rate",rate);
                cmd.Parameters.AddWithValue("@Selling_price", Selling_price);
                cmd.Parameters.AddWithValue("@Quantity",quantity);
                cmd.Parameters.AddWithValue("@Added_by",added_by);
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
        #endregion

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
                return true;
            }
            else
            {
                return false;
            }
        }

        #region UPDATE
        public bool update()
        {
            bool checker = true;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection connector = new OleDbConnection(connection);
            try
            {
                string command = "UPDATE Products SET Product = @Product , Category = @Category , Description = @Description , Rate = @Rate, Selling_price = @Selling_price, Added_by = @Added_by WHERE id = @id ";
                OleDbCommand cmd = new OleDbCommand(command, connector);
                cmd.Parameters.AddWithValue("@Product", Product);
                cmd.Parameters.AddWithValue("@Category", category);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Rate", rate);
                cmd.Parameters.AddWithValue("@Selling_price", Selling_price);
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
        #endregion

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

        #region SEARCH
        public DataTable search(string keywords)
        {
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(connection);
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
        #endregion

        #region DELETE 
        public bool delete()
        {
            bool checker = true;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection connector = new OleDbConnection(connection);
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
        #endregion
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

        #region Search for product in transaction module
        public DataTable Search(string keywords)
        {
            string[] results = new string[4];
            const string conns = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(conns);
            string cmdstring = "SELECT Product , Rate , Selling_price , Quantity FROM Products WHERE id LIKE '%" + keywords + "%' OR Product LIKE '%" + keywords + "%' ";
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
        #endregion

        #region Get the product quantity from database
        public decimal GetProduct(string productName)
        {
            decimal qty = 0;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
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
        #endregion

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

        #region Update the product quantity
        public async Task<bool> QuantityUpdate(decimal quantity ,string productName )
        {
            bool success = false;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
            try
            {
                string cmds = "UPDATE Products SET Quantity = @Quantity WHERE Product = @product";
                OleDbCommand cmd = new OleDbCommand(cmds, conn);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@product", productName);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                var server_side = await quantityupdate2(quantity, productName);
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
        #endregion

        

        #region Increase the product quantity 
        public async Task<bool> IncreaseProduct(decimal quantity, string Product_name)
        {
            bool success = false;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
            try
            {
                //Getting the product from database
                decimal Qty = GetProduct(Product_name);

                //Calculations
                decimal result = Qty + quantity;

                //Updating the quantity in the database
                bool check = await QuantityUpdate(result, Product_name);

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
                conn.Close();

            }
            return success;
        }
        #endregion

        #region Decrease the product Quantity
        public async Task<bool> DecreaseProduct(decimal quantity, string Product_name)
        {
            bool success = false;
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
            try
            {
                //Getting the product from database
                decimal Qty = GetProduct(Product_name);

                //Calculations
                decimal result = Qty - quantity;

                //Updating the quantity in the database
                bool check = await QuantityUpdate(result, Product_name);

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
                conn.Close();

            }
            return success;

        }
        #endregion

        #region Displaying Products in inventory
        public OleDbDataAdapter DisplayProductsBasedOnCategory(string Name)
        {
            DataTable dt = new DataTable();
            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
            OleDbConnection conn = new OleDbConnection(connection);
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
        #endregion

        #region Read excel
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
        #endregion

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




    }
}