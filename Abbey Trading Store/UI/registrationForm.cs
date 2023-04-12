using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL;

namespace Abbey_Trading_Store.UI
{
    public partial class registrationForm : Form
    {
        public registrationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clear()
        {
            
            name.Text = "";
            password.Text = "";
            this.gender_cmbx.Text = "";
            added_by.Text = "";
            type_cmbx.Text = "";

        }

        private void registrationForm_Load(object sender, EventArgs e)
        {
            Users user = new Users();
            DataTable dt = user.SelectAppropriately();
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[2].Visible = false;

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Users user = new Users();
            user.user = name.Text;
            user.password = password.Text;
            user.gender = gender_cmbx.Text;
            user.added_by = Login_form.user;
            user.type = type_cmbx.Text;
            bool result = await user.InsertAppropriately();
            if (result == true)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("User successfully added");
                //Updating the server
                
            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("user creation failed ");
            }
            DataTable dt = user.SelectAppropriately();
            dataGridView1.DataSource = dt;
            clear();
            Cursor = Cursors.Default;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string keywords = search.Text;
            Users user = new Users();
            DataTable dt = user.SearchAppropriately(keywords);
            dataGridView1.DataSource = dt;


        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            
            name.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            if (Login_form.user == name.Text)
            {
                password.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
            } else
            {
                password.Text = "XXXXX";
            }
            gender_cmbx.Text = dataGridView1.Rows[rowindex].Cells[3].Value.ToString();
            added_by.Text = dataGridView1.Rows[rowindex].Cells[4].Value.ToString();
            type_cmbx.Text = dataGridView1.Rows[rowindex].Cells[5].Value.ToString();
            search.Text = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (Login_form.user == name.Text)
            {
                Users user = new Users();
                user.id = int.Parse(search.Text);
                user.user = name.Text;
                user.password = password.Text;
                user.gender = gender_cmbx.Text;
                user.added_by = added_by.Text;
                user.type = type_cmbx.Text;
                bool result = await user.UpdateAppropriately(search.Text);

                if (result == true)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("User successfully updated");

                }
                else
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("An error occcurred.");
                }
                DataTable dt = user.search(search.Text);
                dataGridView1.DataSource = dt;
                clear();

            } else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("You dont have administral rights over this account.This means you cannot edit or delete it.");
            }
            Cursor = Cursors.Default;


        }

        private async void button4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (Login_form.user == name.Text)
            {
                Users user = new Users();
                bool result = await user.DeleteApprpriately(search.Text);
                if (result == true)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("User successfully deleted");
                }
                else
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("An error occured...");
                }
                clear();
                search.Text = "";
                DataTable dt = user.select();
                dataGridView1.DataSource = dt;
            } else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("You dont have administral rights over this account.This means you cannot edit or delete it.");
            }

            Cursor = Cursors.Default;
        }
    }
}
