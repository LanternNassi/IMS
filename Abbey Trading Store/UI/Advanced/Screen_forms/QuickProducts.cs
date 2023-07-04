using Abbey_Trading_Store.DAL;
using Abbey_Trading_Store.DAL.DAL_Properties;
using MaterialSkin.Controls;
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
    public partial class QuickProducts : MaterialForm
    {
        public QuickProducts()
        {
            InitializeComponent();

            product product = new product();
            DataTable dt = new DataTable();
            dynamic adapter = product.SelectAppropriately();
            Connection().Open();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            Connection().Close();
        }
        private dynamic Connection()
        {
            if (Env.mode == 1)
            {
                const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
                System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connection);
                return conn;
            }
            else
            {
                SqlConnection conn = new SqlConnection(Env.local_server_database_conn_string);
                return conn;
            }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            string keyword = search.Text;
            product product = new product();
            DataTable dt = product.SearchAppropriately(keyword);
            dataGridView1.DataSource = dt;

            
        }
    }
}
