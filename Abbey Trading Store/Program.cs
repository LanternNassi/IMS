﻿using Abbey_Trading_Store.DAL.DAL_Properties;
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

        static bool IsServiceInstalled(string serviceName)
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
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Testing if SQL server exists
            //SqlConnection conn = new SqlConnection();
            

            try
            {

                bool client = IsServiceInstalled("IMSClient");
                bool server = IsServiceInstalled("IMSServer");

                if (client || server)
                {

                    if (client)
                    {

                        string variableValue = Environment.GetEnvironmentVariable("IMS_conn_string");
                        //SqlConnection conn_1 = new SqlConnection();
                        try
                        {
                            SqlConnection conn_2 = new SqlConnection(variableValue);
                            //conn_1 = conn_2;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("The server to which this client installation belongs cannot be found");
                            return;
                        }
                        finally
                        {

                        }


                        string strComputerName = Environment.MachineName.ToString();
                        string computed_server_name = strComputerName + @"\SQLSERVER2012";
                        string local_server_database_conn_string = "Data Source=" + computed_server_name + ";Initial Catalog=Tes2;Integrated Security=True;TrustServerCertificate=True";
                        Environment.SetEnvironmentVariable("IMS_conn_string", local_server_database_conn_string, EnvironmentVariableTarget.Process);
                        //Env.local_server_database_conn_string = variableValue;
                        ////Applying migrations 
                        DatabaseUpdater db_updater = new DatabaseUpdater();
                        db_updater.UpdateOrCreateDatabase();

                        ////Application.Run(new Abbey_Trading_Store.UI.Advanced.Screen_forms.frmCompany());
                        //Application.Run(new Abbey_Trading_Store.UI.Login_form());
                        ////Login_form.user = "Nessim";
                        ////Login_form.account_type = "admin";
                        ////Application.Run(new Abbey_Trading_Store.UI.Advanced.Dashboard());


                        ////this.BackColor = Color.White;\
                        Application.Run(new Abbey_Trading_Store.UI.Login_form());

                    }

                }
                else
                {
                    Application.Run(new Abbey_Trading_Store.UI.Advanced.Screen_forms.frmSetup());

                }

                //Application.Run(new Abbey_Trading_Store.UI.Login_form());


            }
            catch (Exception ex)
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
                //conn.Close();
            }

        }
    }
}
