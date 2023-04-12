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
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
        }

        private void clear()
        {
            id.Text = "";
            title.Text = "";
            description.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            Categories category = new Categories();
            DataTable dt = category.select();
            categoriesDGV.DataSource = dt;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Categories category = new Categories();
            category.Title = title.Text;
            category.Description = description.Text;
            category.Added_by = Login_form.user;
            bool affected = category.insert();
            //var isSuccess = await category.insert2();

            if (affected == true)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Category successfully inserted");
                clear();
            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Category insertion Failed");
            }
            DataTable dt = category.select();
            categoriesDGV.DataSource = dt;
            Cursor = Cursors.Default;
        }

        private void categoriesDGV_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            id.Text = categoriesDGV.Rows[row].Cells[0].Value.ToString();
            title.Text = categoriesDGV.Rows[row].Cells[1].Value.ToString();
            description.Text = categoriesDGV.Rows[row].Cells[2].Value.ToString();

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Categories category = new Categories();
            category.Title = title.Text;
            category.Description = description.Text;
            category.ID = id.Text;
            bool affected = category.update();
            var isSuccess = await category.Update2();
            if (affected == true )
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Category successfully updated. Thank you.");
                clear();
                DataTable dt = category.select();
                categoriesDGV.DataSource = dt;
            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Category not updated.");
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Categories category = new Categories();
            category.ID = id.Text;
            category.Title = title.Text;
            bool affected = category.delete();
            var isSuccess = await category.Delete2();
            if (affected == true)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Category deleted successfully ");
                clear();
                DataTable dt = category.select();
                categoriesDGV.DataSource = dt;
            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Category not deleted ");
            }


        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            string value = search.Text;
            Categories category = new Categories();
            DataTable dt = category.search(value);
            categoriesDGV.DataSource = dt;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
