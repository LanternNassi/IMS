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
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using AfricasTalkingCS;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

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
        public static frmExpenditures active_exp_form = null;
        public static System.Threading.Timer timer = null;
        private System.Timers.Timer backupTimer;


        public Dashboard()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            //this.Size = Screen.PrimaryScreen.Bounds.Size;

            DataRow Get_business_details()
            {
                SqlDataAdapter adapter = DAL.BusinessAccount.Select();
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt.Rows[0];
            }



            // Business Details
            DataRow business_dr = Get_business_details();

            Env.BusinessName = business_dr[1].ToString();
            Env.BusinessDescription = business_dr[2].ToString();
            Env.Tel_1 = business_dr[3].ToString();
            Env.Tel_2 = business_dr[4].ToString();
            Env.Tel_3 = business_dr[5].ToString();
            Env.Valid = business_dr[6].ToString();
            Env.Location = business_dr[7].ToString();

            System.Drawing.Rectangle workingRectangle =
                Screen.PrimaryScreen.WorkingArea;

            // Set the size of the form slightly less than size of 
            // working rectangle.
            this.Size = LayoutFlex.working_size;

            top_panel.Height = Convert.ToInt32(0.166 * this.Size.Height);
            panel4.Height = panel10.Height = top_panel.Height / 2;
            panel5.Width = panel6.Height = panel8.Width = Convert.ToInt32(0.45 * panel4.Width) / 3;
            panel7.Width = Convert.ToInt32(0.43 * panel4.Width);
            panel9.Width = panel4.Width - ((panel5.Width * 3) + panel7.Width);


            panel11.Width = panel12.Width = Convert.ToInt32(0.45 * panel10.Width)/2;

            // Set the location so the entire form is visible.
            this.Location = new System.Drawing.Point(5, 5);
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            PnlContainer = pnlform.Size;

            //this.pnlform.Height = LayoutFlex.overall_container_height;
            //this.top_panel.Height = LayoutFlex.top_panel_height;
            //DataTable dt = new DataTable();
            //Env.account_adapter.Fill(dt);

            CompanyName.Text = Env.BusinessName;

            Settings settings = SettingsConfig.GetSettings(1);
            Env.AppVersion = settings.AppVersion;
            Env.Messages = settings.Messages;
            Env.MessageAPIKey = settings.MessageAPIKey;
            Env.MessageUsername = settings.MessageUsername;
            Env.MessageFrom = settings.MessageFrom;
            Env.Active = settings.Active;
            Env.Date_configured = Convert.ToDateTime(settings.Date_configured);
            Env.MessageGateway = new AfricasTalkingGateway(settings.MessageUsername,settings.MessageAPIKey);
            Env.ClientId = settings.ClientId;
            Env.ValidTill = settings.ValidTill;

            if (bool.Parse(Env.Messages))
            {
                materialButton3.Enabled = false;
            }

            else
            {
                materialButton3.Enabled = true;
            }

            //Setting up the backUp mechanism
            backupTimer = new System.Timers.Timer();
            backupTimer.Interval = 1000; // 1 second
            backupTimer.Elapsed += BackupTimer_Tick;
            SetBackupTime(14, 0, 0); // Set backup time to 5:00:00 PM
            backupTimer.Start();

        }


        private void BackupTimer_Tick(object sender, EventArgs e)
        {
            //MessageBox.Show("Event raised");
            DateTime now = DateTime.Now;
            if (now.Hour == 14 && now.Minute == 0 && now.Second == 0)
            {
                SettingsConfig.CreateBackUp(Env.ClientId);
            }
        }

        private void SetBackupTime(int hour, int minute, int second)
        {
            TimeSpan timeUntilBackup = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, second) - DateTime.Now;
            if (timeUntilBackup.TotalMilliseconds < 0)
            {
                timeUntilBackup = timeUntilBackup.Add(new TimeSpan(24, 0, 0)); // Add 24 hours to the time if it's already passed for today
            }

            backupTimer.Interval = timeUntilBackup.TotalMilliseconds;
        }




        private async void CheckForUpdates(object state)
        {
            try
            {

                dynamic latest_release_info = await frmSetup.FetchData("https://api.github.com/repos/LanternNassi/IMS/releases/latest" , false);
                string numericPart = Regex.Replace(Convert.ToString(latest_release_info["tag_name"]), "[^0-9]", "");
                if (int.TryParse(numericPart, out int versionNumber))
                {
                    if (Convert.ToInt32(Env.AppVersion) < versionNumber)
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            materialButton5.Enabled = true;
                        });
                    }
                }

            }
            catch(Exception ex)
            {

            }
            finally
            {

            }
            
            

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

        private async void Dashboard_Load(object sender, EventArgs e)
        {

            

            timer = new System.Threading.Timer(CheckForUpdates, null, TimeSpan.Zero, TimeSpan.FromMinutes(15));



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
                button3.Enabled = true;

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
                button3.Enabled = true;
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
            timer.Dispose();

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

        private void Dashboard_Layout(object sender, LayoutEventArgs e)
        {
            // Aligning the panels 


        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            pnlNav.Height = button3.Height;
            pnlNav.Top = button3.Top;
            pnlNav.Left = button3.Left;
            button3.BackColor = Color.FromArgb(46, 51, 73);
            lblTitle.Text = "Expenditures";
            this.pnlform.Controls.Clear();
            Screen_forms.frmExpenditures FrmExpend = new Screen_forms.frmExpenditures() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FrmExpend.FormBorderStyle = FormBorderStyle.None;
            this.pnlform.Controls.Add(FrmExpend);
            FrmExpend.Show();

            active_exp_form = FrmExpend;

        }

        private void button3_Leave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            UpdateScreen form = new UpdateScreen(this);
            form.Show();
        }
    }
}
