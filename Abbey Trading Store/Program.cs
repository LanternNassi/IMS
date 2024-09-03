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

using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Wmi;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using System.Diagnostics;

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
            //SqlConnection conn = new SqlConnection();

            bool IsServiceInstalled(string serviceName)
            {
                ServiceController[] services = ServiceController.GetServices();

                foreach (ServiceController service in services)
                {
                    if (service.ServiceName.Equals(serviceName, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }

                return false;
            }


            //Code above is stray

            try
            {

                bool client = IsServiceInstalled("IMSClient");
                bool server = IsServiceInstalled("IMSServer");

                if (client || server)
                {

                    if (server)
                    {

                      
                        Env.installation_type = "Server";

                        ////Applying migrations 
                        DatabaseUpdater db_updater = new DatabaseUpdater();
                        db_updater.UpdateOrCreateDatabase();

                        ////Application.Run(new Abbey_Trading_Store.UI.Advanced.Screen_forms.frmCompany());
                        ////Login_form.user = "Nessim";
                        ////Login_form.account_type = "admin";
                        ///Application.Run(new Abbey_Trading_Store.UI.Advanced.Dashboard());

                        Application.Run(new Abbey_Trading_Store.UI.Login_form());

                    }
                    else
                    {
                        Env.installation_type = "Client";

                        //Application.Run(new Abbey_Trading_Store.UI.Advanced.Screen_forms.frmSetup());
                        //Login_form.user = "Nessim";
                        //Login_form.account_type = "admin";

                        //Application.Run(new Abbey_Trading_Store.UI.Advanced.Dashboard());


                        Application.Run(new Abbey_Trading_Store.UI.Login_form());

                        


                    }

                }
                else
                {

                    Application.Run(new Abbey_Trading_Store.UI.Advanced.Screen_forms.frmSetup());

                }



            }
            catch (Exception ex)
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

                    else service.Start();

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
                //conn.Close();
            }

        }
    }
}
