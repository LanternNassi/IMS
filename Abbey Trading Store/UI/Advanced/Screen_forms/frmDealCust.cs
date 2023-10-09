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
using System.Windows.Forms.DataVisualization.Charting;

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    public partial class frmDealCust : Form
    {
        public bool item_active = false;

        public frmDealCust()
        {
            InitializeComponent();

            DealerAndCustomer D_cust = new DealerAndCustomer();
            DataTable dt = D_cust.SelectAppropriately();
            dataGridView1.DataSource = dt;

            //this.circularProgressBar1.Value = dt.Rows.Count;
            this.circularProgressBar1.Text = (dt.Rows.Count).ToString() + "%";
        }

        private void clear()
        {
            id.Text = "";
            name.Text = "";
            Email.Text = "";
            Contact.Text = "";
            Address.Text = "";
            type_comboBox1.Text = "";

            materialButton1.Enabled = false;
            materialButton2.Enabled = false;
            materialButton3.Enabled = false;
        }

        private void frmDealCust_Load(object sender, EventArgs e)
        {
            
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
                item_active = false;
                Cursor = Cursors.Default;
                DataTable dt = DC.SelectAppropriately();
                dataGridView1.DataSource = dt;
                RJMessageBox.Show("Customer updated successfully",
                                    "Customery Management Portal",
                                    MessageBoxButtons.OK);
                clear();

                
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
                item_active = false;
                Cursor = Cursors.Default;
                DataTable dt = DC.SelectAppropriately();
                dataGridView1.DataSource = dt;
                RJMessageBox.Show("Customer deleted successfully",
                                   "Customery Management Portal",
                                   MessageBoxButtons.OK);
                clear();
                
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

            
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                id.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
                type_comboBox1.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
                name.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
                Email.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
                Contact.Text = dataGridView1.Rows[row].Cells[4].Value.ToString();
                Address.Text = dataGridView1.Rows[row].Cells[5].Value.ToString();

                materialButton1.Enabled = false;
                materialButton2.Enabled = true;
                materialButton3.Enabled = true;
            }
            

        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            if (name.Text.Length > 0 && !item_active)
            {
                materialButton1.Enabled = true;

            }
            else
            {
                materialButton1.Enabled = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                id.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
                type_comboBox1.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
                name.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
                Email.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
                Contact.Text = dataGridView1.Rows[row].Cells[4].Value.ToString();
                Address.Text = dataGridView1.Rows[row].Cells[5].Value.ToString();

                materialButton1.Enabled = false;
                materialButton2.Enabled = true;
                materialButton3.Enabled = true;
            }
        }

        private void frmDealCust_Layout(object sender, LayoutEventArgs e)
        {
            panel1.Width = Convert.ToInt32(Dashboard.PnlContainer.Width * 0.25);

            panel16.Height = Convert.ToInt32(Dashboard.PnlContainer.Height * 0.19);
            panel11.Height = panel12.Height = panel13.Height = panel14.Height = panel15.Height = (Dashboard.PnlContainer.Height - panel16.Height) / 5;

            panel3.Height = Convert.ToInt32(Dashboard.PnlContainer.Height * 0.21);
            panel4.Width = panel5.Width = Convert.ToInt32((Dashboard.PnlContainer.Width-panel1.Width) * 0.6)/2;

            panel6.Height = Convert.ToInt32(0.121 * Dashboard.PnlContainer.Height);
            panel7.Width = panel8.Width = panel9.Width = panel10.Width = panel6.Width / 4;


        }
    }
}
