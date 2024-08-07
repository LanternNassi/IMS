﻿using Abbey_Trading_Store.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;

using System.Windows.Forms;
using Abbey_Trading_Store.DAL.DAL_Properties;
using System.Data.SqlClient;
using Abbey_Trading_Store.DAL.Helpers;

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    public partial class frmDebts : Form
    {
        public frmDebts()
        {
            InitializeComponent();

            Transactions transaction = new Transactions();
            dynamic adapter = transaction.GetAllDebtsCreditsAppropriately("Customer");
            DataTable dt = new DataTable();
            Connection().Open();
            adapter.Fill(dt);
            active_debts_dt = dt;
            DebtsDGV.DataSource = MoneyFormatter.formatDT(dt.Copy() , new int[] { 3, 5, 7, 8, 9 });
            Connection().Close();

            long unsettled_amount = 0;
            long settled_amount = 0;
            foreach (DataRow dr in dt.Rows)
            {
                unsettled_amount += (Convert.ToInt64(dr[8].ToString()) * -1);
                settled_amount += (Convert.ToInt64(dr[7].ToString()));
            }

            overall_settled_amount = settled_amount;
            overall_unsettled_amount = unsettled_amount;

            // Updating the progress bars
            if (overall_unsettled_amount != 0)
            {
                //circularProgressBar1.Value = (unsettled_amount / overall_unsettled_amount) * 100;
                //circularProgressBar1.Text = ((unsettled_amount / overall_unsettled_amount) * 100).ToString() + "%";

                //circularProgressBar2.Value = (settled_amount / overall_settled_amount) * 100;
                //circularProgressBar2.Text = ((settled_amount / overall_settled_amount) * 100).ToString() + "%";
            }
            else
            {
                //circularProgressBar1.Value = 0;
                //circularProgressBar1.Text = "0%";

                //circularProgressBar2.Value = 0;
                //circularProgressBar2.Text = "0%";

            }
            


            label11.Text = "shs." + unsettled_amount.ToString("N0");
            label10.Text = "shs." + settled_amount.ToString("N0");

        }
        int row_overall = 0;
        string rem_amount = "";

        long overall_settled_amount = 0;
        long overall_unsettled_amount = 0;

        DataTable active_debts_dt = new DataTable();

        public void calculate_debt(DataTable dt)
        {
            //Calculating unsettled debts
            long unsettled_amount = 0;
            long settled_amount = 0;
            foreach (DataRow dr in dt.Rows)
            {
                unsettled_amount += (Convert.ToInt64(dr[8].ToString()) * -1);
                settled_amount += (Convert.ToInt64(dr[7].ToString()));
            }

            // Updating the progress bars
            if(overall_unsettled_amount != 0)
            {
                //circularProgressBar1.Value = Convert.ToInt32((Convert.ToDecimal(unsettled_amount) / Convert.ToDecimal(overall_unsettled_amount)) * 100);
                //circularProgressBar1.Text = Convert.ToInt32((Convert.ToDecimal(unsettled_amount) / Convert.ToDecimal(overall_unsettled_amount)) * 100).ToString() + "%";

                //circularProgressBar2.Value = Convert.ToInt32((Convert.ToDecimal(settled_amount) / Convert.ToDecimal(overall_settled_amount)) * 100);
                //circularProgressBar2.Text = Convert.ToInt32((Convert.ToDecimal(settled_amount) / Convert.ToDecimal(overall_settled_amount)) * 100).ToString() + "%";
            }else
            {
                //circularProgressBar1.Value = 0;
                //circularProgressBar1.Text = "0%";

                //circularProgressBar2.Value = 0;
                //circularProgressBar2.Text = "0%";

            }
            

            label11.Text = "shs." + unsettled_amount.ToString("N0");
            label10.Text = "shs." + settled_amount.ToString("N0");
        }
        

        public dynamic Connection()
        {
            if(Env.mode == 1)
            {
                OleDbConnection conn = new OleDbConnection(Env.local_database_conn_string);
                return conn;

            }
            else
            {
                SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
                return conn;
            }
        }
        

        private async void materialButton2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (id.Text != "")
            {
                Transactions transaction = new Transactions();

                //Computing the remaining amount
                bool cleared = false;
                bool Success = false;
                int total = Int32.Parse(active_debts_dt.Rows[row_overall][3].ToString());
                int new_return_amount = ((Int32.Parse(rem_amount) * -1) - Int32.Parse(PaidAmount.Text));
                if (new_return_amount == 0)
                {
                    cleared = true;
                }
                if (new_return_amount < 0)
                {
                    string message_paid = "The value entered is greater than the expected value ?";
                    string title_paid = "Confirmation";
                    MessageBoxButtons buttons_paid = MessageBoxButtons.YesNo;
                    DialogResult result_paid = MessageBox.Show(message_paid, title_paid, buttons_paid);
                    if (result_paid == DialogResult.Yes)
                    {
                        Success = await transaction.UpdatePaymentAppropriately(Int32.Parse(id.Text), (new_return_amount * -1), (total - new_return_amount), cleared);

                    }
                    else
                    {
                        return;
                    }
                }
                else
                {

                    Success = await transaction.UpdatePaymentAppropriately(Int32.Parse(id.Text), (new_return_amount * -1), (total - new_return_amount), cleared);

                }
                //Inserting the track
                string[] args = {
                                id.Text,
                                PaidAmount.Text,
                                Login_form.user,
                            };
                bool isSuccess = await transaction.InsertTransactionTrackAppropriately(args);

                if (isSuccess)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Inserted successfully");
                }
                else
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Track not entered");
                }

                //Confirmation
                if (isSuccess && Success)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Updated successfully");
                    //Refreshing tracks
                    dynamic adapter = transaction.GetAllTrackDataAppropriately(Int32.Parse(id.Text));
                    DataTable dttrack = new DataTable();
                    Connection().Open();
                    adapter.Fill(dttrack);
                    TRACKDGV.DataSource = MoneyFormatter.formatDT(dttrack , new int[] {2});
                    //Refreshing debts
                    dynamic adapter2 = transaction.GetAllDebtsCreditsAppropriately("Customer");
                    DataTable dt = new DataTable();
                    adapter2.Fill(dt);

                    active_debts_dt = dt;
                    DebtsDGV.DataSource = MoneyFormatter.formatDT(dt.Copy(), new int[] { 3, 5, 7, 8, 9 }); ;
                    Connection().Close();
                }
                Cursor = Cursors.Default;

            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Please select a Debtor");
            }
            Cursor = Cursors.Default;
        }

        

        private void frmDebts_Load(object sender, EventArgs e)
        {
            
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            try
            {
                TransactionDetail Td = new TransactionDetail();
                Cursor = Cursors.WaitCursor;
                Abbey_Trading_Store.Reports.Invoice_Report.Invoice dataset = new Reports.Invoice_Report.Invoice();
                dynamic adapter1 = Td.GetTransactionAppropriately(Int32.Parse(id.Text));
                dynamic adapter2 = Td.GetdetailsAppropriately(Int32.Parse(id.Text));
                dynamic adapter3 = DAL.BusinessAccount.Select();

                
                adapter1.Fill(dataset, "Overall_data");
                adapter2.Fill(dataset, "Invoice_data");
                adapter3.Fill(dataset, "DataTable_Company");

                ReportDataSource datasource1 = new ReportDataSource("DataSet1", dataset.Tables[0]);
                ReportDataSource datasource2 = new ReportDataSource("DataSet2", dataset.Tables[1]);
                ReportDataSource datacource3 = new ReportDataSource("Company", dataset.Tables[2]);

                ReportDataSource[] list = { datasource1, datasource2, datacource3 };
                ReportView form = new ReportView(list, "Abbey_Trading_Store.Reports.Invoice_Report.Invoice.rdlc");
                form.Show();
                Cursor = Cursors.Default;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Please select an entry");
            }
            finally
            {
                Cursor = Cursors.Default;

            }

        }

        private void DebtsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            row_overall = e.RowIndex;
            if (row == 0 || row > 0)
            {
                id.Text = DebtsDGV.Rows[row].Cells[0].Value.ToString();
                CustomerName.Text = DebtsDGV.Rows[row].Cells[2].Value.ToString();
                rem_amount = DebtsDGV.Rows[row].Cells[8].Value.ToString();
                RemainAmount.Text = (Convert.ToInt32(DebtsDGV.Rows[row].Cells[8].Value)*-1).ToString("N0");
                if (id.Text != "")
                {
                    // Loading the changes track dgv
                    Transactions transaction = new Transactions();
                    dynamic adapter = transaction.GetAllTrackDataAppropriately(Int32.Parse(id.Text));
                    DataTable dttrack = new DataTable();
                    Connection().Open();
                    adapter.Fill(dttrack);
                    TRACKDGV.DataSource = dttrack;
                    Connection().Close();
                }
                
            }
        }

        private void DebtsDGV_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            row_overall = e.RowIndex;
            if (row == 0 || row > 0)
            {
                id.Text = active_debts_dt.Rows[row][0].ToString();
                CustomerName.Text = active_debts_dt.Rows[row][2].ToString();
                RemainAmount.Text = "shs." + (Convert.ToInt32(active_debts_dt.Rows[row][8]) * -1).ToString("N0");
                rem_amount = active_debts_dt.Rows[row][8].ToString();
                if (id.Text != "")
                {
                    // Loading the changes track dgv
                    Transactions transaction = new Transactions();
                    dynamic adapter = transaction.GetAllTrackDataAppropriately(Int32.Parse(id.Text));
                    DataTable dttrack = new DataTable();
                    Connection().Open();
                    adapter.Fill(dttrack);
                    TRACKDGV.DataSource = MoneyFormatter.formatDT(dttrack.Copy() , new int[] {2});
                    Connection().Close();
                }

            }

        }

        private void searchtxtbx_TextChanged(object sender, EventArgs e)
        {
            if (searchtxtbx.Text != "")
            {
                Transactions transact = new Transactions();
                DataTable dt = transact.SearchCreditorsDebtors_2(searchtxtbx.Text);
                active_debts_dt = dt;
                DebtsDGV.DataSource = MoneyFormatter.formatDT(dt.Copy(), new int[] { 3, 5, 7, 8, 9 }); ;
                calculate_debt(dt);
            }
            else
            {
                Transactions transaction = new Transactions();
                dynamic adapter = transaction.GetAllDebtsCreditsAppropriately("Customer");
                DataTable dt = new DataTable();
                Connection().Open();
                adapter.Fill(dt);
                active_debts_dt = dt;
                DebtsDGV.DataSource = MoneyFormatter.formatDT(dt.Copy(), new int[] { 3, 5, 7, 8, 9 }); ;
                Connection().Close();
                calculate_debt(dt);

            }
            
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void frmDebts_Layout(object sender, LayoutEventArgs e)
        {
            panel1.Width = Convert.ToInt32(Dashboard.PnlContainer.Width * 0.25);

            panel5.Height = panel6.Height = panel7.Height = panel8.Height = panel9.Height = Dashboard.PnlContainer.Height / 5;

            panel4.Height = Convert.ToInt32(0.22 * Dashboard.PnlContainer.Height);

            panel3.Height = panel2.Height = Convert.ToInt32(0.34 * Dashboard.PnlContainer.Height);

            panel10.Height = panel11.Height = (Dashboard.PnlContainer.Height - (panel4.Height + panel2.Height + panel3.Height)) / 2;

            panel12.Width = panel15.Width = Convert.ToInt32(0.55 * panel4.Width)/2;

            panel13.Width = panel14.Width = (panel4.Width - (panel12.Width * 2)) / 2;


        }

        
    }
}
