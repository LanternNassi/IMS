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
using Abbey_Trading_Store.DAL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;
using Abbey_Trading_Store.UI.Advanced.CustomMessageBox;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    public partial class frmDealCust : Form
    {
        public frmDealCust()
        {
            InitializeComponent();
        }

        private void clear()
        {
            id.Text = "";
            name.Text = "";
            Email.Text = "";
            Contact.Text = "";
            Address.Text = "";
            type_comboBox1.Text = "";
        }

        private void frmDealCust_Load(object sender, EventArgs e)
        {
            DealerAndCustomer D_cust = new DealerAndCustomer();
            DataTable dt = D_cust.SelectAppropriately();
            dataGridView1.DataSource = dt;

            this.circularProgressBar1.Value = dt.Rows.Count;
            this.circularProgressBar1.Text = (dt.Rows.Count).ToString() + "%";
        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DealerAndCustomer DC = new DealerAndCustomer();
            //DC.Id = Convert.ToInt32(id.Text);
            DC.Type = type_comboBox1.Text;
            DC.Name = name.Text;
            DC.Email = Email.Text;
            DC.Contact = Contact.Text;
            DC.Address = Address.Text;
            DC.Added_by = Login_form.user;
            bool check = await DC.InsertAppropriately();
            if (check == true)
            {
                Cursor = Cursors.Default;
                RJMessageBox.Show("Customer added successfully",
                    "Customery Management Portal",
                    MessageBoxButtons.OK);
                clear();
                DataTable dt =  DC.SelectAppropriately();
                dataGridView1.DataSource = dt;

                this.circularProgressBar1.Value = dt.Rows.Count;
                this.circularProgressBar1.Text = (dt.Rows.Count).ToString() + "%";
            }
            else
            {
                Cursor = Cursors.Default;
                RJMessageBox.Show("Customer added successfully",
                                    "Customery Management Portal",
                                    MessageBoxButtons.OK);
            }

        }

        private async void materialButton2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DealerAndCustomer DC = new DealerAndCustomer();
            DC.Id = Convert.ToInt32(id.Text);
            DC.Type = type_comboBox1.Text;
            DC.Name = name.Text;
            DC.Email = Email.Text;
            DC.Contact = Contact.Text;
            DC.Address = Address.Text;
            bool check = await DC.UpdateAppropriately();
            if (check == true)
            {
                Cursor = Cursors.Default;
                DataTable dt = DC.SelectAppropriately();
                dataGridView1.DataSource = dt;
                RJMessageBox.Show("Customer updated successfully",
                                    "Customery Management Portal",
                                    MessageBoxButtons.OK);
                clear();

                this.circularProgressBar1.Value = dt.Rows.Count;
                this.circularProgressBar1.Text = (dt.Rows.Count).ToString() + "%";
            }
            else
            {
                Cursor = Cursors.Default;
                RJMessageBox.Show("Failed to update correctly",
                                    "Customery Management Portal",
                                    MessageBoxButtons.OK);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            id.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
            type_comboBox1.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
            name.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
            Email.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
            Contact.Text = dataGridView1.Rows[row].Cells[4].Value.ToString();
            Address.Text = dataGridView1.Rows[row].Cells[5].Value.ToString();
        }

        private async void materialButton3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DealerAndCustomer DC = new DealerAndCustomer();
            DC.Id = Convert.ToInt32(id.Text);
            bool check = await DC.DeleteAppropriately();
            if (check == true)
            {
                Cursor = Cursors.Default;
                DataTable dt = DC.SelectAppropriately();
                dataGridView1.DataSource = dt;
                RJMessageBox.Show("Customer deleted successfully",
                                   "Customery Management Portal",
                                   MessageBoxButtons.OK);
                clear();
                this.circularProgressBar1.Value = dt.Rows.Count;
                this.circularProgressBar1.Text = (dt.Rows.Count).ToString() + "%";
            }
            else
            {
                Cursor = Cursors.Default;
                RJMessageBox.Show("Customer deletion unsuccessfully",
                                   "Customery Management Portal",
                                   MessageBoxButtons.OK);
            }
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            string keyword = search.Text;
            DealerAndCustomer DC = new DealerAndCustomer();
            DataTable dt = DC.SearchAppropriately(keyword);
            dataGridView1.DataSource = dt;

            this.circularProgressBar2.Value = dt.Rows.Count;
            this.circularProgressBar2.Text = (dt.Rows.Count).ToString() + "%";
        }
    }
}
