﻿using Abbey_Trading_Store.DAL;
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
            this.panel10.Height = LayoutFlex.scrollbar_1;

            //materialScrollBar1.Value = flowLayoutPanel1.HorizontalScroll.Value;
            //materialScrollBar1.Minimum = flowLayoutPanel1.HorizontalScroll.Minimum;
            //materialScrollBar1.Maximum = flowLayoutPanel1.HorizontalScroll.Maximum;

            //materialScrollBar1.Minimum = flowLayoutPanel1.HorizontalScroll.Minimum;
            //materialScrollBar1.Maximum = flowLayoutPanel1.HorizontalScroll.Maximum + 20;


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
                ExpCategories category = new ExpCategories();
                DataTable dt = Product.MostSellingProductsAppropriatetly();
                DataTable dt_2 = DAL.DAL_Properties.Env.mode == 1 ? (user.Overview_2()) : (user.Overview());
                DataTable dt_3 = DAL.DAL_Properties.Env.mode == 1 ? (user.TransactionsOverview_2()) : (user.TransactionsOverview("Customer"));
                DataTable dt_4 = category.ExpenditureOverview();

                //Reversing the rows of transactions overview
                DataRow[] rows = dt_3.Select();
                Array.Reverse(rows);

                foreach (DataRow dr in rows)
                {
                    
                    chart1.Series["Sales"].Points.AddXY(dr[2].ToString(), Convert.ToInt32(dr[1]));
                    chart1.Series["Profit Accummulation"].Points.AddXY(dr[2].ToString(), Convert.ToInt64(dr[0]));

                    label6.Text = "Shs. " + Convert.ToInt64(dr[1]).ToString("N0");
                    profitlbl.Text = "Shs. " + Convert.ToInt64(dr[0]).ToString("N0");

                    circularProgressBar1.Value = Convert.ToInt32(dr[1]) / 1000000000;
                    Profits.Value = Convert.ToInt32(dr[0]) / 1000000000;

                    circularProgressBar1.Text = Convert.ToInt32(dr[1]) / 1000000000 * 100 + "%";
                    Profits.Text = Convert.ToInt32(dr[0]) / 1000000000 * 100 + "%";
                    

                }

                foreach(DataRow dr in dt_4.Rows)
                {
                    chart1.Series["Expenditure"].Points.AddXY(dr[1].ToString(), Convert.ToInt64(dr[0]));

                }


                Users.Text = "Users : " + dt_2.Rows[12][1].ToString();
                Categories.Text = "Categories : " + dt_2.Rows[2][1].ToString();
                Products.Text = "Products : " + dt_2.Rows[7][1].ToString();
                Customers.Text = "Customers : " + dt_2.Rows[3][1].ToString();
                Transactions.Text = "Transactions : " + dt_2.Rows[11][1].ToString();
                TD.Text = "Details : " + dt_2.Rows[9][1].ToString();

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
                    chart1.Series["Transactions"].Points.AddXY(dr[2].ToString(), Convert.ToInt64(dr[1]));
                    chart1.Series["Profit Accummulation"].Points.AddXY(dr[2].ToString(), Convert.ToInt64(dr[0]));

                    label6.Text = "Shs. " + Convert.ToInt64(dr[1]).ToString("N0");
                    profitlbl.Text = "Shs. " + Convert.ToInt64(dr[0]).ToString("N0");

                    circularProgressBar1.Value = Convert.ToInt32(dr[1]) / 1000000000;
                    Profits.Value = Convert.ToInt32(dr[0]) / 1000000000;

                    circularProgressBar1.Text = Convert.ToInt64(dr[1]) / 1000000000 * 100 + "%";
                    Profits.Text = Convert.ToInt64(dr[0]) / 1000000000 * 100 + "%";



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

        private void materialScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            //flowLayoutPanel1.HorizontalScroll.Value = materialScrollBar1.Value;
            //flowLayoutPanel1.Left = materialScrollBar1.Value;
        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            LowStock form = new LowStock(low_on_stock);
            form.Show();
        }
    }
}
