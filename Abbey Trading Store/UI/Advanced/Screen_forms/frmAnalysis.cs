using Abbey_Trading_Store.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    public partial class frmAnalysis : Form
    {
        public frmAnalysis()
        {
            InitializeComponent();

            DateTime start_date = (DateTime.Today).AddDays(-30);
            dateTimePicker1.Value = start_date;

            DateTime end_date = DateTime.Today;
            dateTimePicker2.Value = end_date;

            cbbx.Text = "Sales";

            TransactionDetail TD = new TransactionDetail();
            DataTable dt = TD.QueryTransactionsAppropriately(start_date, end_date, cbbx.Text);
            TDD.DataSource = dt;
            cc = dt;
        }

        private void materialComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        DataTable cc = new DataTable();

        private void regenerate()
        {
            try
            {
                //Getting all the query parameters from the form 
                DateTime start_date = dateTimePicker1.Value;
                DateTime end_date = dateTimePicker2.Value;
                string type = cbbx.Text;
                string customer_name = Customer.Text;
                string product_name = Product.Text;
                string quantity = Quantity.Text;
                string added_by = Added_by.Text;

                //Run the query 
                TransactionDetail TD = new TransactionDetail();
                DataTable dt = TD.QueryTransactionsAppropriately(
                    start_date,
                    end_date,
                    type,
                    (product_name != "") ? (product_name) : (null),
                    (customer_name != "") ? (customer_name) : (null),
                    (quantity != "") ? (Convert.ToInt32(quantity)) : (0),
                    (added_by != "") ? (added_by) : (null)
                );
                TDD.DataSource = dt;
                cc = dt;
                update_overall();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                
            }
            
        }


        private void update_overall()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(Int32));
            dt.Columns.Add("Product", typeof(String));
            dt.Columns.Add("Quantity", typeof(Int32));
            dt.Columns.Add("Total Sales", typeof(Int32));
            dt.Columns.Add("Total profits", typeof(Int32));

            //Dictionary to hold collected items or products
            Dictionary<int, string> checked_products = new Dictionary<int, string>();

            //index for current run
            int current_index = 0;
            int total_sales = 0;
            int total_profits = 0;

            foreach (DataRow dr in cc.Rows)
            {
                try
                {
                    if (checked_products.ContainsValue(dr[1].ToString()))
                    {
                        foreach (KeyValuePair<int, string> prod in checked_products)
                        {
                            if (dr[1].ToString() == prod.Value)
                            {
                                dt.Rows[prod.Key]["Quantity"] = Convert.ToInt32(dt.Rows[prod.Key]["Quantity"]) + Convert.ToInt32(dr[3]);

                                dt.Rows[prod.Key]["Total Sales"] = Convert.ToInt32(dt.Rows[prod.Key]["ToTal Sales"]) + Convert.ToInt32(dr[4]);
                                total_sales += Convert.ToInt32(dr[4]);

                                dt.Rows[prod.Key]["Total profits"] = Convert.ToInt32(dt.Rows[prod.Key]["Total profits"]) + Convert.ToInt32(dr[9]);
                                total_profits += Convert.ToInt32(dr[9]);

                            }
                            else
                            {
                                continue;
                            }
                        }

                    }
                    else
                    {
                        dt.Rows.Add(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToInt32(dr[3]), Convert.ToInt32(dr[4]), Convert.ToInt32(dr[9]));

                        total_sales += Convert.ToInt32(dr[4]);
                        total_profits += Convert.ToInt32(dr[9]);

                        checked_products.Add(current_index, dr[1].ToString());
                        current_index++;

                    }

                }
                catch (System.Data.DeletedRowInaccessibleException ex)
                {
                    continue;
                }
                finally
                {

                }


            }
            Overall_dgv.DataSource = dt;
            Total_sales.Text = "Shs." + total_sales.ToString("N0");
            Total_profits.Text = "Shs." + total_profits.ToString("N0");

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void frmAnalysis_Load(object sender, EventArgs e)
        {

            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            regenerate();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            regenerate();
        }

        private void cbbx_TextChanged(object sender, EventArgs e)
        {
            regenerate();
        }

        private void Customer_TextChanged(object sender, EventArgs e)
        {
            regenerate();
        }

        private void Product_TextChanged(object sender, EventArgs e)
        {
            regenerate();
        }

        private void Added_by_TextChanged(object sender, EventArgs e)
        {
            regenerate();
        }

        private void Quantity_TextChanged(object sender, EventArgs e)
        {
            regenerate();
        }

        private void Customer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected_item = Customer.Items[Customer.SelectedIndex].ToString();
            Customer.Text = selected_item;
            regenerate();
        }

        private void Customer_TextUpdate(object sender, EventArgs e)
        {
            string keywords = Customer.Text;
            DealerAndCustomer cust = new DealerAndCustomer();
            DataTable dt = cust.SearchAppropriately(keywords);
            foreach (DataRow dr in dt.Rows)
            {
                Customer.Items.Add(dr[2].ToString());
            }
        }

        private void Product_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected_product = Product.Items[Product.SelectedIndex].ToString();
            Product.Text = selected_product;
            regenerate();
        }

        private void Product_TextUpdate(object sender, EventArgs e)
        {
            string keywords = Product.Text;
            product product = new product();
            DataTable dt = product.searchAppropriately(keywords);
            foreach (DataRow dr in dt.Rows)
            {
                Product.Items.Add(dr[1].ToString());
            }
        }

        private void Added_by_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected_user = Added_by.Items[Added_by.SelectedIndex].ToString();
            Added_by.Text = selected_user;
            regenerate();
        }

        private void Added_by_TextUpdate(object sender, EventArgs e)
        {
            string keywords = Added_by.Text;
            Users user = new Users();
            DataTable dt = user.SearchAppropriately(keywords);
            foreach (DataRow dr in dt.Rows)
            {
                Added_by.Items.Add(dr[1].ToString());
            }
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            regenerate();
        }

        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {
            regenerate();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
