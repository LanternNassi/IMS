using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL;
using DGVPrinterHelper;
using System.Data.OleDb;
using Microsoft.Reporting.WinForms;
using Abbey_Trading_Store.Invoice;
using System.Web.Services.Description;

namespace Abbey_Trading_Store.UI
{
    public partial class frmPurchaseandsales : Form
    {
        public frmPurchaseandsales()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        DataTable dts = new DataTable();
        DataTable search = new DataTable();
        product product = new product();
        int initial_price;
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void frmPurchaseandsales_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Product");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Rate");
            dt.Columns.Add("Total",System.Type.GetType("System.Double"));
            dt.Columns.Add("Profit");
            
            dts.Columns.Add("ID");
            dts.Columns.Add("type");
            dts.Columns.Add("dea_cust_name");
            dts.Columns.Add("grandTotal");
            dts.Columns.Add("transaction_date");
            dts.Columns.Add("discount");
            dts.Columns.Add("added_by");
            dts.Columns.Add("Paid amount");
            dts.Columns.Add("Return amount");
            Types.Text = frmUserDashboard.type;
            this.reportViewer1.RefreshReport();
            if (Types.Text == "Purchase")
            {
                p_rate.ReadOnly = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keyword = textBox1.Text;
            if (keyword == "")
            {
                name.Text = "";
                email.Text = "";
                contact.Text = "";
                address.Text = "";
                return;
            }
            DealerAndCustomer DC = new DealerAndCustomer();
            string[] result = DC.search(keyword);
            name.Text = result[0];
            email.Text = result[1];
            contact.Text = result[2];
            address.Text = result[3];

        }

