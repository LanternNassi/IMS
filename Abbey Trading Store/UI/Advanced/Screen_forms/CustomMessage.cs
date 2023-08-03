using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL;

namespace Abbey_Trading_Store.UI.Advanced.Screen_forms
{
    public partial class CustomMessage : Form
    {
        public CustomMessage()
        {
            InitializeComponent();
        }

        DataTable selected;
        DataTable dt;

        private void CustomMessage_Load(object sender, EventArgs e)
        {
            DealerAndCustomer cust = new DealerAndCustomer();
            dt = cust.BulkSendCustomerContacts();
            dataGridView1.DataSource = dt;

            //
            selected = dt.Clone();
            dgv1.DataSource = selected;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

            if (materialTextBox1.Text == "")
            {
                if (rowIndex >= 0)
                {
                    selected.ImportRow(dt.Rows[rowIndex]);
                    dt.Rows.Remove(dt.Rows[rowIndex]);

                }
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr[0].ToString() == dataGridView1.Rows[rowIndex].Cells[0].Value.ToString())
                    {
                        selected.ImportRow(dr);
                        dt.Rows.Remove(dr);
                        dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
                        return;
                    }
                }
            }

            dgv1.DataSource = selected;
            

        }

        private DataTable Search(string keywords)
        {
            
            DataTable searched = dt.Clone();
            
            foreach(DataRow dr in dt.Rows)
            {
                if (dr[2].ToString().Contains(keywords))
                {
                    searched.ImportRow(dr);
                }
            }
            return searched;
        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(materialTextBox1.Text != "")
            {
                string keywords = materialTextBox1.Text;
                DataTable temp_dt = Search(keywords);
                dataGridView1.DataSource = temp_dt;
            }
            else
            {
                dataGridView1.DataSource = dt;

            }

        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                dt.ImportRow(selected.Rows[row]);
                selected.Rows.RemoveAt(row);
            }
        }

        private void materialCheckbox1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialCheckbox2.CheckState.ToString() == "Checked" || materialCheckbox3.CheckState.ToString() == "Checked")
            {
                MessageBox.Show("Only one choice can be selected");
                //materialCheckbox1.Checked = false;
                this.materialCheckbox1.Checked = false;
                this.materialCheckbox1.CheckState = System.Windows.Forms.CheckState.Unchecked;

            } else if(materialCheckbox1.CheckState.ToString() == "Unchecked")
            {
                this.materialCheckbox1.Checked = false;
                this.materialCheckbox1.CheckState = System.Windows.Forms.CheckState.Unchecked;
            }
            else
            {
                //materialCheckbox1.Checked= true;
                this.materialCheckbox1.Checked = true;
                this.materialCheckbox1.CheckState = System.Windows.Forms.CheckState.Checked;
            }

            //MessageBox.Show(materialCheckbox1.CheckState.ToString());
        }

        private void materialCheckbox2_CheckedChanged(object sender, EventArgs e)
        {
            if (materialCheckbox1.CheckState.ToString() == "Checked" || materialCheckbox3.CheckState.ToString() == "Checked")
            {
                MessageBox.Show("Only one choice can be selected");
                //materialCheckbox1.Checked = false;
                this.materialCheckbox2.Checked = false;
                this.materialCheckbox2.CheckState = System.Windows.Forms.CheckState.Unchecked;

            }
            else if (materialCheckbox2.CheckState.ToString() == "Unchecked")
            {
                this.materialCheckbox2.Checked = false;
                this.materialCheckbox2.CheckState = System.Windows.Forms.CheckState.Unchecked;
            }
            else
            {
                //materialCheckbox1.Checked= true;
                this.materialCheckbox2.Checked = true;
                this.materialCheckbox2.CheckState = System.Windows.Forms.CheckState.Checked;
            }
        }

        private void materialCheckbox3_CheckedChanged(object sender, EventArgs e)
        {
            if (materialCheckbox1.CheckState.ToString() == "Checked" || materialCheckbox2.CheckState.ToString() == "Checked")
            {
                MessageBox.Show("Only one choice can be selected");
                //materialCheckbox1.Checked = false;
                this.materialCheckbox3.Checked = false;
                this.materialCheckbox3.CheckState = System.Windows.Forms.CheckState.Unchecked;

            }
            else if (materialCheckbox3.CheckState.ToString() == "Unchecked")
            {
                this.materialCheckbox3.Checked = false;
                this.materialCheckbox3.CheckState = System.Windows.Forms.CheckState.Unchecked;
            }
            else
            {
                //materialCheckbox1.Checked= true;
                this.materialCheckbox3.Checked = true;
                this.materialCheckbox3.CheckState = System.Windows.Forms.CheckState.Checked;
            }
        }

        public void updateSendMessageProgress(int value)
        {
            SendProgress.Value = value;
            SendProgress.Text = value + "%";
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if(materialMultiLineTextBox21.Text == "")
            {
                MessageBox.Show("Please enter the message before sending");
            }else
            {
                //Determining what is selected
                DataTable chosen_dt = new DataTable();
                if(this.materialCheckbox1.CheckState.ToString() == "Checked")
                {
                    chosen_dt = dt;
                }else if (this.materialCheckbox2.CheckState.ToString() == "Checked")
                {
                    chosen_dt = selected;
                }
                else
                {
                    if (selected.Rows.Count > 0)
                    {
                        foreach(DataRow dr in selected.Rows)
                        {
                            dt.ImportRow(dr);
                        }
                        selected.Clear();
                    }

                    chosen_dt = dt;

                }

                DealerAndCustomer cust = new DealerAndCustomer();
                bool success = cust.SendMessage(chosen_dt, materialMultiLineTextBox21.Text, updateSendMessageProgress , false);
                if (success)
                {
                    MessageBox.Show(chosen_dt.Rows.Count + " Messages sent successfully");
                }
                else
                {
                    MessageBox.Show("An error occured.Try again later");
                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
