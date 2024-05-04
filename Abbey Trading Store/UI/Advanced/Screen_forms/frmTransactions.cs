using Abbey_Trading_Store.DAL;
using Abbey_Trading_Store.DAL.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    public partial class frmTransactions : Form
    {
        public readonly DbContext _dbcontext = new Base2();

        private int page_number = 1;
        private int offset = 0;
        private int per_page = 20;
        //var overall_number = _dbcontext.Set<Transaction>().Count();
        public frmTransactions()
        {
            InitializeComponent();

        }


        Transactions Ts = new Transactions();
        public static string lblName;
        public static DateTime date;
        public static int transaction_id;
        DataTable flexible = new DataTable();




        public void regenerate(
            bool next_page ,
            bool previous_page ,
            string type = "All" ,
            bool filter_date = false 
            )
        {
            Cursor = Cursors.WaitCursor;


            string computed_type = "All";
            if (type == "Sales")
            {
                computed_type = "Customer";

            } else if (type == "Purchase")
            {
                computed_type = "Dealer";
            }else
            {
                computed_type = "All";

            }

            var total_count = _dbcontext.Set<Transaction>().Count();

            int current_page = (offset / per_page) + 1;
            
            int total_pages = (int)Math.Ceiling(Convert.ToDecimal(total_count) / Convert.ToDecimal(per_page));
            pagination_info.Text = current_page.ToString() + "/" + total_pages.ToString();

            //Calculating pagination offset
            if (next_page)
            {
                if ((offset+per_page)>=total_count)
                {
                    MessageBox.Show("Reached end of the scroll");
                    Cursor = Cursors.Default;
                    return;
                }
                
                offset += per_page;
            }

            if (previous_page)
            {
                if (offset < 1)
                {
                    Cursor = Cursors.Default;
                    return;
                }
                offset -= per_page;
            }


            (DataTable trans_dt , DataTable dt) = Ts.DisplayTransactions(offset, per_page, computed_type , filter_date , dateTimePicker1.Value.Date , dtp_transactions.Value.Date.AddDays(1));


            dataGridView1.DataSource = MoneyFormatter.formatDT(trans_dt.Copy(), new int[] { 3, 5, 7, 8, 9 });

            long purchase_holder = 0;
            long sales_holder = 0;
            long profit_holder = 0;


            foreach (DataRow dr in dt.Rows)
            {
                if (dr[0].ToString() == "Customer")
                {
                    sales_holder = Convert.ToInt64(dr[1]);
                    profit_holder = Convert.ToInt64(dr[2]);
                }
                else
                {
                    purchase_holder = Convert.ToInt64(dr[1]);

                }
            }

            
            
            txtbx_total.Text = "Shs. " + purchase_holder.ToString("N0");
            txtbx_sales.Text = "Shs. " + sales_holder.ToString("N0");
            txtbx_discounts.Text = "Shs. " + profit_holder.ToString("N0");

            if (sales_holder != 0)
            {
                circularProgressBar2.Value = Convert.ToInt32((Convert.ToDecimal(profit_holder) / Convert.ToDecimal(sales_holder)) * 100);
            }
            else
            {
                circularProgressBar2.Value = 0;
            }

            circularProgressBar2.Text = Convert.ToString(circularProgressBar2.Value) + "%";

            Cursor = Cursors.Default;
        }

        

        private void frmTransactions_Load(object sender, EventArgs e)
        {
            regenerate(false, false);
        }


        private void Cateory_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            offset = 0;
            regenerate(false, false, Cateory_combobox.Text, checkBox1.Checked ? (true) : (false));
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            offset = 0;
            regenerate(false, false, Cateory_combobox.Text, checkBox1.Checked ? (true) : (false));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                string name = dataGridView1.Rows[row].Cells[2].Value.ToString();
                DateTime time = Convert.ToDateTime(dataGridView1.Rows[row].Cells[4].Value.ToString());
                transaction_id = int.Parse(dataGridView1.Rows[row].Cells[0].Value.ToString());
                lblName = name;
                date = time;
                frmDetails TD = new frmDetails();
                TD.Show();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void frmTransactions_Layout(object sender, LayoutEventArgs e)
        {
            panel2.Height = Convert.ToInt32(0.2 * Dashboard.PnlContainer.Height);

            panel1.Width = Convert.ToInt32(0.25 * panel2.Width);

            panel4.Width = panel5.Width = panel3.Width = panel6.Width = (panel2.Width - panel1.Width)/4;

            panel8.Height = Convert.ToInt32(0.07 * panel7.Height);

        }

        private void label2_Click(object sender, EventArgs e)
        {
            regenerate(true, false, Cateory_combobox.Text, checkBox1.Checked ? (true) : (false));
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            offset = 0;
            regenerate(false, false, Cateory_combobox.Text, checkBox1.Checked ? (true) : (false));
        }

        private void dtp_transactions_ValueChanged(object sender, EventArgs e)
        {
            offset = 0;
            regenerate(false, false, Cateory_combobox.Text, checkBox1.Checked ? (true) : (false));
        }

        private void prev_Click(object sender, EventArgs e)
        {
            regenerate(false, true, Cateory_combobox.Text, checkBox1.Checked ? (true) : (false));

        }
    }
}
