using Abbey_Trading_Store.DAL;
using MaterialSkin.Controls;
using Microsoft.Data.SqlClient;
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
    public partial class UnsettledDebts : MaterialForm
    {
        public UnsettledDebts()
        {
            InitializeComponent();
        }

        private void UnsettledDebts_Load(object sender, EventArgs e)
        {
            Transactions transactions= new Transactions();
            System.Data.SqlClient.SqlDataAdapter adapter = transactions.GetDebtorsOnly();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {
            string searched_name = materialTextBox1.Text;
            Transactions transactions = new Transactions();
            System.Data.SqlClient.SqlDataAdapter adapter = transactions.GetDebtorsOnly(searched_name);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
