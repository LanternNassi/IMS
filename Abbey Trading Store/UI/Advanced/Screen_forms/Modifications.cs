using Abbey_Trading_Store.DAL;
using MaterialSkin.Controls;
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
    public partial class Modifications : MaterialForm
    {
        public Modifications()
        {
            InitializeComponent();

            product Product = new product();
            DataTable dt = Product.Select_Modifications();
            dataGridView1.DataSource = dt;
        }
    }
}