        private void p_search_TextChanged(object sender, EventArgs e)
        {
            search.Clear();
            string keyword = p_search.Text;
            if (keyword == "")
            {
                pname.Text = "";
                p_inventory.Text = "";
                p_rate.Text = "";
                search.Clear();
                return;
            }
            product product = new product();
            search = product.Search(keyword);
            for (int i = 0; i < search.Rows.Count; i++)
            {
                p_search.Items.Add(search.Rows[i][0].ToString());
            }
            //p_search.AutoCompleteSource = search;
            if (search.Rows.Count > 0)
            {
                pname.Text = search.Rows[0]["Product"].ToString();
                if (Types.Text == "Sales")
                {
                    p_rate.Text = search.Rows[0]["Selling_Price"].ToString();
                }
                else
                {
                    p_rate.Text = search.Rows[0]["Rate"].ToString();
                }
                p_inventory.Text = search.Rows[0]["Quantity"].ToString();
                if (search.Rows[0]["Selling_Price"].ToString() == null)
                {

                }
                else
                {
                    initial_price = int.Parse(search.Rows[0]["Rate"].ToString());
                }

            }
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //Getting 
            string productname = pname.Text;
            decimal rate = decimal.Parse(p_rate.Text);
            decimal quantity = decimal.Parse(p_quantity.Text);
            decimal total = rate * quantity;
            decimal subtotals = 0;
            if (subtotal.Text == "")
            {
            }
            else
            {
                subtotals = decimal.Parse(subtotal.Text);
            }
            decimal profit = ((quantity * rate) - (quantity * initial_price));

            //calulations
            subtotals += total;
            subtotal.Text = subtotals.ToString("N0");

            if (productname == "")
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Please add a product.");
            }
            else
            {
                dt.Rows.Add(productname, quantity, rate, total, profit);
                dgv_products.DataSource = dt;
                //hiding the profit column
                dgv_products.Columns[4].Visible = false;
                //NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                //dgv_products.Columns["Total"].DefaultCellStyle.Format = "C";
                pname.Text = "";
                p_search.Text = "";
                p_inventory.Text = "";
                p_rate.Text = "0";
                p_quantity.Text = "0";

            }
            Cursor = Cursors.Default;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            if (textBox13.Text == "")
            {
                grandtotal.Text = subtotal.Text;

            }
            else
            {
                // Discount for raw values 
                int discount = 0;
                try
                {
                    discount = Convert.ToInt32(textBox13.Text);
                }
                catch(Exception) {
                    MessageBox.Show("Please enter a valid amount");
                    textBox13.Text = "";
                }
                finally
                {

                }
                decimal sub = decimal.Parse(subtotal.Text);
                int subtL = Convert.ToInt32(sub);
                int overall = subtL - discount;
                grandtotal.Text = overall.ToString("N0");

            }
            
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            if (paid_amount.Text == "")
            {
                return_amount.Text = "0";
            }
            else
            {
                decimal grandtotals = Decimal.Parse(grandtotal.Text);
                decimal paid = Decimal.Parse(paid_amount.Text);
                decimal returnvalue = paid-grandtotals;
                return_amount.Text = returnvalue.ToString("N0");

                
            }
        }

        

        private async void save_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            //Cursor.Current = Cursors.WaitCursor;
            string course;
            if (Types.Text == "Sales")
            {
                course = "Customer";
            }
            else
            {
                course = "Dealer";
            }
            string dea_cust_name = name.Text;
            string emails = email.Text;
            string contacts = contact.Text;
            string addresss = address.Text;
            int discount = int.Parse(textBox13.Text);
            int grand_total = int.Parse((grandtotal.Text).Replace(",",""));
            
            DealerAndCustomer DC = new DealerAndCustomer();
            bool check = DC.checker(dea_cust_name);
            if (check == true)
            {
                //MessageBox.Show("Successful");

            }
            else
            {
                //MessageBox.Show("Doesn't exist");
                DC.Name = dea_cust_name;
                DC.Email = emails;
                DC.Contact = contacts;
                DC.Address = addresss;
                DC.Added_by = Login_form.user;
                string type;
                if (Types.Text == "Sales")
                {
                    type = "Customer";
                }
                else
                {
                    type = "Dealer";
                }
                DC.Type = type;
                bool test = DC.Insert();
                var test2 = await DC.insert2();
                if (test == true)
                {

                    //MessageBox.Show("inserted successfully");
                }
                else
                {
                    MessageBox.Show("Failed");
                }
            }

            //Inserting the transactions into the database
            bool success = false;
            //using (TransactionScope scope = new TransactionScope())
            //{

            int Transactionid = -1;
            Transactions transact = new Transactions();
            int ovp = 0;
            for (int h = 0; h <= ((dt.Rows.Count) - 1); h++)
            {
                ovp += int.Parse(dt.Rows[h][4].ToString());
            }
            //Veryfying whether the product is taken
            //string message = "Are the items taken ?";
            //string title = "Confirmation";
            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //DialogResult result = MessageBox.Show(message, title, buttons);
            //if (result == DialogResult.Yes)
            //{
            //    transact.Taken = "True";
            //}
            //else
            //{
            //    transact.Taken = "False";
            //}

            //Veryfing whether the product is paid for
            //string message_paid = "Are the items Paid for ?";
            //string title_paid = "Confirmation";
            //MessageBoxButtons buttons_paid = MessageBoxButtons.YesNo;
            //DialogResult result_paid = MessageBox.Show(message_paid, title_paid, buttons_paid);
            //if (result_paid == DialogResult.Yes)
            //{
            //    transact.Paid = "True";
            //}
            //else
            //{
            //    transact.Paid = "False";
            //}
            if (int.Parse((return_amount.Text).Replace(",","")) < 0)
            {
                transact.Paid = "False";
            }
            else
            {
                transact.Paid = "True";
            }
            transact.Taken = "True";
            transact.Added_by = Login_form.user;
            transact.Dea_Cust_name = name.Text;
            transact.Discount = int.Parse(textBox13.Text);
            transact.GrandTotal = int.Parse((grandtotal.Text).Replace(",",""));
            transact.Transaction_date = DateTime.Now;
            transact.Type = course;
            transact.Return_amount = int.Parse((return_amount.Text).Replace(",",""));
            transact.Paid_amount = int.Parse((paid_amount.Text).Replace(",",""));
            if (Types.Text == "Sales")
            {
                transact.Total_Profit = ovp - int.Parse(textBox13.Text);
            }
            else
            {
                transact.Total_Profit = 0;
            }
            

            // adding transaction to dataTable dts
            dts.Rows.Add("2", transact.Type, name.Text, grandtotal.Text, DateTime.Now, textBox13.Text, Login_form.user, paid_amount.Text, return_amount.Text);
            int x = transact.Insert();
            // Inserting to the server
            var isSuccess_server = await transact.insert2();
            //if (isSuccess_server)
            //{
            //    MessageBox.Show("Transaction added successfully to server");
            //} else
            //{
            //    MessageBox.Show("Transaction upload to server failed");
            //}
            TransactionDetail TD = new TransactionDetail();
            int recorder = 0;
            int i;
            
            for (i=0; i<dt.Rows.Count; i++){

                TD.Product_name = dt.Rows[i][0].ToString();
                TD.qty = decimal.Parse(dt.Rows[i][1].ToString());
                TD.Rate = decimal.Parse(dt.Rows[i][2].ToString());
                TD.Total = decimal.Parse(dt.Rows[i][3].ToString());
                TD.profit = int.Parse(dt.Rows[i][4].ToString());
                TD.type = Types.Text;
                TD.Dea_Cust_name = name.Text;
                TD.Added_by = Login_form.user;
                if (Types.Text == "Sales")
                {
                    TD.profit = int.Parse(dt.Rows[i][4].ToString());   
                }
                TD.invoice_id = x;
                bool y = TD.Insert();
                var detailsuccess = await TD.insert2();
                recorder += 1;
                if (Types.Text == "Sales")
                {
                    check = await product.DecreaseProduct(TD.qty, TD.Product_name);
                       

                }
                else if (Types.Text == "Purchase")
                {
                    check = await product.IncreaseProduct(TD.qty, TD.Product_name);

                }
                    
            }
                
            success = (recorder == dt.Rows.Count);
            if (success)
            {
               
                //MessageBox.Show("Transaction successfully completed.");
                textBox1.Text = "";
                name.Text = course;
                email.Text = "Lanternnassi@gmail.com";
                contact.Text = "0753103488";
                address.Text = "Masaka";
                p_search.Text = "";
                pname.Text = "";
                p_inventory.Text = "";
                p_quantity.Text = "";
                p_rate.Text = "";
                subtotal.Text = "";
                return_amount.Text = "";     
                grandtotal.Text = "";
                dt.Rows.Clear();
                dgv_products.DataSource = null;
                textBox13.Text = "";
                paid_amount.Text = "";
                invoice_txtbx.Text = x.ToString();

                if (Types.Text == "Sales")
                {
                    // printing an invoice
                    const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
                    OleDbConnection conn = new OleDbConnection(connection);

                    string cmd = "SELECT * FROM `Transactions` WHERE ID = " + x + " ";
                    string cmd2 = "SELECT `product_name` , `Qty` , `rate` , `total` FROM `Transaction Details` WHERE Invoice_id = " + x + " ";

                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd, conn);
                    OleDbDataAdapter adapter2 = new OleDbDataAdapter(cmd2, conn);

                    Abbey_Trading_StoreDataSet dataset = new Abbey_Trading_StoreDataSet();
                    conn.Open();

                    adapter2.Fill(dataset, "Datatable_invoice");
                    adapter.Fill(dataset, "DataTable_Details2");
                    conn.Close();

                    ReportDataSource datasource = new ReportDataSource("DataSet_Report", dataset.Tables[0]);
                    ReportDataSource datasource2 = new ReportDataSource("DataSet_details", dataset.Tables[1]);

                    this.reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.LocalReport.DataSources.Add(datasource2);
                    this.reportViewer1.LocalReport.DataSources.Add(datasource);
                    this.reportViewer1.RefreshReport();

                }
                else
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Purchase saved successfully");
                }
               
              
                    
            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Transaction Failed");
            }

                


            //}


        }

        private void dgv_products_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int row = e.RowIndex;
            pname.Text = dgv_products.Rows[row].Cells[0].Value.ToString();
            p_quantity.Text = dgv_products.Rows[row].Cells[1].Value.ToString();
            p_rate.Text = dgv_products.Rows[row].Cells[2].Value.ToString();
            int total = int.Parse(dgv_products.Rows[row].Cells[3].Value.ToString());
            dt.Rows[row].Delete();
            int subtotals = int.Parse((subtotal.Text).Replace(",",""));
            int final_sub = subtotals - total;
            subtotal.Text = final_sub.ToString("N0");
            


        }
        private bool check_validity(OleDbDataAdapter adapter)
        {
            bool isSuccess = false;
            DataTable check_dt = new DataTable();
            adapter.Fill(check_dt);
            if (check_dt.Rows.Count > 0)
            {
                 if (check_dt.Rows[0]["type"].ToString() == "Customer")
            {
                isSuccess = true;
            }
                
            }
           
            return isSuccess;
        }
        private void generate_invoice_Click(object sender, EventArgs e)
        {
            int invoice_id = int.Parse(this.invoice_txtbx.Text);
            string cmd = "SELECT * FROM Transactions WHERE ID = " + invoice_id + " ";
            string cmd2 = "SELECT `product_name` , `Qty` , `rate` , `total` FROM `Transaction Details` WHERE Invoice_id = " + invoice_id + " ";

            const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";

            OleDbConnection conn = new OleDbConnection(connection);

            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd, conn);
            if (check_validity(adapter))
            {
                OleDbDataAdapter adapter2 = new OleDbDataAdapter(cmd2, conn);

                Abbey_Trading_StoreDataSet dataset = new Abbey_Trading_StoreDataSet();

                conn.Open();
                adapter.Fill(dataset, "DataTable_Details2");
                adapter2.Fill(dataset, "Datatable_invoice");
                conn.Close();

                ReportDataSource datasource = new ReportDataSource("DataSet_Report", dataset.Tables[0]);
                ReportDataSource datasource2 = new ReportDataSource("DataSet_details", dataset.Tables[1]);

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(datasource);
                reportViewer1.LocalReport.DataSources.Add(datasource2);
                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Transaction id " + invoice_id + " is not a receipt type transaction");
            }
           
        }

        private void p_search_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void p_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = p_search.Items[p_search.SelectedIndex].ToString();
            pname.Text = selectedItem;
            product product = new product();
            DataTable temp = product.search(selectedItem);
            if (Types.Text == "Sales")
            {
                p_rate.Text = temp.Rows[0]["Selling_Price"].ToString();
            }
            else
            {
                p_rate.Text = temp.Rows[0]["Rate"].ToString();
            }
            p_inventory.Text = temp.Rows[0]["Quantity"].ToString();
            if (temp.Rows[0]["Selling_Price"].ToString() == null)
            {

            }
            else
            {
                initial_price = int.Parse(temp.Rows[0]["Rate"].ToString());
            }
           

        }
    }
}
