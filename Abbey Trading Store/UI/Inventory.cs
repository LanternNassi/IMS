using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL;
using System.Data.OleDb;
using Microsoft.Reporting.WinForms;
using DGVPrinterHelper;
using Abbey_Trading_Store.Reports.Inventory_Report;


namespace Abbey_Trading_Store.UI
{
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }
        const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
        OleDbConnection conn = new OleDbConnection(connection);
        InventoryDataSet dataset = new InventoryDataSet();
        product product = new product();
        Categories category = new Categories();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();

            DataTable dt = new DataTable();
            OleDbDataAdapter adapter = product.select();
            conn.Open();
            adapter.Fill(dt);
            dgv_Inventory.DataSource = dt;
            dataset.Clear();
            adapter.Fill(dataset, "Inventory_data");
            conn.Close();
            

            // adding categories to the combo box
            DataTable cdt = category.select();
            Category_combobox.DataSource = cdt;

            // adding the rows to be displayed
            Category_combobox.DisplayMember = "title";
            Category_combobox.ValueMember = "title";

            this.reportViewer1.RefreshReport();
        }

        private void Category_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = Category_combobox.Text;
            DataTable dt = new DataTable();
            OleDbDataAdapter adapter = product.DisplayProductsBasedOnCategory(category);
            conn.Open();
            adapter.Fill(dt);
            dgv_Inventory.DataSource = dt;
            dataset.Clear();
            adapter.Fill(dataset, "Inventory_data");
            conn.Close();

           
        }

        private void Show_all_inventory_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adapter = product.select();
            conn.Open();
            adapter.Fill(dt);
            dgv_Inventory.DataSource = dt;
            dataset.Clear();
            adapter.Fill(dataset, "Inventory_data");
            conn.Close(); 

        }

        private void Show_all_Click(object sender, EventArgs e)
        {
            //DGVPrinter Printer = new DGVPrinter();
            //Printer.Title = "\r\n\r\n\r\n ABBEY TRADING STORE \r\n\r\n";
            //Printer.SubTitle = "Masaka Buddu Street \r\n Phone: 0758989094\r\n\r\n";
            //Printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            //Printer.PageNumbers = true;
            //Printer.PageNumberInHeader = false;
            //Printer.PorportionalColumns = false;
            //Printer.HeaderCellAlignment = StringAlignment.Near;
            //Printer.Footer = "\r\n\r\n Report for All Inventory";
            //Printer.FooterSpacing = 15;
            //Printer.PrintDataGridView(dgv_Inventory);

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Abbey_Trading_Store.Reports.Inventory_Report.InventoryReport.rdlc";
            ReportDataSource datasource = new ReportDataSource("InventoryDataSet", dataset.Tables[0]);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datasource);
            this.reportViewer1.RefreshReport();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgv_Inventory_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

        }
    }
}
