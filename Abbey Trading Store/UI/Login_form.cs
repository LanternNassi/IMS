using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Abbey_Trading_Store.DAL;
using Abbey_Trading_Store.DAL.DAL_Properties;
using Abbey_Trading_Store.UI.Advanced;
using Abbey_Trading_Store.Configurations;


using Microsoft.SqlServer;
using Abbey_Trading_Store.UI.Advanced.Screen_forms;
//using Microsoft.SqlServer.ConnectionInfo.dll;
//using Microsoft.SqlServer.Management.Sdk.Sfc.dll;
//using Microsoft.SqlServer.Smo.dll;
//using Microsoft.SqlServer.SqlEnum;

namespace Abbey_Trading_Store.UI
{
    public partial class Login_form : Form
    {
        
        public Login_form()
        {


            

            InitializeComponent();

        }

        public static string user;
        public static string account_type;
        int active_index = 0;


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Control[] controls = { username, password, usertype_cmbx, button1 };
            switch (keyData)
            {
                //case Keys.Down:
                //    active_index += 1;
                //    controls[active_index].Focus();
                    
                //    break;
                //case Keys.Up:
                //    active_index -= 1;
                //    controls[active_index].Focus();
                //    break;
                case Keys.Enter:
                    button1_Click(this,null);
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        bool stopper = false;

        private void button1_Click(object sender, EventArgs e)
        {
            //Dashboard form = new Dashboard();
            //user = "User";
            //form.Show();


            Cursor = Cursors.WaitCursor;
            Dashboard form = new Dashboard();
            LoginDAL Login = new LoginDAL();
            Login.Username = username.Text;
            Login.Password = password.Text;
            Login.Usertype = usertype_cmbx.Text;
            string[] results = Login.LoginAppropriately();
            string admin_priviledge = usertype_cmbx.Text;
            if (results[0] == "True")
            {
                //MessageBox.Show("Login successful");
                user = Login.Username;
                account_type = Login.Usertype;
                //Open Respective dashboard
                switch (results[1])
                {
                    case "admin":
                        {
                            this.Hide();
                            Splashscreen ss = new Splashscreen();
                            ss.Show();
                            ss.Update();
                            System.Threading.Thread.Sleep(10000);
                            ss.Close();
                            if (admin_priviledge == "admin")
                            {
                                Admin_dashboard admin = new Admin_dashboard();
                                if (Env.layout ==1) {
                                    admin.Show();
                                } else
                                {
                                    form.Show();
                                }
                            }
                            else if (admin_priviledge == "normal")
                            {
                                //frmUserDashboard normal = new frmUserDashboard();
                                //normal.Show();
                                form.Show();
                            }


                        }
                        break;
                    case "normal":
                        {
                            if (admin_priviledge == "admin")
                            {
                                Cursor = Cursors.Default;
                                MessageBox.Show("You are trying to access an admin panel without administration rights.Please consider informing your administrator for more information");
                                this.Close();
                            }
                            else if (admin_priviledge == "normal")
                            {
                                this.Hide();
                                Splashscreen ss = new Splashscreen();
                                ss.Show();
                                ss.Update();
                                System.Threading.Thread.Sleep(10000);
                                ss.Close();
                                //frmUserDashboard normal = new frmUserDashboard();
                                //normal.Show();
                                form.Show();

                            }


                        }
                        break;
                    default:
                        {
                            Cursor = Cursors.Default;
                            MessageBox.Show("Invalid Usertype");
                        }
                        break;

                }
            }
            else
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Login Failed");
            }

        }

        private void Login_form_Load(object sender, EventArgs e)
        {
            username.Focus();
            
        }

        private void Login_form_Shown(object sender, EventArgs e)
        {
            
        }

        private void Login_form_VisibleChanged(object sender, EventArgs e)
        {

            //this.Hide();
            //frmSetup form = new frmSetup();
            //form.Show();
        }

        private void Login_form_BackColorChanged(object sender, EventArgs e)
        {
            

        }
    }
    }

