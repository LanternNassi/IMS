using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL;
using System.Data.SqlClient;

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    public partial class ManageExpenditures : Form
    {
        int expense_id;
        public ManageExpenditures(int Expense_id)
        {
            expense_id = Expense_id;
            InitializeComponent();
        }

        public bool item_active = false;


        private void name_txt_TextChanged(object sender, EventArgs e)
        {
            if (name_txt.Text.Length > 0 && !item_active)
            {
                materialButton1.Enabled = true;

            }
            else
            {
                materialButton1.Enabled = false;
            }
        }

        private void ManageExpenditures_Layout(object sender, LayoutEventArgs e)
        {
            
        }

        private void ManageExpenditures_Load(object sender, EventArgs e)
        {
            ExpCategories category = new ExpCategories(expense_id);
            System.Data.DataTable dt = new System.Data.DataTable();
            SqlDataAdapter adapter = category.Select();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void Clear()
        {
            id.Text = "";
            name_txt.Text = "";
            description.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                item_active = true;
                id.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
                name_txt.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
                description.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();


                materialButton1.Enabled = false;
                materialButton2.Enabled = true;
                materialButton3.Enabled = true;
            }

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            Expenditure_Categories category_props = new Expenditure_Categories();
            category_props.Name = name_txt.Text;
            category_props.Description = description.Text;
            category_props.Overall_category = expense_id.ToString();
            category_props.Added_by = Login_form.user;
            ExpCategories category = new ExpCategories(category_props);
            bool success = category.Insert();
            if (success)
            {
                MessageBox.Show("Category added successfully");
                Clear();
                Dashboard.active_exp_form.Load_data();

            }
            else
            {
                MessageBox.Show("Something happened . Try again later");
            }



            System.Data.DataTable dt = new System.Data.DataTable();
            ExpCategories category_2 = new ExpCategories(expense_id);
            SqlDataAdapter adapter = category_2.Select();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            Expenditure_Categories category_props = new Expenditure_Categories();
            category_props.Name = name_txt.Text;
            category_props.Description = description.Text;
            category_props.Added_by = Login_form.user;
            category_props.ID = Convert.ToInt32(id.Text);
            ExpCategories category = new ExpCategories(category_props);
            bool success = category.Update();
            if (success)
            {
                MessageBox.Show("Category updated successfully");
                Clear();
                Dashboard.active_exp_form.Load_data();
            }
            else
            {
                MessageBox.Show("An error occured");
            }


            System.Data.DataTable dt = new System.Data.DataTable();
            ExpCategories category_2 = new ExpCategories(expense_id);
            SqlDataAdapter adapter = category_2.Select();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            Expenditure_Categories category_props = new Expenditure_Categories();
            category_props.ID = Convert.ToInt32(id.Text);
           
            ExpCategories category = new ExpCategories(category_props);
            bool success = category.Delete();
            if (success)
            {
                MessageBox.Show("Category deleted successfully");
                Clear();
                Dashboard.active_exp_form.Load_data();

            }
            else
            {
                MessageBox.Show("An error occured");
            }

            System.Data.DataTable dt = new System.Data.DataTable();
            ExpCategories category_2 = new ExpCategories(expense_id);
            SqlDataAdapter adapter = category_2.Select();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
