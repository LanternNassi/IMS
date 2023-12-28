using Abbey_Trading_Store.DAL;
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
    public partial class UpdateScreen : Form
    {
        private Dashboard dashboard;
        public UpdateScreen(Dashboard db)
        {
            InitializeComponent();

            dashboard = db;
        }

        private void P_b_1_Click(object sender, EventArgs e)
        {

        }

        private void label_1_Click(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            
            dashboard.Hide();
            materialButton1.Enabled = false;
            SettingsConfig.Download_install_update(this , P_b_1 , label_1);
        }
    }
}
