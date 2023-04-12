using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Abbey_Trading_Store.UI
{
    public partial class frmUserDashboard : Form
    {
        public frmUserDashboard()
        {
            InitializeComponent();
        }

        //Set public static string to specify if the form is sales or purchase
        public static string type; 

        private void frmUserDashboard_Load(object sender, EventArgs e)
        {
            user.Text = Login_form.user;
        }

        private void frmUserDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login_form form = new Login_form();
            form.Show();
            this.Hide();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            type = "Sales";
            frmPurchaseandsales form = new frmPurchaseandsales();
            form.Show();
            Cursor = Cursors.Default;

        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            type = "Purchase";
            frmPurchaseandsales form = new frmPurchaseandsales();
            form.Show();
            //set value
            Cursor = Cursors.Default;


        }

        private void dealerAndCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmDealerAndCustomer form = new frmDealerAndCustomer();
            form.Show();
            Cursor = Cursors.Default;
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmTransactions form = new frmTransactions();
            form.Show();
            Cursor = Cursors.Default;
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            ProductsNormal form = new ProductsNormal();
            form.Show();
            Cursor = Cursors.Default;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            type = "Sales";
            frmPurchaseandsales form = new frmPurchaseandsales();
            form.Show();
            Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            type = "Purchase";
            frmPurchaseandsales form = new frmPurchaseandsales();
            form.Show();
            Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmTransactions form = new frmTransactions();
            form.Show();
            Cursor = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmDealerAndCustomer form = new frmDealerAndCustomer();
            form.Show();
            Cursor = Cursors.Default;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //Inventory form = new Inventory();
            //form.Show();
            Cursor = Cursors.WaitCursor;
            ProductsNormal form = new ProductsNormal();
            form.Show();
            Cursor = Cursors.Default;
        }
    }
}
