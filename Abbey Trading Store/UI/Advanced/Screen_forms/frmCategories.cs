using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL;
using Abbey_Trading_Store.UI.Advanced.CustomMessageBox;
using Microsoft.Reporting.WinForms;

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    public partial class frmCategories : Form
    {
        public frmCategories()
        {
            InitializeComponent();

            Categories category = new Categories();
            DataTable dt = category.SelectAppropriately();
            dataGridView1.DataSource = dt;

            this.circularProgressBar1.Value = dt.Rows.Count * 10;
            this.circularProgressBar1.Text = (dt.Rows.Count * 10).ToString() + "%";
        }

        private void clear()
        {
            id.Text = "";
            title.Text = "";
            description.Text = "";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void frmCategories_Load(object sender, EventArgs e)
        {
            
        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Categories category = new Categories();
            category.Title = title.Text;
            category.Description = description.Text;
            category.Added_by = Login_form.user;
            bool affected = await category.InsertAppropriately();
            if (affected == true)
            {
                RJMessageBox.Show("Category added successfully",
                    "Categories Management Portal",
                    MessageBoxButtons.OK);
                clear();
                
            }
            else
            {
                MessageBox.Show("Category insertion Failed");
            }
            DataTable dt = category.SelectAppropriately();
            dataGridView1.DataSource = dt;
            Cursor = Cursors.Default;
            this.circularProgressBar1.Value = dt.Rows.Count * 10;
            this.circularProgressBar1.Text = (dt.Rows.Count * 10).ToString() + "%";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            id.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
            title.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
            description.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
        }

        private async void materialButton3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Categories category = new Categories();
            category.ID = id.Text;
            bool affected = await category.DeleteAppropriately();
            if (affected == true)
            {
                Cursor = Cursors.Default;
                RJMessageBox.Show("Category deleted successfully",
                    "Categories Management Portal",
                    MessageBoxButtons.OK);
                clear();
                DataTable dt = category.SelectAppropriately();
                dataGridView1.DataSource = dt;
                this.circularProgressBar1.Value = dt.Rows.Count * 10;
                this.circularProgressBar1.Text = (dt.Rows.Count * 10).ToString() + "%";
            }
            else
            {
                MessageBox.Show("Category not deleted ");
            }
        }

        private async void materialButton2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Categories category = new Categories();
            category.Title = title.Text;
            category.Description = description.Text;
            category.ID = id.Text;
            bool affected = await category.UpdateAppropriately();
            if (affected == true)
            {
                Cursor = Cursors.Default;
                RJMessageBox.Show("Category successfully updated. Thank you.",
                    "Categories Management Portal",
                    MessageBoxButtons.OK);
                clear();
                DataTable dt = category.SelectAppropriately();
                dataGridView1.DataSource = dt;
                
            }
            else
            {
                MessageBox.Show("Category not updated.");
            }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            string value = search.Text;
            Categories category = new Categories();
            DataTable dt = category.SearchAppropriately(value);
            dataGridView1.DataSource = dt;

            this.circularProgressBar2.Value = dt.Rows.Count * 10;
            this.circularProgressBar2.Text = (dt.Rows.Count * 10).ToString() + "%";
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                id.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
                title.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
                description.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
            }
            

        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            // Generating the Report form 
            Cursor = Cursors.WaitCursor;
            Categories category = new Categories();
            Abbey_Trading_Store.Reports.Categories_Report.Categories dataset = new Reports.Categories_Report.Categories();
            SqlDataAdapter adapter = category.select_2();

            adapter.Fill(dataset, "Categories");
            ReportDataSource datasource = new ReportDataSource("Categories", dataset.Tables[0]);
            ReportDataSource[] list = { datasource };

            ReportView form = new ReportView(list, "Abbey_Trading_Store.Reports.Categories_Report.Categories.rdlc");
            form.Show();
            Cursor = Cursors.Default;
        }
    }
}
