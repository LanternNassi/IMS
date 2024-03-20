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
using Abbey_Trading_Store.DAL.Helpers;

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    public partial class frmExpenditures : Form
    {
        public frmExpenditures()
        {
            InitializeComponent();
        }

        DataTable utilities = new DataTable();
        DataTable Payments = new DataTable();
        DataTable Benefits = new DataTable();
        DataTable mis = new DataTable();


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

            // Calculations for the DGVs
            Utility_dgv.Height = Payment_dgv.Height = Benefit_dgv.Height = mis_dgv.Height = Convert.ToInt32(0.75 * panel7.Height);
            panel18.Height = panel19.Height = panel20.Height = panel21.Height = panel7.Height - (panel13.Height + Utility_dgv.Height);

            //Accounting for the panel 14 error
            panel14.Height = Payment_dgv.Height + panel18.Height;

            //Accounting for the graphs 
            panel22.Height = panel24.Height = panel26.Height = panel28.Height = Convert.ToInt32(panel12.Height * 0.9);

            panel23.Height = panel25.Height = panel27.Height = panel29.Height = Convert.ToInt32(panel22.Height * 0.86);
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

        private int total_sum(DataTable dt)
        {
            int total = 0;
            foreach (DataRow dr in dt.Rows)
            {
                total += Convert.ToInt32(dr[2]);
            }
            return total;
        }

        private int overall_sum()
        {
            int total = 0;
            //Utilities
            foreach(DataRow dr in utilities.Rows)
            {
                total += Convert.ToInt32(dr[2]);
            }

            //Payments
            foreach(DataRow dr in Payments.Rows)
            {
                total += Convert.ToInt32(dr[2]);
            }
            //Benefits 
            foreach(DataRow dr in Benefits.Rows)
            {
                total += Convert.ToInt32(dr[2]);
            }
            //mis
            foreach(DataRow dr in mis.Rows)
            {
                total += Convert.ToInt32(dr[2]);
            }


            return total;

        }

        

        public void Load_data()
        {

            ExpCategories ov_category = new ExpCategories();


            //Working on the utilities
            ExpCategories utility_category = new ExpCategories(1);
            SqlDataAdapter utility_adapter = utility_category.Select();
            DataTable utility_dt = new DataTable();
            utility_adapter.Fill(utility_dt);
            utility_dt.Rows.Add(0, "All", "", "", "", DateTime.Now);
            comboBox1.DataSource = utility_dt;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.SelectedIndex = comboBox1.Items.Count -1;
            //Working on the charts
            chart2.Series["S2"].Points.Clear();
            DataTable utility_graph = ov_category.ExpenditureSummaryOverview(1);
            for (int i = 0; i < utility_graph.Rows.Count; i++)
            {
                //MessageBox.Show(utility_graph.Rows[i][1].ToString(), utility_graph.Rows[i][0].ToString());
                chart2.Series["S2"].Points.AddXY(utility_graph.Rows[i][1].ToString(), Convert.ToInt32(utility_graph.Rows[i][0].ToString()));
            }



            //Working on the Payments
            ExpCategories payment_category = new ExpCategories(2);
            SqlDataAdapter payment_adapter = payment_category.Select();
            DataTable payment_dt = new DataTable();
            payment_adapter.Fill(payment_dt);
            payment_dt.Rows.Add(0, "All", "", "", "", DateTime.Now);
            comboBox2.DataSource = payment_dt;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "ID";
            comboBox2.SelectedIndex = comboBox2.Items.Count - 1;
            //Working on the charts
            DataTable payment_graph = ov_category.ExpenditureSummaryOverview(2);
            chart1.Series["S2"].Points.Clear();
            for (int i = 0; i < payment_graph.Rows.Count; i++)
            {
                //MessageBox.Show(utility_graph.Rows[i][1].ToString(), utility_graph.Rows[i][0].ToString());
                chart1.Series["S2"].Points.AddXY(payment_graph.Rows[i][1].ToString(), Convert.ToInt32(payment_graph.Rows[i][0].ToString()));
            }


            //Working on the benefits
            ExpCategories benefit_category = new ExpCategories(3);
            SqlDataAdapter benefit_adapter = benefit_category.Select();
            DataTable benefit_dt = new DataTable();
            benefit_adapter.Fill(benefit_dt);
            benefit_dt.Rows.Add(0, "All", "", "", "", DateTime.Now);
            comboBox3.DataSource = benefit_dt;
            comboBox3.DisplayMember = "Name";
            comboBox3.ValueMember = "ID";
            comboBox3.SelectedIndex = comboBox3.Items.Count - 1;
            //Working on the charts
            DataTable benefit_graph = ov_category.ExpenditureSummaryOverview(3);
            chart3.Series["S2"].Points.Clear();
            for (int i = 0; i < benefit_graph.Rows.Count; i++)
            {
                //MessageBox.Show(utility_graph.Rows[i][1].ToString(), utility_graph.Rows[i][0].ToString());
                chart3.Series["S2"].Points.AddXY(benefit_graph.Rows[i][1].ToString(), Convert.ToInt32(benefit_graph.Rows[i][0].ToString()));
            }


            //Working on the miscellaneuos
            ExpCategories mis_category = new ExpCategories(4);
            SqlDataAdapter mis_adapter = mis_category.Select();
            DataTable mis_dt = new DataTable();
            mis_adapter.Fill(mis_dt);
            mis_dt.Rows.Add(0, "All", "", "", "", DateTime.Now);
            comboBox4.DataSource = mis_dt;
            comboBox4.DisplayMember = "Name";
            comboBox4.ValueMember = "ID";
            comboBox4.SelectedIndex = comboBox4.Items.Count - 1;

            //Working on the charts
            DataTable mis_graph = ov_category.ExpenditureSummaryOverview(4);
            chart4.Series["S2"].Points.Clear();
            for (int i = 0; i < mis_graph.Rows.Count; i++)
            {
                //MessageBox.Show(utility_graph.Rows[i][1].ToString(), utility_graph.Rows[i][0].ToString());
                chart4.Series["S2"].Points.AddXY(mis_graph.Rows[i][1].ToString(), Convert.ToInt32(mis_graph.Rows[i][0].ToString()));
            }

            //Overall total
            int overall_total = overall_sum();
            label4.Text = "shs." + overall_total.ToString("N0");


        }

        private void frmExpenditures_Load(object sender, EventArgs e)
        {
            Load_data();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count > 0 && (comboBox1.SelectedValue.GetType() == typeof(int)))
            {
                ExpendituresDAL utility_exp = new ExpendituresDAL(Convert.ToInt32(comboBox1.SelectedValue), 1);
                SqlDataAdapter utility_adapter_2 = utility_exp.Select();
                DataTable utility_dt_2 = new DataTable();
                utility_adapter_2.Fill(utility_dt_2);
                utilities = utility_dt_2;
                Utility_dgv.DataSource = MoneyFormatter.formatDT(utility_dt_2.Copy(), new int[] { 2 });

                int utility_sum = total_sum(utility_dt_2);
                label13.Text = "Total shs." + utility_sum.ToString("N0");

            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Items.Count > 0 && (comboBox2.SelectedValue.GetType() == typeof(int)))
            {
                ExpendituresDAL payment_exp = new ExpendituresDAL(Convert.ToInt32(comboBox2.SelectedValue), 2);
                SqlDataAdapter payment_adapter_2 = payment_exp.Select();
                DataTable payment_dt_2 = new DataTable();
                payment_adapter_2.Fill(payment_dt_2);
                Payments = payment_dt_2;
                Payment_dgv.DataSource = MoneyFormatter.formatDT(payment_dt_2.Copy() , new int[] {2});

                int payment_sum = total_sum(payment_dt_2);
                label12.Text = "Total shs." + payment_sum.ToString("N0");

            }
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Items.Count > 0 && (comboBox3.SelectedValue.GetType() == typeof(int)))
            {
                ExpendituresDAL benefit_exp = new ExpendituresDAL(Convert.ToInt32(comboBox3.SelectedValue), 3);
                SqlDataAdapter benefit_adapter_2 = benefit_exp.Select();
                DataTable benefit_dt_2 = new DataTable();
                benefit_adapter_2.Fill(benefit_dt_2);
                Benefits = benefit_dt_2;
                Benefit_dgv.DataSource = MoneyFormatter.formatDT(benefit_dt_2.Copy() , new int[] {2});

                int benefit_sum = total_sum(benefit_dt_2);
                label14.Text = "Total shs." + benefit_sum.ToString("N0");
            }

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Items.Count > 0 && (comboBox4.SelectedValue.GetType() == typeof(int)))
            {
                ExpendituresDAL mis_exp = new ExpendituresDAL(Convert.ToInt32(comboBox4.SelectedValue), 4);
                SqlDataAdapter mis_adapter_2 = mis_exp.Select();
                DataTable mis_dt_2 = new DataTable();
                mis_adapter_2.Fill(mis_dt_2);
                mis = mis_dt_2;
                mis_dgv.DataSource = MoneyFormatter.formatDT(mis_dt_2.Copy(), new int[] { 2 });

                int mis_sum = total_sum(mis_dt_2);
                label15.Text = "Total shs." + mis_sum.ToString("N0");
            }
        }
    }
}
