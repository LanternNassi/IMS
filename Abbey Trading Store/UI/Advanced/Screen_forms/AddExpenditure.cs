using Abbey_Trading_Store.DAL;
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

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    public partial class AddExpenditure : Form
    {
        int expense_id;
        public AddExpenditure(int ExpenseId)
        {
            expense_id = ExpenseId;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ManageExpenditures form = new ManageExpenditures(expense_id);
            form.Show();
        }

        private void AddExpenditure_Load(object sender, EventArgs e)
        {
            ExpCategories category = new ExpCategories(expense_id);
            SqlDataAdapter adapter = category.Select();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cat_combobox.DataSource = dt;
            cat_combobox.DisplayMember = "Name";
            cat_combobox.ValueMember = "ID";

        }

        private void extra_txt_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void amount_txt_TextChanged(object sender, EventArgs e)
        {
            if (amount_txt.Text != "")
            {
                materialButton2.Enabled = true;
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            Expenditures expenditure = new Expenditures();
            expenditure.Description = extra_txt.Text;
            expenditure.Amount = amount_txt.Text;
            expenditure.Added_by = Login_form.user;
            expenditure.Overall_category = expense_id.ToString();
            expenditure.Category = cat_combobox.SelectedValue.ToString();

            ExpendituresDAL exp = new ExpendituresDAL(expenditure);
            bool success = exp.InsertExpenditure();
            if (success)
            {
                MessageBox.Show("Expenditure added successfully");
                Dashboard.active_exp_form.Load_data();
                this.Close();

            }
            else
            {
                MessageBox.Show("An error occured");
            }


        }
    }
}
