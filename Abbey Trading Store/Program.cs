using Abbey_Trading_Store.DAL.DAL_Properties;
using Abbey_Trading_Store.UI.Advanced.Screen_forms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceProcess;
using System.Windows.Forms;

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
                conn = new SqlConnection(Env.local_server_database_conn_string);
                Console.WriteLine("Testing SQL server...");
                conn.Open();
                Console.WriteLine("Testing SQL server successful...");
                //Application.Run(new Abbey_Trading_Store.UI.Advanced.Screen_forms.frmCompany());
                Application.Run(new Abbey_Trading_Store.UI.Login_form());

                //this.BackColor = Color.White;
            }
            catch (SqlException ex)
            {
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
