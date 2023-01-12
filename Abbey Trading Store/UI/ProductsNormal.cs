using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Abbey_Trading_Store.UI
{
    public partial class ProductsNormal : Form
    {
        public ProductsNormal()
        {
            InitializeComponent();
        }
        const string connection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Abbey Trading Store.accdb;";
        OleDbConnection conn = new OleDbConnection(connection);

        private void ProductsNormal_Load(object sender, EventArgs e)
        {
            product product = new product();
            DataTable dt = new DataTable();
            OleDbDataAdapter adapter = product.select();
            conn.Open();
            adapter.Fill(dt);
            Prod_DGV.DataSource = dt;
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchProd_TextChanged(object sender, EventArgs e)
        {
            string keyword = SearchProd.Text;
            product product = new product();
            DataTable dt = product.search(keyword);
            Prod_DGV.DataSource = dt;
        }
    }
}
