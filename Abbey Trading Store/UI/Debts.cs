using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Data.OleDb;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Abbey_Trading_Store.DAL;
using Abbey_Trading_Store.Reports.Invoice_Report;
using DGVPrinterHelper;

namespace Abbey_Trading_Store.UI
{
    public partial class Debts : Form
    {
        public Debts()
        {
            InitializeComponent();
        }
        int row_overall = 0;
        const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
        OleDbConnection conn = new OleDbConnection(connection);
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Debts_Load(object sender, EventArgs e)
        {
            Transactions transaction = new Transactions();
             OleDbDataAdapter adapter = transaction.GetAllDebtsCredits("Customer");
             DataTable dt = new DataTable();
             conn.Open();
             adapter.Fill(dt);
             DebtsDGV.DataSource = dt;
             conn.Close();
        }

        private void DebtsDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            row_overall = e.RowIndex;
            if (row == 0 || row > 0)
            {
                id.Text = DebtsDGV.Rows[row].Cells[0].Value.ToString();
                CustomerName.Text = DebtsDGV.Rows[row].Cells[2].Value.ToString();
                RemainAmount.Text = DebtsDGV.Rows[row].Cells[8].Value.ToString();

                // Loading the changes track dgv
                Transactions transaction = new Transactions();
                OleDbDataAdapter adapter = transaction.GetAllTrackData(Int32.Parse(id.Text));
                DataTable dttrack = new DataTable();
                conn.Open();
                adapter.Fill(dttrack);
                TRACKDGV.DataSource = dttrack;
                conn.Close();
            }
            
        }

        private async void Add_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (id.Text != "")
            {
                Transactions transaction = new Transactions();

                //Computing the remaining amount
                bool cleared = false;
                bool Success = false;
                int total = Int32.Parse(DebtsDGV.Rows[row_overall].Cells[3].Value.ToString());
                int new_return_amount = ((Int32.Parse(RemainAmount.Text) * -1) - Int32.Parse(PaidAmount.Text));
                if (new_return_amount == 0){
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
                        Success = transaction.UpdatePayment(Int32.Parse(id.Text), (new_return_amount * -1),(total-new_return_amount),cleared);
                        var resultserver1 = await transaction.UpdatePayment2(Int32.Parse(id.Text), (new_return_amount * -1), (total - new_return_amount), cleared);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {

                    Success = transaction.UpdatePayment(Int32.Parse(id.Text), (new_return_amount * -1), (total - new_return_amount), cleared);
                    var resultserver = await transaction.UpdatePayment2(Int32.Parse(id.Text), (new_return_amount * -1), (total - new_return_amount), cleared);

                }
                //Inserting the track
                string[] args = {
                                id.Text,
                                PaidAmount.Text,
                                Login_form.user,
                            };
                bool isSuccess = transaction.InsertTransactionTrack(args);
                var serverSuccess = await transaction.InsertTransactionTrack2(args);
                if (serverSuccess)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Server track inserted successfully");
                }
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
                    OleDbDataAdapter adapter = transaction.GetAllTrackData(Int32.Parse(id.Text));
                    DataTable dttrack = new DataTable();
                    conn.Open();
                    adapter.Fill(dttrack);
                    TRACKDGV.DataSource = dttrack;
                    //Refreshing debts
                    OleDbDataAdapter adapter2 = transaction.GetAllDebtsCredits("Customer");
                    DataTable dt = new DataTable();
                    adapter2.Fill(dt);
                    DebtsDGV.DataSource = dt;
                    conn.Close();
                }

            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Please select a Debtor");
            }
            Cursor = Cursors.Default;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Transactions transaction = new Transactions();  
            if (searchtxtbx.Text == "")
            {
                conn.Open();
                OleDbDataAdapter adapter2 = transaction.GetAllDebtsCredits("Customer");
                DataTable dt = new DataTable();
                adapter2.Fill(dt);
                DebtsDGV.DataSource = dt;
                conn.Close();

            }
            else
            {
                DataTable dt = transaction.SearchCreditorsDebtors("Customer", searchtxtbx.Text);
                DebtsDGV.DataSource = dt;


            }
        }

        public OleDbDataAdapter GetTransaction(int id)
        {
            conn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            string cmds = "SELECT * FROM Transactions WHERE ID = @id";
            OleDbCommand cmd = new OleDbCommand(cmds, conn);
            cmd.Parameters.AddWithValue("@id", id);
            adapter.SelectCommand = cmd;
            conn.Close();
            return adapter;
            
        }

        public OleDbDataAdapter Getdetails(int id)
        {
            conn.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            string cmds = "SELECT * FROM `Transaction Details` WHERE Invoice_id = @id";
            OleDbCommand cmd = new OleDbCommand(cmds, conn);
            cmd.Parameters.AddWithValue("@id", id);
            adapter.SelectCommand = cmd;
            conn.Close();
            return adapter;
        }

        private void Invoice_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Abbey_Trading_Store.Reports.Invoice_Report.Invoice dataset = new Reports.Invoice_Report.Invoice();
            OleDbDataAdapter adapter1 = GetTransaction(Int32.Parse(id.Text));
            OleDbDataAdapter adapter2 = Getdetails(Int32.Parse(id.Text));

            adapter1.Fill(dataset, "Overall_data");
            adapter2.Fill(dataset, "Invoice_data");

            ReportDataSource datasource1 = new ReportDataSource("DataSet1", dataset.Tables[0]);
            ReportDataSource datasource2 = new ReportDataSource("DataSet2", dataset.Tables[1]);
            ReportDataSource[] list = { datasource1, datasource2 };
            ReportView form = new ReportView(list);
            form.Show();
            Cursor = Cursors.Default;
        }

        private void PrintDebtors_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DGVPrinter Printer = new DGVPrinter();
            Printer.Title = "\r\n\r\n\r\n MMAK AGRO CHEMICALS Ltd \r\n\r\n";
            Printer.SubTitle = "Located at Busega Kampala \r\n Phone: 0754066646\r\n\r\n";
            Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            Printer.PageNumbers = true;
            Printer.PageNumberInHeader = false;
            Printer.PorportionalColumns = false;
            Printer.HeaderCellAlignment = StringAlignment.Near;
            Printer.Footer = "\r\n\r\n Report";
            Printer.FooterSpacing = 15;
            Printer.PrintDataGridView(DebtsDGV);
            Cursor = Cursors.Default;
        }

        private void Print_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DGVPrinter Printer = new DGVPrinter();
            Printer.Title = "\r\n\r\n\r\n MMAK AGRO CHEMICALS Ltd \r\n\r\n";
            Printer.SubTitle = "Located at Busega Kampala \r\n Phone: 0754066646\r\n\r\n";
            Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            Printer.PageNumbers = true;
            Printer.PageNumberInHeader = false;
            Printer.PorportionalColumns = false;
            Printer.HeaderCellAlignment = StringAlignment.Near;
            Printer.Footer = "\r\n\r\n Report for All the detailed Payment tracks";
            Printer.FooterSpacing = 15;
            Printer.PrintDataGridView(TRACKDGV);
            Cursor = Cursors.Default;
        }

        private void PaidAmount_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
