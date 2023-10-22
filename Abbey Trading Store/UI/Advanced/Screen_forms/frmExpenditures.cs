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
    public partial class frmExpenditures : Form
    {
        public frmExpenditures()
        {
            InitializeComponent();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AddExpenditure form = new AddExpenditure(1);
            form.Show();
;
        }

        private void frmExpenditures_Layout(object sender, LayoutEventArgs e)
        {
            //Applying the layout calculations (the hustle...)

            panel7.Height = panel11.Height = Convert.ToInt32(Dashboard.PnlContainer.Height * 0.8)/2;
            panel1.Height = Convert.ToInt32(Dashboard.PnlContainer.Height * 0.1);

            panel5.Height = panel6.Height = (Dashboard.PnlContainer.Height - ((panel7.Height * 2) + panel1.Height))/2;


            //Layout calculations for panel 1
            panel3.Width = Convert.ToInt32(0.45 * Dashboard.PnlContainer.Width);
            panel2.Width = panel4.Width = (Dashboard.PnlContainer.Width - (panel3.Width)) / 2;


            //Layout calculations for panel 7
            panel8.Width = panel9.Width = panel10.Width = Dashboard.PnlContainer.Width / 3;

            //Layout for panel 11
            panel12.Width = panel8.Width;
            flowLayoutPanel1.Width = Dashboard.PnlContainer.Width - panel12.Width;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AddExpenditure form = new AddExpenditure(2);
            form.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AddExpenditure form = new AddExpenditure(3);
            form.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            AddExpenditure form = new AddExpenditure(4);
            form.Show();
        }

        private void frmExpenditures_Load(object sender, EventArgs e)
        {
            //Working on the utilities
            ExpCategories utility_category = new ExpCategories(1);
            SqlDataAdapter utility_adapter= utility_category.Select();
            DataTable utility_dt = new DataTable();
            utility_adapter.Fill(utility_dt);
            comboBox1.DataSource = utility_dt;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";


            //Working on the Payments
            ExpCategories payment_category = new ExpCategories(2);
            SqlDataAdapter payment_adapter = payment_category.Select();
            DataTable payment_dt = new DataTable();
            payment_adapter.Fill(payment_dt);
            comboBox2.DataSource = payment_dt;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";

            //Working on the benefits
            ExpCategories benefit_category = new ExpCategories(3);
            SqlDataAdapter benefit_adapter = benefit_category.Select();
            DataTable benefit_dt = new DataTable();
            benefit_adapter.Fill(benefit_dt);
            comboBox3.DataSource = benefit_dt;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "ID";


            //Working on the miscellaneuos
            ExpCategories mis_category = new ExpCategories(4);
            SqlDataAdapter mis_adapter = mis_category.Select();
            DataTable mis_dt = new DataTable();
            mis_adapter.Fill(mis_dt);
            comboBox4.DataSource = mis_dt;
            comboBox4.DisplayMember = "Name";
            comboBox4.ValueMember = "ID";




        }
    }
}
