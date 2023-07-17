using Abbey_Trading_Store.DAL;
using MaterialSkin.Controls;
//using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    public partial class LowStock : MaterialForm
    {
        public LowStock(SqlDataAdapter adapter)
        {
            InitializeComponent();
            ad = adapter;
        }
        SqlDataAdapter ad = new SqlDataAdapter();
        DataTable dt = new DataTable();

        private void LowStock_Load(object sender, EventArgs e)
        {
            ad.Fill(dt);
            dataGridView1.DataSource = dt;


        }
    }
}
