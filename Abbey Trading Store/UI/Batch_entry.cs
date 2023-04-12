using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL;
using Abbey_Trading_Store.DAL.DAL_Properties;

namespace Abbey_Trading_Store.UI
{
    public partial class Batch_entry : Form
    {

        public Batch_entry()
        {
            InitializeComponent();
        }
        DataTable dtExcel = new DataTable();


        private void Choose_file_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            product New_products = new product();
            string fileExt = string.Empty;
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filePath = file.FileName;
                fileExt = Path.GetExtension(filePath);
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        dtExcel = New_products.ReadExcel(filePath, fileExt);
                        dgv_Batch.Visible = true;
                        dgv_Batch.DataSource = dtExcel;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void Generate_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int number_of_columns = dtExcel.Columns.Count;
            if (number_of_columns == 7)
            {
                List<ProductsProps> products = new List<ProductsProps>();
                int row = 0;
                for(int i = 1; i<dtExcel.Rows.Count; i++){
                    product new_product = new product();
                    new_product.products = dtExcel.Rows[i][0].ToString();
                    new_product.Category = dtExcel.Rows[i][1].ToString();
                    new_product.Description = dtExcel.Rows[i][2].ToString();
                    new_product.Rate = Convert.ToDecimal(dtExcel.Rows[i][3]);
                    new_product.Selling_price = Convert.ToDecimal(dtExcel.Rows[i][4]);
                    new_product.Quantity = Convert.ToDecimal(dtExcel.Rows[i][5]);
                    new_product.Added_date = DateTime.Now;
                    new_product.Added_by = dtExcel.Rows[i][6].ToString();

                    // Adding to the props class
                    ProductsProps product_prop = new ProductsProps();
                    product_prop.products = dtExcel.Rows[i][0].ToString();
                    product_prop.Category = dtExcel.Rows[i][1].ToString();
                    product_prop.Description = dtExcel.Rows[i][2].ToString();
                    product_prop.Rate = Convert.ToDecimal(dtExcel.Rows[i][3]);
                    product_prop.Selling_price = Convert.ToDecimal(dtExcel.Rows[i][4]);
                    product_prop.Quantity = Convert.ToDecimal(dtExcel.Rows[i][5]);
                    product_prop.Added_date = DateTime.Now;
                    product_prop.Added_by = dtExcel.Rows[i][6].ToString();

                    products.Add(product_prop);
                    bool created = new_product.add();
                    
                    if (created)
                    {
                        row += 1;
                    }
                    else
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("There is an error with " + new_product.products);
                    }
                }
                product prod = new product();
                var success = await prod.Batchupload(products);
                Cursor = Cursors.Default;
                MessageBox.Show("Products inserted successfully");
            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Seems you are making an error with this function");
            }
            Cursor = Cursors.Default;
        }



    }
}
