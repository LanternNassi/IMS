using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using Abbey_Trading_Store.DAL;
using MaterialSkin.Controls;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using Abbey_Trading_Store.UI.Advanced.CustomMessageBox;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    public partial class frmUser :Form
    {
        MaterialTextBox search;
        public string active_user_id;
        public frmUser()
        {
            InitializeComponent();
            //search = search_control;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            //this.panel3.Height = LayoutFlex.user_panel_1;
            //this.panel2.Height = LayoutFlex.user_panel_2;

            Users user = new Users();
            DataTable dt = user.SelectAppropriately();
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.Columns[2].Visible = false;
            for (var i = 0; i < dt.Columns.Count - 1; i++)
            {
                this.dataGridView1.Columns[i].Width = 160;

            }
            //materialSkinManager.ColorScheme = new ColorScheme(Primary.Pink400, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void clear()
        {

            name.Text = "";
            password.Text = "";
            this.gender_cmbx.Text = "";
            added_by.Text = "";
            materialComboBox2.Text = "";

            //
            materialButton1.Enabled = false;
            materialButton2.Enabled = false;
            materialButton3.Enabled = false;

        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void materialComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.user = name.Text;
            user.password = password.Text;
            user.gender = gender_cmbx.Text;
            user.added_by = Login_form.user;
            user.type = materialComboBox2.Text;
            bool result = await user.InsertAppropriately();
            if (result == true)
            {
                //MessageBox.Show("User successfully added");
                RJMessageBox.Show("User added successfully",
                    "User Management Portal",
                    MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("user creation failed ");
            }
            DataTable dt = user.SelectAppropriately();
            dataGridView1.DataSource = dt;
            clear();
        }

        private async void materialButton2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (Login_form.user == name.Text)
            {
                Users user = new Users();
                user.user = name.Text;
                user.password = password.Text;
                user.gender = gender_cmbx.Text;
                user.added_by = added_by.Text;
                user.type = materialComboBox2.Text;
                bool result = await user.UpdateAppropriately(active_user_id);
                if (result == true)
                {
                    Cursor = Cursors.Default;
                    RJMessageBox.Show("User updated successfully",
                                        "User Management Portal",
                                        MessageBoxButtons.OK);
                }
                else
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("An error occcurred.");
                }
                DataTable dt = user.SelectAppropriately();
                dataGridView1.DataSource = dt;
                clear();
            }
            else
            {
                Cursor = Cursors.Default;
                RJMessageBox.Show(
                    "The editing of this account's information is not subject to any of your eligible permissions. Meaning you cannot edit this account's information ",
                    "User Management Portal",
                    MessageBoxButtons.OK);
                //MessageBox.Show("The editing of this account's information is not subject to any of your eligible permissions. Meaning you cannot edit this account's information ");

            }
            Cursor = Cursors.Default;
        }

        private async void materialButton3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (Login_form.user == name.Text)
            {
                Users user = new Users();
                bool result = await user.DeleteApprpriately(active_user_id);
                if (result == true)
                {
                    Cursor = Cursors.Default;
                    RJMessageBox.Show("User deleted successfully",
                                        "User Management Portal",
                                        MessageBoxButtons.OK);
                    //MessageBox.Show("User successfully deleted");
                }
                else
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("An error occured...");
                }
                clear();
               
                DataTable dt = user.SelectAppropriately();
                dataGridView1.DataSource = dt;

            }
            else
            {
                Cursor = Cursors.Default;
                RJMessageBox.Show(
                    "The editing of this account's information is not subject to any of your eligible permissions. Meaning you cannot edit this account's information ",
                    "User Management Portal",
                    MessageBoxButtons.OK);
                //MessageBox.Show("The editing of this account's information is not subject to any of your eligible permissions. Meaning you cannot edit this account's information ");
            }

            Cursor = Cursors.Default;
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Users user = new Users();
            Abbey_Trading_Store.Reports.Users_Report.Users dataset = new Reports.Users_Report.Users();
            SqlDataAdapter adapter = user.select_2();

            adapter.Fill(dataset , "Users");
            ReportDataSource datasource = new ReportDataSource("Users" , dataset.Tables[0]);
            ReportDataSource[] list = { datasource };

            ReportView form = new ReportView(list, "Abbey_Trading_Store.Reports.Users_Report.Users.rdlc");
            form.Show();
            Cursor = Cursors.Default;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            name.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            if (Login_form.user == name.Text)
            {
                password.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
            }
            else
            {
                password.Text = "XXXXXX";
            }
            gender_cmbx.Text = dataGridView1.Rows[rowindex].Cells[3].Value.ToString();
            added_by.Text = dataGridView1.Rows[rowindex].Cells[4].Value.ToString();
            materialComboBox2.Text = dataGridView1.Rows[rowindex].Cells[5].Value.ToString();
            active_user_id = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
        }
        public void search_users()
        {
            Users user = new Users();
            DataTable dt = user.SearchAppropriately(search.Text);
            dataGridView1.DataSource = dt;
            clear();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            if (rowindex >= 0)
            {
                name.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
                if (Login_form.user == name.Text)
                {
                    password.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
                }
                else
                {
                    password.Text = "XXXXXX";
                }
                gender_cmbx.Text = dataGridView1.Rows[rowindex].Cells[3].Value.ToString();
                added_by.Text = dataGridView1.Rows[rowindex].Cells[4].Value.ToString();
                materialComboBox2.Text = dataGridView1.Rows[rowindex].Cells[5].Value.ToString();
                active_user_id = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

                //Activating buttons
                materialButton2.Enabled = true;
                materialButton3.Enabled = true;
                materialButton1.Enabled = false;

            }
            
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            if (((name.Text).Length > 0))
            {
                materialButton1.Enabled = true;
            } else
            {
                materialButton1.Enabled = false;
            }
        }

        private void frmUser_Layout(object sender, LayoutEventArgs e)
        {
            //Calculating the base height and width of components 
            panel1.Width = Convert.ToInt32(Dashboard.PnlContainer.Width * 0.25);

            //Calculating the height of the mini panels in the panel1
            panel8.Height = panel9.Height = panel10.Height = panel11.Height = panel12.Height = Convert.ToInt32(Dashboard.PnlContainer.Height / 5);


            //Calulating for panel 3
            panel3.Height = Convert.ToInt32(Dashboard.PnlContainer.Height * 0.13);

            //Calculating the width for the button panels
            panel4.Width = panel5.Width = panel6.Width = panel7.Width = Convert.ToInt32(Dashboard.PnlContainer.Width - panel1.Width) / 4;


            panel4.Height = panel5.Height = panel6.Height = panel7.Height = panel3.Height;



        }
    }
}
