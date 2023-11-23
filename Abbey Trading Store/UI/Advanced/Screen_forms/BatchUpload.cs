using Abbey_Trading_Store.DAL;
using Abbey_Trading_Store.DAL.DAL_Properties;
using Abbey_Trading_Store.UI.Advanced.CustomMessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    
    public partial class BatchUpload : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
       (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
           int nHeightEllipse

        );
        public BatchUpload()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

        }

        DataTable dtExcel = new DataTable();


        private void materialButton1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
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
                    Cursor = Cursors.Default;
                    RJMessageBox.Show("Please choose .xls or .xslx file only",
                    "BatchEntry Management Portal",
                    MessageBoxButtons.OK);
                }
            }
            Cursor = Cursors.Default;
        }

        private async void materialButton2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int number_of_columns = dtExcel.Columns.Count;
            if (number_of_columns == 8)
            {
                List<ProductsProps> products = new List<ProductsProps>();
                int row = 0;
                for (int i = 1; i < dtExcel.Rows.Count; i++)
                {
                    product new_product = new product();
                    new_product.products = dtExcel.Rows[i][0].ToString();
                    new_product.Category = dtExcel.Rows[i][1].ToString();
                    new_product.Description = dtExcel.Rows[i][2].ToString();
                    new_product.Rate = Convert.ToDecimal(dtExcel.Rows[i][3]);
                    new_product.Wholesale_price = Convert.ToDecimal(dtExcel.Rows[i][4]);
                    new_product.Selling_price = Convert.ToDecimal(dtExcel.Rows[i][5]);
                    new_product.Quantity = Convert.ToDecimal(dtExcel.Rows[i][6]);
                    new_product.Added_date = DateTime.Now;
                    new_product.Added_by = dtExcel.Rows[i][7].ToString();

                    // Adding to the props class
                    ProductsProps product_prop = new ProductsProps();
                    product_prop.products = dtExcel.Rows[i][0].ToString();
                    product_prop.Category = dtExcel.Rows[i][1].ToString();
                    product_prop.Description = dtExcel.Rows[i][2].ToString();
                    product_prop.Rate = Convert.ToDecimal(dtExcel.Rows[i][3]);
                    product_prop.Wholesale_price = Convert.ToDecimal(dtExcel.Rows[i][4]);
                    product_prop.Selling_price = Convert.ToDecimal(dtExcel.Rows[i][5]);
                    product_prop.Quantity = Convert.ToDecimal(dtExcel.Rows[i][6]);
                    product_prop.Added_date = DateTime.Now;
                    product_prop.Added_by = dtExcel.Rows[i][7].ToString();

                    products.Add(product_prop);
                    bool created = await new_product.AddAppropriately();

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
                if (Env.mode == 3)
                {
                    var success = await prod.Batchupload(products);
                }
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

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
