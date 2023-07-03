using Abbey_Trading_Store.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public frmTransactions()
        {
            InitializeComponent();

            DataTable dt = Ts.DisplayAllTransactionsAppropriately();
            flexible = dt;
            dataGridView1.DataSource = dt;
            int purchase_holder = 0;
            int sales_holder = 0;
            int profit_holder = 0;
            for (int i = 0; (i <= flexible.Rows.Count - 1); i++)
            {
                string paid = flexible.Rows[i][10].ToString();
                if (flexible.Rows[i][1].ToString() == "Customer")
                {
                    if (paid == "True" || paid == "Cleared")
                    {
                        sales_holder += int.Parse(flexible.Rows[i][3].ToString());
                    }

                }
                else
                {
                    purchase_holder += int.Parse(flexible.Rows[i][3].ToString());

                }
                try
                {
                    if (paid == "True" || paid == "Cleared")
                    {
                        profit_holder += int.Parse(flexible.Rows[i][9].ToString());
                    }
                }
                catch (Exception ex)
                {

                }


            }
            txtbx_total.Text = "Shs. " + purchase_holder.ToString("N0");
            txtbx_sales.Text = "Shs. " + sales_holder.ToString("N0");
            txtbx_discounts.Text = "Shs. " + profit_holder.ToString("N0");
        }
        Transactions Ts = new Transactions();
        public static string lblName;
        public static DateTime date;
        public static int transaction_id;
        DataTable flexible = new DataTable();

        private void frmTransactions_Load(object sender, EventArgs e)
        {
            

        }

        private void Show_all_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DataTable dt_showAll = Ts.DisplayAllTransactionsAppropriately();
            flexible = dt_showAll;
            dataGridView1.DataSource = flexible;
            int purchase_holder = 0;
            int sales_holder = 0;
            int profit_holder = 0;
            for (int i = 0; (i <= flexible.Rows.Count - 1); i++)
            {
                string paid = flexible.Rows[i][10].ToString();
                if (flexible.Rows[i][1].ToString() == "Customer")
                {
                    if (paid == "True" || paid == "Cleared")
                    {
                        sales_holder += int.Parse(flexible.Rows[i][3].ToString());
                    }

                }
                else
                {
                    purchase_holder += int.Parse(flexible.Rows[i][3].ToString());

                }
                try
                {
                    if (paid == "True" || paid == "Cleared")
                    {
                        profit_holder += int.Parse(flexible.Rows[i][9].ToString());
                    }
                }
                catch (Exception ex)
                {

                }
            }
            txtbx_total.Text = "Shs. " + purchase_holder.ToString("N0");
            txtbx_sales.Text = "Shs. " + sales_holder.ToString("N0");
            txtbx_discounts.Text = "Shs. " + profit_holder.ToString("N0");
            Cateory_combobox.Text = "";
            checkBox1.Checked = false;
            Cursor = Cursors.Default;
        }

        private void Cateory_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = "Dealer";
            if (Cateory_combobox.Text == "Sales")
            {
                type = "Customer";

            }
            else if (Cateory_combobox.Text == "Purchase")
            {
                type = "Dealer";
            }
            // Defining a holder table to temporarily hold data during filtering
            DataTable holder = new DataTable();
            holder.Columns.Add("ID");
            holder.Columns.Add("type");
            holder.Columns.Add("dea_cust_name");
            holder.Columns.Add("grandTotal");
            holder.Columns.Add("transaction_date");
            holder.Columns.Add("discount");
            holder.Columns.Add("added_by");
            holder.Columns.Add("Paid_amount");
            holder.Columns.Add("Return_amount");
            holder.Columns.Add("Profit");
            holder.Columns.Add("Paid");
            holder.Columns.Add("Taken");

            for (int i = 0; i <= (flexible.Rows.Count - 1); i++)
            {

                string kind = flexible.Rows[i][1].ToString();
                if (type == kind)
                {
                    string id = flexible.Rows[i][0].ToString();
                    string types = flexible.Rows[i][1].ToString();
                    string name = flexible.Rows[i][2].ToString();
                    string grandTotal = flexible.Rows[i][3].ToString();
                    string date_time = flexible.Rows[i][4].ToString();
                    string discount = flexible.Rows[i][5].ToString();
                    string added_by = flexible.Rows[i][6].ToString();
                    string paid_amount = flexible.Rows[i][7].ToString();
                    string return_amount = flexible.Rows[i][8].ToString();
                    string profit = flexible.Rows[i][9].ToString();
                    string paid = flexible.Rows[i][10].ToString();
                    string taken = flexible.Rows[i][11].ToString();

                    // Add the data to the holder data table
                    holder.Rows.Add(id, types, name, grandTotal, date_time, discount, added_by, paid_amount, return_amount, profit, paid, taken);

                }
                else
                {

                }
            }

            flexible = holder;
            dataGridView1.DataSource = flexible;
            int purchase_holder = 0;
            int sales_holder = 0;
            int profit_holder = 0;
            for (int i = 0; (i <= flexible.Rows.Count - 1); i++)
            {
                string paid = flexible.Rows[i][10].ToString();
                if (flexible.Rows[i][1].ToString() == "Customer")
                {

                    if (paid == "True" || paid == "Cleared")
                    {
                        sales_holder += int.Parse(flexible.Rows[i][3].ToString());
                    }

                }
                else
                {
                    purchase_holder += int.Parse(flexible.Rows[i][3].ToString());

                }
                try
                {
                    if (paid == "True" || paid == "Cleared")
                    {
                        profit_holder += int.Parse(flexible.Rows[i][9].ToString());

                    }
                }
                catch (Exception ex)
                {

                }
            }
            txtbx_total.Text = "Shs. " + purchase_holder.ToString("N0");
            txtbx_sales.Text = "Shs. " + sales_holder.ToString("N0");
            txtbx_discounts.Text = "Shs. " + profit_holder.ToString("N0");

        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // Get the date from the date time picker and convert it into the appropriate string
                string initial_date = dtp_transactions.Value.ToString("MM/dd/yyyy");
                DataTable holder = new DataTable();
                holder.Columns.Add("ID");
                holder.Columns.Add("type");
                holder.Columns.Add("dea_cust_name");
                holder.Columns.Add("grandTotal");
                holder.Columns.Add("transaction_date");
                holder.Columns.Add("discount");
                holder.Columns.Add("added_by");
                holder.Columns.Add("Paid_amount");
                holder.Columns.Add("Return_amount");
                holder.Columns.Add("Profits");
                holder.Columns.Add("Paid");
                holder.Columns.Add("Taken");

                for (int i = 0; i <= (flexible.Rows.Count - 1); i++)
                {
                    DateTime data_date = DateTime.Parse(flexible.Rows[i][4].ToString());
                    string date = data_date.ToString("MM/dd/yyyy");
                    if (initial_date == date)
                    {
                        string id = flexible.Rows[i][0].ToString();
                        string type = flexible.Rows[i][1].ToString();
                        string name = flexible.Rows[i][2].ToString();
                        string grandTotal = flexible.Rows[i][3].ToString();
                        string date_time = flexible.Rows[i][4].ToString();
                        string discount = flexible.Rows[i][5].ToString();
                        string added_by = flexible.Rows[i][6].ToString();
                        string paid_amount = flexible.Rows[i][7].ToString();
                        string return_amount = flexible.Rows[i][8].ToString();
                        string profits = flexible.Rows[i][9].ToString();
                        string paid = flexible.Rows[i][10].ToString();
                        string taken = flexible.Rows[i][11].ToString();

                        // Add the data to the holder data table
                        holder.Rows.Add(id, type, name, grandTotal, date_time, discount, added_by, paid_amount, return_amount, profits, paid, taken);

                    }
                    else
                    {

                    }
                }
                if (holder.Rows.Count > 0)
                {
                    flexible = holder;
                    dataGridView1.DataSource = flexible;
                    int purchase_holder = 0;
                    int sales_holder = 0;
                    int profit_holder = 0;
                    for (int i = 0; (i <= flexible.Rows.Count - 1); i++)
                    {
                        string paid = flexible.Rows[i][10].ToString();
                        if (flexible.Rows[i][1].ToString() == "Customer" && (flexible.Rows[i][10].ToString() == "True" || flexible.Rows[i][10].ToString() == "Cleared"))
                        {
                            if (paid == "True" || paid == "Cleared")
                            {
                                sales_holder += int.Parse(flexible.Rows[i][3].ToString());
                            }


                        }
                        else if (flexible.Rows[i][1].ToString() == "Dealer")
                        {
                            purchase_holder += int.Parse(flexible.Rows[i][3].ToString());

                        }
                        try
                        {
                            if (flexible.Rows[i][10].ToString() == "True" || flexible.Rows[i][10].ToString() == "Cleared")
                            {
                                if(paid == "True" || paid == "Cleared")
                                {
                                    profit_holder += int.Parse(flexible.Rows[i][9].ToString());
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    txtbx_total.Text = "Shs. " + purchase_holder.ToString("N0");
                    txtbx_sales.Text = "Shs. " + sales_holder.ToString("N0");
                    txtbx_discounts.Text = "Shs. " + profit_holder.ToString("N0");
                    Cateory_combobox.Text = "";
                }
                else
                {

                    dataGridView1.DataSource = holder;
                    int purchase_holder = 0;
                    int sales_holder = 0;
                    int profit_holder = 0;
                    txtbx_total.Text = "Shs. " + purchase_holder.ToString("N0");
                    txtbx_sales.Text = "Shs. " + sales_holder.ToString("N0");
                    txtbx_discounts.Text = "Shs. " + profit_holder.ToString("N0");
                    Cateory_combobox.Text = "";

                }



            }
            else
            {

            }
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
                //TransactionDetail Td = new TransactionDetail();
                //dts = Td.GetTransactionDetail(name);
                frmDetails TD = new frmDetails();
                TD.Show();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
