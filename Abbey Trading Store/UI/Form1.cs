using System;
using System.Windows.Forms;

namespace Abbey_Trading_Store.UI
{
    public partial class Admin_dashboard : Form
    {
        public Admin_dashboard()
        {
            InitializeComponent();
        }
        //Set public static string to specify if the form is sales or purchase
        //public static string type; 


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abbey_Trading_Store.UI.registrationForm form = new Abbey_Trading_Store.UI.registrationForm();
            form.Show();
        }

        private void Admin_dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Login_form form = new Login_form();
            form.Show();
            this.Hide();
            Cursor = Cursors.Default;
        }

        private void Admin_dashboard_Load(object sender, EventArgs e)
        {

            user.Text = Login_form.user;
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor= Cursors.WaitCursor;
            frmCategory category = new frmCategory();
            category.Show();
            Cursor = Cursors.Default;
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmProducts product = new frmProducts();
            product.Show();
            Cursor = Cursors.Default;
        }

        private void dealerAndCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmDealerAndCustomer D_cust = new frmDealerAndCustomer();
            D_cust.Show();
            Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            registrationForm form = new registrationForm();
            form.Show();
            Cursor = Cursors.Default;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmCategory category = new frmCategory();
            category.Show();
            Cursor = Cursors.Default;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmProducts product = new frmProducts();
            product.Show();
            Cursor = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmDealerAndCustomer form = new frmDealerAndCustomer();
            form.Show();
            Cursor = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Inventory form = new Inventory();
            form.Show();
            Cursor = Cursors.Default;
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmTransactions form = new frmTransactions();
            //form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmTransactions form = new frmTransactions();
            form.Show();
            Cursor = Cursors.Default;
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Inventory form = new Inventory();
            form.Show();
            Cursor = Cursors.Default;
        }

        private void batchEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Batch_entry form = new Batch_entry();
            form.Show();
            Cursor = Cursors.Default;

        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmTransactions form = new frmTransactions();
            form.Show();
            Cursor = Cursors.Default;
        }

        private void manageDebtsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Debts form = new Debts();
            form.Show();
            Cursor = Cursors.Default;
        }

        private void purchasesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            frmUserDashboard.type = "Purchase";
            frmPurchaseandsales form = new frmPurchaseandsales();
            form.Show();
            Cursor = Cursors.Default;
        }
    }
}
