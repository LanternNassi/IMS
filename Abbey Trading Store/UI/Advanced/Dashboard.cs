using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Abbey_Trading_Store.UI;
using MaterialSkin;
using Abbey_Trading_Store.UI.Advanced.Screen_forms;
using System.Net;
using System.Threading;
using Abbey_Trading_Store.DAL.DAL_Properties;
using Abbey_Trading_Store.DAL;

namespace Abbey_Trading_Store.UI.Advanced
{
    public partial class Dashboard : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
       (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
           int nHeightEllipse

        );

        public frmUser active_form = null;
        public static System.Drawing.Size PnlContainer;


        public Dashboard()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            //this.Size = Screen.PrimaryScreen.Bounds.Size;

            System.Drawing.Rectangle workingRectangle =
                Screen.PrimaryScreen.WorkingArea;

            // Set the size of the form slightly less than size of 
            // working rectangle.
            this.Size = LayoutFlex.working_size;

            // Set the location so the entire form is visible.
            this.Location = new System.Drawing.Point(5, 5);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            PnlContainer = pnlform.Size;

            //this.pnlform.Height = LayoutFlex.overall_container_height;
            //this.top_panel.Height = LayoutFlex.top_panel_height;
            //DataTable dt = new DataTable();
            //Env.account_adapter.Fill(dt);

