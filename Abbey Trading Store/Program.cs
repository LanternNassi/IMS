using Abbey_Trading_Store.DAL.DAL_Properties;
using Abbey_Trading_Store.UI;
using Abbey_Trading_Store.UI.Advanced.Screen_forms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceProcess;
using System.Windows.Forms;
using Abbey_Trading_Store.Configurations;

namespace Abbey_Trading_Store
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Testing if SQL server exists
            SqlConnection conn = new SqlConnection();

            try
            {
                
                //Applying migrations 
                DatabaseUpdater db_updater = new DatabaseUpdater();
                db_updater.UpdateOrCreateDatabase();

                //Application.Run(new Abbey_Trading_Store.UI.Advanced.Screen_forms.frmCompany());
                //Application.Run(new Abbey_Trading_Store.UI.Login_form());
                Login_form.user = "Nessim";
                Login_form.account_type = "admin";
                Application.Run(new Abbey_Trading_Store.UI.Advanced.Dashboard());


                //this.BackColor = Color.White;
            }
            catch (SqlException ex)
            {
                //Application.Run(new Abbey_Trading_Store.UI.Advanced.Screen_forms.frmSetup());

                try
                {
                    ServiceController service = new ServiceController("MSSQL$SQLSERVER2012");

                    if ((service.Status.Equals(ServiceControllerStatus.Stopped)) ||

                        (service.Status.Equals(ServiceControllerStatus.StopPending)))
                    {
                        service.Start();
                        Application.Run(new Abbey_Trading_Store.UI.Login_form());


                    }

                    else service.Stop();

                }
                catch (Exception ex2)
                {
                    Application.Run(new Abbey_Trading_Store.UI.Advanced.Screen_forms.frmSetup());
                }
                finally
                {

                }
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
