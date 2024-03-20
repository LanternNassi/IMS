using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Abbey_Trading_Store.DAL;
using Abbey_Trading_Store.DAL.DAL_Properties;
using Abbey_Trading_Store.DAL.Helpers;
using Abbey_Trading_Store.UI.Advanced.CustomMessageBox;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    public partial class frmProducts : Form
    {

        public bool item_active = false;
        public DataTable product_changes = new DataTable();
        public DataRow product_row = null;

        private DataTable active_products = new DataTable();

        public frmProducts()
        {
            InitializeComponent();

            // Values of the category combo box
            Categories category = new Categories();
            category_comboBox1.DataSource = category.SelectAppropriately();
            // Specifying value in combobox
            category_comboBox1.DisplayMember = "title";
            category_comboBox1.ValueMember = "title";

            LoadProductsData();

            if (active_products.Rows.Count > 100)
            {
                this.circularProgressBar2.Value = (1000 / active_products.Rows.Count);
                this.circularProgressBar2.Text = (1000 / active_products.Rows.Count).ToString() + "%";
            }
            else
            {
                this.circularProgressBar2.Value = (active_products.Rows.Count);
                this.circularProgressBar2.Text = (active_products.Rows.Count).ToString() + "%";

            }

            if (dataGridView1.Rows.Count > 100)
            {
                this.circularProgressBar1.Value = (10000 / dataGridView1.Rows.Count);
                this.circularProgressBar1.Text = (10000 / dataGridView1.Rows.Count).ToString() + "%";
            }
            else
            {
                this.circularProgressBar1.Value = (dataGridView1.Rows.Count);
                this.circularProgressBar1.Text = (dataGridView1.Rows.Count).ToString() + "%";

            }


            //Calculating the heights of the panels regarding the space of the description panel since it is large
            this.panel13.Height = this.panel14.Height = this.panel15.Height = this.panel17.Height = this.panel18.Height = this.panel19.Height = (LayoutFlex.overall_container_height - 130)/6;


            //Calculating the width of the button panels
            //this.panel4.Height = this.panel5.Height = LayoutFlex.overall_container_width

            //Initialising the product changes dataTable
            product_changes.Columns.Add("Type");
            product_changes.Columns.Add("Product");
            product_changes.Columns.Add("Initial_price");
            product_changes.Columns.Add("Set_price");

        }

        public void LoadProductsData()
        {
            //Loading the datatable
            product product = new product();
            DataTable dt = new DataTable();
            dynamic adapter = product.SelectAppropriately();
            Connection().Open();


            adapter.Fill(dt);
            adapter.Fill(active_products);


            dataGridView1.DataSource = MoneyFormatter.formatDT(dt, new int[] { 4, 5, 10 });
            Connection().Close();
        }

        private dynamic Connection()
        {
            if (Env.mode == 1)
            {
                const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
                OleDbConnection conn = new OleDbConnection(connection);
                return conn;
            }else
            {
                SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
                return conn;
            }
        }

        //const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
        //OleDbConnection conn = new OleDbConnection(connection);

        private void clear()
        {
            id.Text = "";
            name.Text = "";
            category_comboBox1.Text = "";
            description.Text = "";
            rate.Text = "";
            SP_txtbx.Text = "";
            WP.Text = "";

            materialButton1.Enabled = false;
            materialButton2.Enabled = false;
            materialButton3.Enabled = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void id_Click(object sender, EventArgs e)
        {

        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void rate_Click(object sender, EventArgs e)
        {

        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            product product = new product();
            product.products = name.Text;
            product.Category = category_comboBox1.Text;
            product.Description = description.Text;
            product.Rate = decimal.Parse(rate.Text);
            product.Selling_price = decimal.Parse(SP_txtbx.Text);
            product.Wholesale_price = decimal.Parse(WP.Text);
            product.Quantity = 0;
            product.Added_by = Login_form.user;
            try
            {
                bool check = await product.AddAppropriately();
                if (check == true)
                {
                    Cursor = Cursors.Default;

                    //MessageBox.Show("Product added successfully",
                    //"Product Management Portal",
                    //MessageBoxButtons.OK);
                    if (MessageBox.Show("Product added successfully. Do you wish to send out messages to clients informing them of the new product?", "Product Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // user clicked yes
                    }
                    else
                    {

                        // user clicked no
                        product_changes.Rows.Add("Add", name.Text," ", "Shs." + SP_txtbx.Text);
                        materialButton5.Enabled = true;
                        materialButton5.Text = product_changes.Rows.Count.ToString() + " Changes";
                    }
                    clear();
                    if (dataGridView1.Rows.Count > 100)
                    {
                        this.circularProgressBar1.Value = (10000 / dataGridView1.Rows.Count);
                        this.circularProgressBar1.Text = (10000 / dataGridView1.Rows.Count).ToString() + "%";
                    }
                    else
                    {
                        this.circularProgressBar1.Value = (dataGridView1.Rows.Count);
                        this.circularProgressBar1.Text = (dataGridView1.Rows.Count).ToString() + "%";

                    }
                }
                else
                {
                    Cursor = Cursors.Default;
                    RJMessageBox.Show("Failed to add product",
                    "Product Management Portal",
                    MessageBoxButtons.OK);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                LoadProductsData();
            }
        }

        private async void materialButton2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            product product = new product();
            product.Id = Convert.ToInt32(id.Text);
            product.products = name.Text;
            product.Category = category_comboBox1.Text;
            product.Description = description.Text;
            product.Rate = decimal.Parse(rate.Text);
            product.Selling_price = decimal.Parse(SP_txtbx.Text);
            try
            {
                product.Wholesale_price = decimal.Parse(WP.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please validate your wholesale price.");
                Cursor = Cursors.Default;
                return;
            }
            finally
            {
                
            }
            product.Added_by = Login_form.user;
            bool check = await product.UpdateAppropriately();
            if (check == true)
            {
                item_active = false;
                Cursor = Cursors.Default;
                string old_price = product_row[5].ToString();
                if (old_price != SP_txtbx.Text)
                {
                    if (MessageBox.Show("Product updated successfully. Do you wish to send out messages to clients informing them of the new changes made immediately?", "Product Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // user clicked yes
                    }
                    else
                    {
                        // user clicked no
                        product_changes.Rows.Add("Update", name.Text, "Shs." + old_price, "Shs." + SP_txtbx.Text);
                        materialButton5.Enabled = true;
                        materialButton5.Text = product_changes.Rows.Count.ToString() + " Changes";
                    }
                } else
                {
                    MessageBox.Show("Product updated successfully.");
                }
                
                clear();

                if (dataGridView1.Rows.Count > 100)
                {
                    this.circularProgressBar1.Value = (10000 / dataGridView1.Rows.Count);
                    this.circularProgressBar1.Text = (10000 / dataGridView1.Rows.Count).ToString() + "%";
                }
                else
                {
                    this.circularProgressBar1.Value = (dataGridView1.Rows.Count);
                    this.circularProgressBar1.Text = (dataGridView1.Rows.Count).ToString() + "%";

                }
            }
            else
            {
                Cursor = Cursors.Default;
                RJMessageBox.Show("Failed to update product",
                    "Product Management Portal",
                    MessageBoxButtons.OK);
            }
            LoadProductsData();
        }

        private async void materialButton3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            product product = new product();
            product.Id = Convert.ToInt32(id.Text);
            bool check = await product.DeleteAppropriately();
            if (check == true)
            {
                item_active = false;
                Cursor = Cursors.Default;
                RJMessageBox.Show("Product deleted successfully",
                                    "Product Management Portal",
                                    MessageBoxButtons.OK); 
                clear();

                if (dataGridView1.Rows.Count > 100)
                {
                    this.circularProgressBar1.Value = (10000 / dataGridView1.Rows.Count);
                    this.circularProgressBar1.Text = (10000 / dataGridView1.Rows.Count).ToString() + "%";
                }
                else
                {
                    this.circularProgressBar1.Value = (dataGridView1.Rows.Count);
                    this.circularProgressBar1.Text = (dataGridView1.Rows.Count).ToString() + "%";

                }
            }
            else
            {
                Cursor = Cursors.Default;
                RJMessageBox.Show("Failed to delete product",
                    "Product Management Portal",
                    MessageBoxButtons.OK);
            }
            LoadProductsData();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            string keyword = search.Text;
            product product = new product();
            DataTable dt = product.SearchAppropriately(keyword);
            dataGridView1.DataSource = dt;

            if(dt.Rows.Count > 10)
            {
                this.circularProgressBar2.Value = (1000 / dt.Rows.Count);
                this.circularProgressBar2.Text = (1000 / dt.Rows.Count).ToString() + "%";
            }
            else
            {
                this.circularProgressBar2.Value = (dt.Rows.Count);
                this.circularProgressBar2.Text = (dt.Rows.Count).ToString() + "%";

            }
            

            if(dt.Rows.Count > 100)
            {
                this.circularProgressBar1.Value = (10000 / dt.Rows.Count);
                this.circularProgressBar1.Text = (10000 / dt.Rows.Count).ToString() + "%";
            }
            else
            {
                this.circularProgressBar1.Value = (dt.Rows.Count);
                this.circularProgressBar1.Text = (dt.Rows.Count).ToString() + "%";

            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            id.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
            name.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
            category_comboBox1.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
            description.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
            rate.Text = dataGridView1.Rows[row].Cells[4].Value.ToString();
            SP_txtbx.Text = dataGridView1.Rows[row].Cells[5].Value.ToString();
            WP.Text = dataGridView1.Rows[row].Cells[10].Value.ToString();

            materialButton1.Enabled = false;
            materialButton2.Enabled = true;
            materialButton3.Enabled = true;

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                //product_row = dataGridView1.Rows[row];
                //id.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
                //name.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
                //category_comboBox1.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
                //description.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
                //rate.Text = dataGridView1.Rows[row].Cells[4].Value.ToString();
                //SP_txtbx.Text = dataGridView1.Rows[row].Cells[5].Value.ToString();
                //WP.Text = dataGridView1.Rows[row].Cells[10].Value.ToString();

                product_row = active_products.Rows[row];
                id.Text = active_products.Rows[row][0].ToString();
                name.Text = active_products.Rows[row][1].ToString();
                category_comboBox1.Text = active_products.Rows[row][2].ToString();
                description.Text = active_products.Rows[row][3].ToString();
                rate.Text = active_products.Rows[row][4].ToString();
                SP_txtbx.Text = active_products.Rows[row][5].ToString();
                WP.Text = active_products.Rows[row][10].ToString();

                materialButton1.Enabled = false;
                materialButton2.Enabled = true;
                materialButton3.Enabled = true;
                materialButton6.Enabled = true;

            }


        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            if (name.Text.Length > 0 && !item_active)
            {
                materialButton1.Enabled = true;

            }
            else
            {
                materialButton1.Enabled = false;
            }
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            SyncChanges form = new SyncChanges(product_changes);
            form.Show();
        }

        private void materialButton6_Click(object sender, EventArgs e)
        {

            string Reason = Interaction.InputBox("Enter the reason for the change", "Enter the description", "");

            if(Reason != "")
            {
                string quantity = Interaction.InputBox("Enter the new Quantity", "Enter quantity", "");
                if (quantity != "")
                {
                    product Product = new product();
                    bool success = Product.update_product_quantity(Convert.ToInt32(product_row[0]), Convert.ToInt32(quantity), Reason, Login_form.user);
                    if (success)
                    {
                        MessageBox.Show("Quantity updated successfully");
                        LoadProductsData();
                    }
                    else
                    {
                        MessageBox.Show("An error occured. Try again later");
                    }
                }
                
            }

        }

        private void frmProducts_Layout(object sender, LayoutEventArgs e)
        {
            panel1.Width = Convert.ToInt32(Dashboard.PnlContainer.Width * 0.25);

            panel13.Height = panel14.Height = panel15.Height = panel17.Height = panel18.Height = panel19.Height = Convert.ToInt32((Dashboard.PnlContainer.Height) * 0.8)/6;
            panel16.Height = Dashboard.PnlContainer.Height - (panel14.Height * 6);

            panel3.Height = Convert.ToInt32(Dashboard.PnlContainer.Height * 0.2);
            panel8.Height = Convert.ToInt32(Dashboard.PnlContainer.Height * 0.1);

            panel4.Width = panel5.Width = Convert.ToInt32(panel3.Width * 0.55) / 2;
            panel7.Width = panel3.Width - (panel4.Width * 2);
            panel6.Height = panel7.Height = Convert.ToInt32(0.5 * panel3.Height);


            panel9.Width = panel10.Width = panel11.Width = panel12.Width = panel8.Width / 4;

        }
    }
}
