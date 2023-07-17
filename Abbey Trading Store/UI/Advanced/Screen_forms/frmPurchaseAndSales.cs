using Abbey_Trading_Store.DAL;
using Abbey_Trading_Store.UI.Advanced.CustomMessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using Microsoft.Reporting.WinForms;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL.DAL_Properties;
using System.Data.SqlClient;
using System.Speech.Synthesis;
using MaterialSkin.Controls;
using Microsoft.VisualBasic;

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    public partial class frmPurchaseAndSales : MaterialForm
    {
        string form_type;
        public frmPurchaseAndSales(string type)
        {
            InitializeComponent();
            form_type = type;
        }

        

        DataTable dt = new DataTable();
        DataTable dts = new DataTable();
        DataTable searchdt = new DataTable();
        product product = new product();
        int initial_price;

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmPurchaseAndSales_Load(object sender, EventArgs e)
        {

            //MessageBox.Show("Loaded");
            dt.Columns.Add("Product");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Rate");
            dt.Columns.Add("Total", System.Type.GetType("System.Double"));
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
            if (this.form_type == "Purchase")
            {
                //p_rate.ReadOnly = true;
            }

        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            string keyword = search.Text;
            if (keyword == "")
            {
                name.Text = "";
                email.Text = "";
                contact.Text = "";
                address.Text = "";
                return;
            }
            DealerAndCustomer DC = new DealerAndCustomer();
            string[] result = DC.searchAppropriately(keyword);
            name.Text = result[0];
            email.Text = result[1];
            contact.Text = result[2];
            address.Text = result[3];

        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            if(Convert.ToDecimal(p_inventory.Text) >= 0)
            {
                if (p_quantity.Text != "" && decimal.Parse(p_quantity.Text) > 0)
                {
                    Cursor = Cursors.WaitCursor;
                    grandtotal.Text = "";
                    textBox13.Text = "";
                    //Getting 
                    string productname = p_name.Text;
                    decimal quantity = decimal.Parse(p_quantity.Text);
                    decimal rate = 0;
                    decimal total = 0;
                    if (p_quantity.Text.Contains("."))
                    {
                        decimal calculated = decimal.Parse(p_quantity.Text) * decimal.Parse(p_rate.Text);
                        string amount = Interaction.InputBox("Confirm the amount?", "Amount", calculated.ToString());
                        total = decimal.Parse(amount);
                        rate = decimal.Parse(p_rate.Text);
                    }
                    else
                    {
                        rate = decimal.Parse(p_rate.Text);
                        total = rate * quantity;
                    }
                    //decimal total = rate * quantity;
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
                        dataGridView1.DataSource = dt;
                        //hiding the profit column
                        dataGridView1.Columns[4].Visible = false;
                        //NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                        //dgv_products.Columns["Total"].DefaultCellStyle.Format = "C";
                        p_name.Text = "";
                        p_search1.Text = "";
                        p_inventory.Text = "";
                        p_rate.Text = "0";
                        p_rate.Items.Clear();
                        p_quantity.Text = "";
                        p_rate.Items.Clear();

                    }
                    Cursor = Cursors.Default;

                }
                else
                {
                    MessageBox.Show("Invalid entry . Add a quantity");
                }
            } else
            {
                MessageBox.Show("You are trying to add a product whose inventory count is depleted. Consider clearing the conflict before trying again");
            }
           
            

        }

        private void test()
        {

            Cursor = Cursors.WaitCursor;
            //Getting 
            if (p_quantity.Text == "")
            {
                RJMessageBox.Show("Please fill in the quantity",
                    "Sales Management Portal",
                    MessageBoxButtons.OK);

            }
            else
            {
                string productname = p_name.Text;
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
                    RJMessageBox.Show("Please add a product",
                    "Sales Management Portal",
                    MessageBoxButtons.OK);
                }
                else
                {
                    dt.Rows.Add(productname, quantity, rate, total, profit);
                    dataGridView1.DataSource = dt;
                    //hiding the profit column
                    dataGridView1.Columns[4].Visible = false;
                    //NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                    //dgv_products.Columns["Total"].DefaultCellStyle.Format = "C";
                    p_name.Text = "";
                    p_search1.Text = "";
                    p_inventory.Text = "";
                    p_rate.Text = "0";
                    p_quantity.Text = "0";

                    SpeechSynthesizer SS = new SpeechSynthesizer();
                    SS.SpeakAsync(productname + " is added at a quantity of " + quantity + " and a total of " + total + " Ugandan shillings");

                }

            }

            Cursor = Cursors.Default;

        }

        private void p_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = p_search1.Items[p_search1.SelectedIndex].ToString();
            p_name.Text = selectedItem;
            product product = new product();
            DataTable temp = product.searchAppropriately(selectedItem);
            if (this.form_type != "Purchase")
            {
                p_rate.Items.Clear();
                //p_rate.Text = temp.Rows[0]["Selling_Price"].ToString();
                this.p_rate.Items.AddRange(new object[] {
                    temp.Rows[0]["Selling_Price"].ToString(),
                    temp.Rows[0]["Wholesale_price"].ToString()
            });
                this.p_rate.Text = temp.Rows[0]["Selling_Price"].ToString();
                //p_rate.Items.Add(temp.Rows[0]["Wholesale_price"].ToString());
            }
            else
            {
                p_rate.Items.Clear();
                p_rate.Items.Add(temp.Rows[0]["Rate"].ToString());
                this.p_rate.Text = temp.Rows[0]["Rate"].ToString();
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

        private void p_search_TextUpdate(object sender, EventArgs e)
        {
            string keyword = p_search1.Text;
            if (keyword == "")
            {
                p_name.Text = "";
                p_inventory.Text = "";
                this.p_rate.Items.Clear();
                this.p_rate.Text = "";
                //search.Clear();
                return;
            }
            product product = new product();
            searchdt = product.SearchAppropriately(keyword);
            int the_count = searchdt.Rows.Count > 30 ? (30) : (searchdt.Rows.Count);
            for (int i = 0; i < the_count; i++)
            {
                p_search1.Items.Add(searchdt.Rows[i][1].ToString());
            }
            //p_search.AutoCompleteSource = search;
            if (searchdt.Rows.Count > 0)
            {
                p_name.Text = searchdt.Rows[0]["Product"].ToString();
                if (this.form_type != "Purchase")
                {
                    p_rate.Items.Clear();
                    //p_rate.Text = searchdt.Rows[0]["Selling_Price"].ToString();
                    this.p_rate.Items.AddRange(new object[] {
                    searchdt.Rows[0]["Selling_Price"].ToString(),
                    searchdt.Rows[0]["Wholesale_price"].ToString()
            });
                    this.p_rate.Text = searchdt.Rows[0]["Selling_Price"].ToString();
                    //p_rate.Items.Add(searchdt.Rows[0]["Wholesale_price"].ToString());
                }
                else
                {
                    p_rate.Items.Clear();
                    p_rate.Items.Add(searchdt.Rows[0]["Rate"].ToString());
                    this.p_rate.Text = searchdt.Rows[0]["Rate"].ToString();

                }
                p_inventory.Text = searchdt.Rows[0]["Quantity"].ToString();
                if (searchdt.Rows[0]["Selling_Price"].ToString() == null)
                {

                }
                else
                {
                    initial_price = int.Parse(searchdt.Rows[0]["Rate"].ToString());
                }

            }

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
                try
                {
                    int discount = Convert.ToInt32(textBox13.Text);
                    decimal sub = decimal.Parse(subtotal.Text);
                    int subtL = Convert.ToInt32(sub);
                    int overall = subtL - discount;
                    grandtotal.Text = overall.ToString("N0");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Input a valid discount");

                }
                finally
                {

                }
                

            }
        }

        private void paid_amount_TextChanged(object sender, EventArgs e)
        {
            if (paid_amount.Text == "")
            {
                return_amount.Text = "0";
            }
            else
            {
                decimal grandtotals = Decimal.Parse(grandtotal.Text);
                decimal paid = Decimal.Parse(paid_amount.Text);
                decimal returnvalue = paid - grandtotals;
                return_amount.Text = returnvalue.ToString("N0");


            }
        }

        private async void materialButton2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            this.reportViewer1.RefreshReport();
            string course;
            if (form_type == "Sales")
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
            int grand_total = int.Parse((grandtotal.Text).Replace(",", ""));

            DealerAndCustomer DC = new DealerAndCustomer();
            bool check = DC.CheckerAppropriately(dea_cust_name);
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
                if (form_type == "Sales")
                {
                    type = "Customer";
                }
                else
                {
                    type = "Dealer";
                }
                DC.Type = type;
                bool test = await DC.InsertAppropriately();
                if (test == true)
                {

                    //MessageBox.Show("inserted successfully");
                }
                else
                {
                    Cursor = Cursors.Default;
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
                try
                {
                    ovp += int.Parse(dt.Rows[h][4].ToString());

                }catch(Exception ex)
                {
                    Decimal profit1 = Decimal.Parse(dt.Rows[h][4].ToString());
                    ovp += Convert.ToInt32(profit1);
                }
                finally
                {

                }
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
            if (int.Parse((return_amount.Text).Replace(",", "")) < 0)
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
            transact.GrandTotal = int.Parse((grandtotal.Text).Replace(",", ""));
            transact.Transaction_date = DateTime.Now;
            transact.Type = course;
            transact.Return_amount = int.Parse((return_amount.Text).Replace(",", ""));
            transact.Paid_amount = int.Parse((paid_amount.Text).Replace(",", ""));
            if (form_type == "Sales")
            {
                transact.Total_Profit = ovp - int.Parse(textBox13.Text);
            }
            else
            {
                transact.Total_Profit = 0;
            }


            // adding transaction to dataTable dts
            dts.Rows.Add("2", transact.Type, name.Text, grandtotal.Text, DateTime.Now, textBox13.Text, Login_form.user, paid_amount.Text, return_amount.Text);
            int x = await transact.InsertAppropriately();
            TransactionDetail TD = new TransactionDetail();
            int recorder = 0;
            int i;

            for (i = 0; i < dt.Rows.Count; i++)
            {
                TD.Product_name = dt.Rows[i][0].ToString();
                TD.qty = Convert.ToDecimal(dt.Rows[i][1].ToString());
                //TD.qty = String.Format("{0:0.00}", (dt.Rows[i][1].ToString()));
               
                TD.Rate = decimal.Parse(dt.Rows[i][2].ToString());
                TD.Total = decimal.Parse(dt.Rows[i][3].ToString());
                try
                {
                    TD.profit = int.Parse(dt.Rows[i][4].ToString());

                }
                catch (Exception ex)
                {
                    Decimal profit_hold = Decimal.Parse(dt.Rows[i][4].ToString());
                    TD.profit = Convert.ToInt32(profit_hold);
                }
                finally
                {

                }
                TD.type = form_type;
                TD.Dea_Cust_name = name.Text;
                TD.Added_by = Login_form.user;
                if (form_type == "Sales")
                {
                    try
                    {
                        TD.profit = int.Parse(dt.Rows[i][4].ToString());

                    }
                    catch (Exception ex)
                    {
                        Decimal profit_hold = Decimal.Parse(dt.Rows[i][4].ToString());
                        TD.profit = Convert.ToInt32(profit_hold);
                    }
                    finally
                    {

                    }
                }
                TD.invoice_id = x;
                bool y = await TD.InsertAppropriately();
                recorder += 1;
                if (form_type == "Sales")
                {
                    Decimal count = decimal.Parse(dt.Rows[i][1].ToString());
                    check = await product.DecreaseProduct(count, TD.Product_name);


                }
                else if (form_type == "Purchase")
                {
                    Decimal count = decimal.Parse(dt.Rows[i][1].ToString());
                    check = await product.IncreaseProduct(count, TD.Product_name);

                }

            }
            //foreach(DataRow dr in dataGridView1.Rows)
            //{

            //    TD.Product_name = dr[0].ToString();
            //    TD.qty = decimal.Parse(dr[1].ToString());
            //    TD.Rate = decimal.Parse(dr[2].ToString());
            //    TD.Total = decimal.Parse(dr[3].ToString());
            //    TD.profit = int.Parse(dr[4].ToString());
            //    TD.type = form_type;
            //    TD.Dea_Cust_name = name.Text;
            //    TD.Added_by = Login_form.user;
            //    if (form_type == "Sales")
            //    {
            //        TD.profit = int.Parse(dr[4].ToString());
            //    }
            //    TD.invoice_id = x;
            //    bool y = await TD.InsertAppropriately();
            //    recorder += 1;
            //    if (form_type == "Sales")
            //    {
            //        check = await product.DecreaseProduct(TD.qty, TD.Product_name);


            //    }
            //    else if (form_type == "Purchase")
            //    {
            //        check = await product.IncreaseProduct(TD.qty, TD.Product_name);

            //    }

            //}

            success = (recorder == dt.Rows.Count) && check;
            if (success)
            {

                //MessageBox.Show("Transaction successfully completed.");
                search.Text = "";
                name.Text = course;
                email.Text = "";
                contact.Text = "";
                address.Text = "";
                p_search1.Text = "";
                p_name.Text = "";
                p_inventory.Text = "";
                p_quantity.Text = "";
                p_rate.Text = "";
                subtotal.Text = "";
                return_amount.Text = "";
                grandtotal.Text = "";
                dt.Rows.Clear();
                dataGridView1.DataSource = null;
                textBox13.Text = "";
                paid_amount.Text = "";
                invoice_txtbx.Text = x.ToString();

                if (form_type == "Sales")
                {
                    if (Env.mode == 1)
                    {
                        // printing an invoice
                        OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);

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
                        // printing an invoice
                        SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);

                        string cmd = "SELECT * FROM Transactions WHERE ID = " + x + " ";
                        string cmd2 = "SELECT product_name , Qty , rate , total FROM [Transaction Details] WHERE Invoice_id = " + x + " ";

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd, conn);
                        SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2, conn);

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
                    

                }
                else
                {
                    Cursor = Cursors.Default;
                    RJMessageBox.Show("Purchase added successfully",
                    "Sales Management Portal",
                    MessageBoxButtons.OK);
                }



            }
            else
            {
                Cursor = Cursors.Default;
                RJMessageBox.Show("Transaction failed",
                    "Sales Management Portal",
                    MessageBoxButtons.OK);
            }

            Cursor = Cursors.Default;

        }

        private bool check_validity(dynamic adapter)
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

        private void materialButton4_Click(object sender, EventArgs e)
        {
            if (Env.mode == 1)
            {
                Cursor = Cursors.WaitCursor;
                int invoice_id = int.Parse(this.invoice_txtbx.Text);
                string cmd = "SELECT * FROM Transactions WHERE ID = " + invoice_id + " ";
                string cmd2 = "SELECT `product_name` , `Qty` , `rate` , `total` FROM `Transaction Details` WHERE Invoice_id = " + invoice_id + " ";


                OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);

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
                    Cursor = Cursors.Default;
                    MessageBox.Show("Transaction id " + invoice_id + " is not a receipt type transaction");
                }
                Cursor = Cursors.Default;

            } else
            {
                Cursor = Cursors.WaitCursor;
                int invoice_id = int.Parse(this.invoice_txtbx.Text);
                string cmd = "SELECT * FROM Transactions WHERE ID = " + invoice_id + " ";
                string cmd2 = "SELECT product_name , Qty , rate , total FROM [Transaction Details] WHERE Invoice_id = " + invoice_id + " ";


                SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd, conn);
                if (check_validity(adapter))
                {
                    SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2, conn);

                    Abbey_Trading_StoreDataSet dataset = new Abbey_Trading_StoreDataSet();

                    conn.Open();
                    adapter.Fill(dataset, "DataTable_Details2");
                    adapter2.Fill(dataset, "Datatable_invoice");
                    //Env.account_adapter.Fill(dataset, "DataTable_Company");
                    conn.Close();

                    ReportDataSource datasource = new ReportDataSource("DataSet_Report", dataset.Tables[0]);
                    ReportDataSource datasource2 = new ReportDataSource("DataSet_details", dataset.Tables[1]);
                    //ReportDataSource datasource3 = new ReportDataSource("DataSet_Company", dataset.Tables[2]);


                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(datasource);
                    reportViewer1.LocalReport.DataSources.Add(datasource2);
                    //reportViewer1.LocalReport.DataSources.Add(datasource3);
                    this.reportViewer1.RefreshReport();
                }
                else
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Transaction id " + invoice_id + " is not a receipt type transaction");
                }
                Cursor = Cursors.Default;

            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            
            
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0 && !(row == dataGridView1.Rows.Count+1))
            {
                p_name.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
                p_quantity.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
                p_rate.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
                int total = int.Parse(dataGridView1.Rows[row].Cells[3].Value.ToString());
                dt.Rows[row].Delete();
                int subtotals = int.Parse((subtotal.Text).Replace(",", ""));
                int final_sub = subtotals - total;
                subtotal.Text = final_sub.ToString("N0");

                textBox13.Text = "";
                paid_amount.Text = "";
                grandtotal.Text = "";
                return_amount.Text = "";
            }
            

        }

        private void p_rate_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialButton3_Click(object sender, EventArgs e)
        {

        }

        private void invoice_txtbx_TextChanged(object sender, EventArgs e)
        {
            if (invoice_txtbx.Text.Length > 0)
            {
                materialButton4.Enabled = true;

            }else
            {
                materialButton4.Enabled = false;
            }
        }

        private void return_amount_TextChanged(object sender, EventArgs e)
        {
            if (return_amount.Text.Length > 0)
            {
                materialButton2.Enabled = true;
            }else
            {
                materialButton2.Enabled = false;
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                materialButton5.Enabled = true;
            }else
            {
                materialButton5.Enabled = false;
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dataGridView1.Rows.Count == 1)
            {
                materialButton5.Enabled = true;
            }
            else
            {
                materialButton5.Enabled = false;
            }
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            //Creating a temporary dataTable 
            DataTable temp_dt = new DataTable();
            temp_dt.Columns.Add("Served_by");
            temp_dt.Columns.Add("Grand_total");
            temp_dt.Columns.Add("Customer_name");
            temp_dt.Columns.Add("Discount");
            try
            {
                temp_dt.Rows.Add(Login_form.user, grandtotal.Text, name.Text, textBox13.Text);
            }catch(Exception ex)
            {
                MessageBox.Show("Please enter a valid disocunt");
            }
            finally
            {

            }
            Users user = new Users();
            Abbey_Trading_Store.Reports.Quotation_Report.QuotationDataSet dataset = new Reports.Quotation_Report.QuotationDataSet();

            ReportDataSource datasource = new ReportDataSource("Overall", temp_dt);
            ReportDataSource datasource_2 = new ReportDataSource("Products", dt);

            ReportDataSource[] list = { datasource , datasource_2 };

            ReportView form = new ReportView(list, "Abbey_Trading_Store.Reports.Quotation_Report.Report1.rdlc");
            form.Show();
            Cursor = Cursors.Default;
        }
    }
}
