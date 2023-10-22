using Abbey_Trading_Store.DAL;
using Abbey_Trading_Store.DAL.DAL_Properties;
using Microsoft.Data.SqlClient;
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
    public partial class Overview : Form
    {
        public Overview()
        {
            InitializeComponent();
            
            this.flowLayoutPanel1.Height = LayoutFlex.overview_flowlayout_panel1;
            this.flowLayoutPanel2.Height = LayoutFlex.overview_flowlayout_panel2;
        }

        System.Data.SqlClient.SqlDataAdapter low_on_stock= null;

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Overview_Load(object sender, EventArgs e)
        {
            if(Env.mode != 1)
            {
                product Product = new product();
                Users user = new Users();
                DataTable dt = Product.MostSellingProductsAppropriatetly();
                DataTable dt_2 = DAL.DAL_Properties.Env.mode == 1 ? (user.Overview_2()) : (user.Overview());
                DataTable dt_3 = DAL.DAL_Properties.Env.mode == 1 ? (user.TransactionsOverview_2()) : (user.TransactionsOverview("Customer"));
                foreach (DataRow dr in dt_3.Rows)
                {
                    
                    chart1.Series["Transactions"].Points.AddXY(dr[2].ToString(), Convert.ToInt32(dr[1]));
                    chart1.Series["Profit Accummulation"].Points.AddXY(dr[2].ToString(), Convert.ToInt32(dr[0]));

                    label6.Text = "Shs. " + Convert.ToInt32(dr[1]).ToString("N0");
                    profitlbl.Text = "Shs. " + Convert.ToInt32(dr[0]).ToString("N0");

                    circularProgressBar1.Value = Convert.ToInt32(dr[1]) / 1000000000;
                    Profits.Value = Convert.ToInt32(dr[0]) / 1000000000;

                    circularProgressBar1.Text = Convert.ToInt32(dr[1]) / 1000000000 * 100 + "%";
                    Profits.Text = Convert.ToInt32(dr[0]) / 1000000000 * 100 + "%";
                    

                }


                Users.Text = "Users : " + dt_2.Rows[9][1].ToString();
                Categories.Text = "Categories : " + dt_2.Rows[2][1].ToString();
                Products.Text = "Products : " + dt_2.Rows[5][1].ToString();
                Customers.Text = "Customers : " + dt_2.Rows[3][1].ToString();
                Transactions.Text = "Transactions : " + dt_2.Rows[8][1].ToString();
                TD.Text = "Details : " + dt_2.Rows[6][1].ToString();

                if(dt.Rows.Count > 0)
                {
                    int determinant = dt.Rows.Count >= 7 ? 7 : dt.Rows.Count;
                    for (int i = 0; i < determinant; i++)
                    {
                        chart2.Series["S2"].Points.AddXY(dt.Rows[i][0].ToString(), Convert.ToDecimal(dt.Rows[i][2].ToString()));
                    }
                }

                //Getting low on stock
                low_on_stock = Product.LowStock();
                DataTable LST = new DataTable();
                low_on_stock.Fill(LST);
                materialButton1.Text = LST.Rows.Count.ToString() + " Low on stock";

                //Unsettled debts
                Abbey_Trading_Store.DAL.Transactions transact = new Transactions();
                System.Data.SqlClient.SqlDataAdapter adapter_G = transact.GetDebtorsOnly();
                DataTable Gt = new DataTable();
                adapter_G.Fill(Gt);
                materialButton2.Text = Gt.Rows.Count.ToString() + " Unsettled debts";



            } else
            {
                product Product = new product();
                Users user = new Users();
                //DataTable dt = Product.MostSellingProductsAppropriatetly();
                //DataTable dt_2 = DAL.DAL_Properties.Env.mode == 1 ? (user.Overview_2()) : (user.Overview());
                DataTable dt_3 = DAL.DAL_Properties.Env.mode == 1 ? (user.TransactionsOverview_2()) : (user.TransactionsOverview("Customer"));
                foreach (DataRow dr in dt_3.Rows)
                {
                    chart1.Series["Transactions"].Points.AddXY(dr[2].ToString(), Convert.ToInt32(dr[1]));
                    chart1.Series["Profit Accummulation"].Points.AddXY(dr[2].ToString(), Convert.ToInt32(dr[0]));

                    label6.Text = "Shs. " + Convert.ToInt32(dr[1]).ToString("N0");
                    profitlbl.Text = "Shs. " + Convert.ToInt32(dr[0]).ToString("N0");

                    circularProgressBar1.Value = Convert.ToInt32(dr[1]) / 1000000000;
                    Profits.Value = Convert.ToInt32(dr[0]) / 1000000000;

                    circularProgressBar1.Text = Convert.ToInt32(dr[1]) / 1000000000 * 100 + "%";
                    Profits.Text = Convert.ToInt32(dr[0]) / 1000000000 * 100 + "%";



                }

                



                //Users.Text = "Users : " + dt_2.Rows[6][1].ToString();
                //Categories.Text = "Categories : " + dt_2.Rows[0][1].ToString();
                //Products.Text = "Products : " + dt_2.Rows[2][1].ToString();
                //Customers.Text = "Customers : " + dt_2.Rows[1][1].ToString();
                //Transactions.Text = "Transactions : " + dt_2.Rows[5][1].ToString();
                //TD.Text = "Details : " + dt_2.Rows[3][1].ToString();

                //for (int i = 0; i < 7; i++)
                //{
                //    chart2.Series["S2"].Points.AddXY(dt.Rows[i][0].ToString(), Convert.ToInt32(dt.Rows[i][2].ToString()));
                //}

            }
            
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            LowStock form = new LowStock(low_on_stock);
            form.Show();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            UnsettledDebts form = new UnsettledDebts();
            form.Show();
        }

        private void Overview_Layout(object sender, LayoutEventArgs e)
        {
            flowLayoutPanel1.Height = Convert.ToInt32(0.33 * Dashboard.PnlContainer.Height);
           
        }
    }
}
