using Abbey_Trading_Store.DAL;
using MaterialSkin;
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
    public partial class frmCompany : Form
    {
        public frmCompany()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        }

        private void label19_Click(object sender, EventArgs e)
        {
            this.Close();
           

        }

        private void Info_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            Abbey_Trading_Store.DAL.BusinessAccount account = new Abbey_Trading_Store.DAL.BusinessAccount();
            account.Name = Name.Text;
            account.Description = Info.Text;
            account.Tel_1= Tel_1.Text;
            account.Tel_2 = Tel_2.Text;
            account.Tel_3 = Tel_3.Text;
            account.Valid = "True";
            account.Server_id = 0;

            bool created = account.Insert();
            if (created) {
                MessageBox.Show("Credentials created successfully");
                this.Close();
                Login_form form = new Login_form();
                form.Show();
            }else
            {
                MessageBox.Show("A problem was encoutered during the setup of the credentials.");
            }
        }
    }
}
