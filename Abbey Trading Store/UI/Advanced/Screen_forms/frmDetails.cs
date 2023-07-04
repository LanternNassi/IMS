using Abbey_Trading_Store.DAL;
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
    public partial class frmDetails : Form
    {
        public frmDetails()
        {
            InitializeComponent();

            TransactionDetail TD = new TransactionDetail();
            lbltop.Text = frmTransactions.lblName;
            lbl2.Text = "( " + frmTransactions.date.ToString() + " )";

            //Creating time value for overlapping conditions where processing time is more than one second
            DateTime overlap_time = frmTransactions.date.AddSeconds(2);

            DataTable dt = TD.GetAllTransactionDetailsAppropriately(lbltop.Text, frmTransactions.transaction_id);
            DataTable dts = new DataTable();
            dts.Columns.Add("Product_name");
            dts.Columns.Add("rate");
            dts.Columns.Add("Qty");
            dts.Columns.Add("Total");
            dts.Columns.Add("dea_cust_name");
            dts.Columns.Add("added_date");
            dts.Columns.Add("added_by");
            dts.Columns.Add("Profit");
            //for (int i = 0; i <= (dt.Rows.Count-1); i++)
            //{
            //    //Getting the date from the data row clicked by the user
            //    string t = dt.Rows[i][5].ToString();

            //    //Converting the date got into Date Time for the expected query 
            //    DateTime target_time = DateTime.Parse(t);

            //    //Checking if the transaction details satisfy one of the conditions where we give a deviation of one second(overlap_time)
            //    bool check_real_time = overlap_time == target_time || target_time == frmTransactions.date;

            //    if (check_real_time)
            //    {
            //        //Getting the values from the Get All Transaction Details Data table
            //        string p_name = dt.Rows[i][0].ToString();
            //        string rate = dt.Rows[i][1].ToString();
            //        string Qty = dt.Rows[i][2].ToString();
            //        string Total = dt.Rows[i][3].ToString();
            //        string dea_cust_name = dt.Rows[i][4].ToString();
            //        string added_date = dt.Rows[i][5].ToString();
            //        string added_by = dt.Rows[i][6].ToString();
            //        string profit = dt.Rows[i][7].ToString();

            //        //Adding the row filtered to the data table for display
            //        dts.Rows.Add(p_name, rate, Qty, Total, dea_cust_name, added_date, added_by,profit);
            //    }
            //    else
            //    {


            //    }

            //}
            print = TD.GetAllTransactionDetailsAppropriately(lbltop.Text, frmTransactions.transaction_id);
            filter = dt;
            dgv_TD.DataSource = dt;
        }
        DataTable print = new DataTable();
        DataTable filter = new DataTable();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmDetails_Load(object sender, EventArgs e)
        {
            

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            bool isSuccess = Transactions.DeleteTransaction_2(frmTransactions.transaction_id);
            if (isSuccess)
            {
                MessageBox.Show("Transaction deleted successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("An error occured. Try again later");
            }
            Cursor = Cursors.Default;
        }
    }
}