            //CompanyName.Text = dt.Rows[0][1].ToString();

        }


        private void btnDashboard_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashboard.Height;
            pnlNav.Top = btnDashboard.Top;
            pnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);
            //search.Visible = true;
            lblTitle.Text = "Overview";
            this.pnlform.Controls.Clear();
            Overview FrmDashboard_Vrb = new Overview() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true, Visible = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlform.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

            if (Login_form.account_type == "admin")
            {
                //Switching on the panels
                btnDashboard.Enabled = true;
                btnUsers.Enabled = true;
                btnCategories.Enabled = true;
                btnProducts.Enabled = true;
                btnCustomers.Enabled = true;
                btnTransactions.Enabled = true;
                btnPurchases.Enabled = true;
                button1.Enabled = true;
                button2.Enabled= true;
                materialButton2.Enabled = true;
                materialButton3.Enabled = true;
                materialButton4.Enabled = true;

                pnlNav.Height = btnDashboard.Height;
                pnlNav.Top = btnDashboard.Top;
                pnlNav.Left = btnDashboard.Left;
                btnDashboard.BackColor = Color.FromArgb(46, 51, 73);
                //search.Visible = true;
                lblTitle.Text = "Overview";
                this.pnlform.Controls.Clear();
                Overview FrmDashboard_Vrb = new Overview() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
                FrmDashboard_Vrb.Height = LayoutFlex.overall_container_height;
                this.pnlform.Controls.Add(FrmDashboard_Vrb);
                FrmDashboard_Vrb.Show();
                Username.Text = Login_form.user;

                //Getting the quick fixes 
                product Product = new product();
                DataTable dt = Product.Select_Modifications();
                materialButton4.Text = "Quick fixes (" + dt.Rows.Count.ToString() + ")";
            }
            else
            {
                pnlNav.Height = btnSales.Height;
                pnlNav.Top = btnSales.Top;
                pnlNav.Left = btnSales.Left;
                btnSales.BackColor = Color.FromArgb(46, 51, 73);
                lblTitle.Text = "Sales";
                this.pnlform.Controls.Clear();
                Username.Text = Login_form.user;
                Screen_forms.frmPurchaseAndSales FrmSales = new Screen_forms.frmPurchaseAndSales("Sales") { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                FrmSales.FormBorderStyle = FormBorderStyle.None;
                this.pnlform.Controls.Add(FrmSales);
                FrmSales.Show();

            }

            
        }

        

        private void btnUsers_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnUsers.Height;
            pnlNav.Top = btnUsers.Top;
            pnlNav.Left = btnUsers.Left;
            btnUsers.BackColor = Color.FromArgb(46, 51, 73);
            //search.Visible = true;
            lblTitle.Text = "Users";
            this.pnlform.Controls.Clear();
            //registrationForm FrmDashboard_Vrb = new registrationForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmUser FrmDashboard_Vrb = new frmUser() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDashboard_Vrb.FormBorderStyle = FormBorderStyle.None;
            FrmDashboard_Vrb.Height = LayoutFlex.overall_container_height;
            this.pnlform.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
            active_form = FrmDashboard_Vrb;

        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            //search.Visible = false;
            pnlNav.Height = btnCategories.Height;
            pnlNav.Top = btnCategories.Top;
            pnlNav.Left = btnCategories.Left;
            btnCategories.BackColor = Color.FromArgb(46, 51, 73);
            lblTitle.Text = "Categories";
            this.pnlform.Controls.Clear();
            frmCategories FrmCategory = new frmCategories() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmCategory.FormBorderStyle = FormBorderStyle.None;
            this.pnlform.Controls.Add(FrmCategory); 
            FrmCategory.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            //search.Visible = false;
            pnlNav.Height = btnProducts.Height;
            pnlNav.Top = btnProducts.Top;
            pnlNav.Left = btnProducts.Left;
            btnProducts.BackColor = Color.FromArgb(46, 51, 73);
            lblTitle.Text = "Products";
            this.pnlform.Controls.Clear();
            Screen_forms.frmProducts FrmProducts = new Screen_forms.frmProducts() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmProducts.FormBorderStyle = FormBorderStyle.None;
            this.pnlform.Controls.Add(FrmProducts);
            FrmProducts.Show();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnCustomers.Height;
            pnlNav.Top = btnCustomers.Top;
            pnlNav.Left = btnCustomers.Left;
            btnCustomers.BackColor = Color.FromArgb(46, 51, 73);
            lblTitle.Text = "Customers";
            this.pnlform.Controls.Clear();  
            Screen_forms.frmDealCust FrmCustomers = new Screen_forms.frmDealCust() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmCustomers.FormBorderStyle = FormBorderStyle.None;
            this.pnlform.Controls.Add(FrmCustomers);
            FrmCustomers.Show();

        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnTransactions.Height;
            pnlNav.Top = btnTransactions.Top;
            pnlNav.Left = btnTransactions.Left;
            btnTransactions.BackColor = Color.FromArgb(46, 51, 73);
            lblTitle.Text = "Transactions";
            this.pnlform.Controls.Clear();  
            Screen_forms.frmTransactions FrmTransact = new Screen_forms.frmTransactions() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmTransact.FormBorderStyle = FormBorderStyle.None;
            this.pnlform.Controls.Add(FrmTransact);
            FrmTransact.Show();
        }

        private void btnPurchases_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnPurchases.Height;
            pnlNav.Top = btnPurchases.Top;
            pnlNav.Left = btnPurchases.Left;
            btnPurchases.BackColor = Color.FromArgb(46, 51, 73);
            lblTitle.Text = "Purchase";
            this.pnlform.Controls.Clear();
            Screen_forms.frmPurchaseAndSales FrmSales = new Screen_forms.frmPurchaseAndSales("Purchase") { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmSales.FormBorderStyle = FormBorderStyle.None;
            this.pnlform.Controls.Add(FrmSales);
            FrmSales.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnUsers_Leave(object sender, EventArgs e)
        {
            btnUsers.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnCategories_Leave(object sender, EventArgs e)
        {
            btnCategories.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnProducts_Leave(object sender, EventArgs e)
        {
            btnProducts.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnCustomers_Leave(object sender, EventArgs e)
        {
            btnCustomers.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnTransactions_Leave(object sender, EventArgs e)
        {
            btnTransactions.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnPurchases_Leave(object sender, EventArgs e)
        {
            btnPurchases.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnSales_Leave(object sender, EventArgs e)
        {
            btnSales.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            if (active_form != null)
            {
                active_form.search_users();
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
            Login_form form = new Login_form();
            form.Show();
            
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnSales.Height;
            pnlNav.Top = btnSales.Top;
            pnlNav.Left = btnSales.Left;
            btnSales.BackColor = Color.FromArgb(46, 51, 73);
            lblTitle.Text = "Sales";
            this.pnlform.Controls.Clear();
            Screen_forms.frmPurchaseAndSales FrmSales = new Screen_forms.frmPurchaseAndSales("Sales") { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmSales.FormBorderStyle = FormBorderStyle.None;
            this.pnlform.Controls.Add(FrmSales);
            FrmSales.Show();

        }

        private void button1_Click(object sender, EventArgs e)

        {
            pnlNav.Height = button1.Height;
            pnlNav.Top = button1.Top;
            pnlNav.Left = button1.Left;
            button1.BackColor = Color.FromArgb(46, 51, 73);
            lblTitle.Text = "Details Analysis";
            this.pnlform.Controls.Clear();
            Screen_forms.frmAnalysis FrmAnalysis = new Screen_forms.frmAnalysis() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmAnalysis.FormBorderStyle = FormBorderStyle.None;
            this.pnlform.Controls.Add(FrmAnalysis);
            FrmAnalysis.Show();
        }

        private void button1_Leave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlNav.Height = button2.Height;
            pnlNav.Top = button2.Top;
            pnlNav.Left = button2.Left;
            button2.BackColor = Color.FromArgb(46, 51, 73);
            lblTitle.Text = "Debts";
            this.pnlform.Controls.Clear();
            Screen_forms.frmDebts FrmDebts = new Screen_forms.frmDebts() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmDebts.FormBorderStyle = FormBorderStyle.None;
            this.pnlform.Controls.Add(FrmDebts);
            FrmDebts.Show();

        }

        private void button2_Leave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            Screen_forms.BatchUpload  FrmUpload = new Screen_forms.BatchUpload();
            FrmUpload.Show();

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            QuickProducts form = new QuickProducts();
            form.Show();
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            //DealerAndCustomer cust = new DealerAndCustomer();
            //DataTable dt = cust.BulkSendCustomerContacts();
            //bool success = cust.SendMessage(dt, "Hello <<Name>> , How are you doing from MMAK Agro Chemicals . Is <<Contact>> your phone number ?" , false);
            CustomMessage form = new CustomMessage();
            form.Show();


        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            Modifications form = new Modifications();
            form.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnUsers_Move(object sender, EventArgs e)
        {
            MessageBox.Show("Users panel being moved");
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
