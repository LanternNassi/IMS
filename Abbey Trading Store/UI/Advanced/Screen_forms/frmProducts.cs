using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL;
using Abbey_Trading_Store.UI.Advanced.CustomMessageBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
        OleDbConnection conn = new OleDbConnection(connection);

        private void clear()
        {
            id.Text = "";
            name.Text = "";
            category_comboBox1.Text = "";
            description.Text = "";
            rate.Text = "";
            SP_txtbx.Text = "";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void id_Click(object sender, EventArgs e)
        {

        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            // Values of the category combo box
            Categories category = new Categories();
            category_comboBox1.DataSource = category.select();
            // Specifying value in combobox
            category_comboBox1.DisplayMember = "title";
            category_comboBox1.ValueMember = "title";
            //Loading the datatable
            product product = new product();
            DataTable dt = new DataTable();
            OleDbDataAdapter adapter = product.select();
            conn.Open();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

            this.circularProgressBar1.Value = dt.Rows.Count;
            this.circularProgressBar1.Text = (dt.Rows.Count).ToString() + "%";

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void rate_Click(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            product product = new product();
            product.products = name.Text;
            product.Category = category_comboBox1.Text;
            product.Description = description.Text;
            product.Rate = decimal.Parse(rate.Text);
            product.Selling_price = decimal.Parse(SP_txtbx.Text);
            product.Quantity = 0;
            product.Added_by = Login_form.user;
            try
            {
                bool check = product.add();
                if (check == true)
                {
                    Cursor = Cursors.Default;
                    RJMessageBox.Show("Product added successfully",
                    "Product Management Portal",
                    MessageBoxButtons.OK);
                    clear();

                    this.circularProgressBar1.Value = dataGridView1.Rows.Count;
                    this.circularProgressBar1.Text = (dataGridView1.Rows.Count).ToString() + "%";

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

                DataTable dt = new DataTable();
                OleDbDataAdapter adapter = product.select();
                conn.Open();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            product product = new product();
            product.Id = Convert.ToInt32(id.Text);
            product.products = name.Text;
            product.Category = category_comboBox1.Text;
            product.Description = description.Text;
            product.Rate = decimal.Parse(rate.Text);
            product.Selling_price = decimal.Parse(SP_txtbx.Text);
            product.Added_by = Login_form.user;
            bool check = product.update();
            if (check == true)
            {
                Cursor = Cursors.Default;
                RJMessageBox.Show("Updated product successfully",
                    "Product Management Portal",
                    MessageBoxButtons.OK);
                clear();

                this.circularProgressBar1.Value = dataGridView1.Rows.Count;
                this.circularProgressBar1.Text = (dataGridView1.Rows.Count).ToString() + "%";
            }
            else
            {
                Cursor = Cursors.Default;
                RJMessageBox.Show("Failed to update product",
                    "Product Management Portal",
                    MessageBoxButtons.OK);
            }
            DataTable dt = new DataTable();
            OleDbDataAdapter adapter = product.select();
            conn.Open();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            product product = new product();
            product.Id = Convert.ToInt32(id.Text);
            bool check = product.delete();
            if (check == true)
            {
                Cursor = Cursors.Default;
                RJMessageBox.Show("Product deleted successfully",
                                    "Product Management Portal",
                                    MessageBoxButtons.OK); 
                clear();

                this.circularProgressBar1.Value = dataGridView1.Rows.Count;
                this.circularProgressBar1.Text = (dataGridView1.Rows.Count).ToString() + "%";
            }
            else
            {
                Cursor = Cursors.Default;
                RJMessageBox.Show("Failed to delete product",
                    "Product Management Portal",
                    MessageBoxButtons.OK);
            }
            DataTable dt = new DataTable();
            OleDbDataAdapter adapter = product.select();
            conn.Open();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            string keyword = search.Text;
            product product = new product();
            DataTable dt = product.search(keyword);
            dataGridView1.DataSource = dt;

            this.circularProgressBar2.Value = dataGridView1.Rows.Count;
            this.circularProgressBar2.Text = (dataGridView1.Rows.Count).ToString() + "%";
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
        }
    }
}
