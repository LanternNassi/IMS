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
    }
}
