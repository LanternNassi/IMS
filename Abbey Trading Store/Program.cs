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

            // Specify the SQL Server instance name
            //string ComputerName = Environment.MachineName.ToString();
            //string strcomputed_server_name = ComputerName + @"\SQLSERVER2012";
            //string local_server_database_conn = "Data Source=" + strcomputed_server_name + ";Initial Catalog=Tes2;Integrated Security=True;TrustServerCertificate=True";

            //string serverInstanceName = strcomputed_server_name;

            //{
            //    ManagedComputer managedcomp = new ManagedComputer();
            //    MessageBox.Show(managedcomp.Urn.ToString());
            //    //foreach (ServerInstance serverInstance in managedcomp.ServerAliases)
            //    //{
            //    //    Console.WriteLine($"Server Name: {serverInstance.Name}");
            //    //    //Console.WriteLine($"Version: {serverInstance.VersionString}");
            //    //    //Console.WriteLine($"Edition: {serverInstance.Edition}");
            //    //    Console.WriteLine();
            //    //}
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //var serverInstance = managedcomp.ServerInstances[""];
            //var tcpProtocol = serverInstance?.ServerProtocols["Tcp"];


            //// Enable the TCP protocol if it's not already enabled
            //if (!tcpProtocol.IsEnabled)
            //{
            //    tcpProtocol.IsEnabled = true;
            //    tcpProtocol.Alter();
            //    Console.WriteLine("TCP protocol enabled successfully.");
            //}
            //else
            //{
            //    Console.WriteLine("TCP protocol is already enabled.");
            //}


            //string test_str = "SQLSERVER2012";
            //var managedComp = new ManagedComputer();
            //var urn = new Urn($"ManagedComputer[@Name='{Environment.MachineName}']/ServerProtocol[@Name='Tcp']");
            //ServerProtocol sp;
            //sp = (ServerProtocol)managedComp.GetSmoObject(urn);

            //sp.IsEnabled = true;

            //sp.Alter();

            //Console.WriteLine("TCP protocol enabled successfully.");


            

            //Code above is stray

            try
            {

                bool client = IsServiceInstalled("IMSClient");
                bool server = IsServiceInstalled("IMSServer");

                if (client || server)
                {

                    if (server)
                    {

                      
                        //string strComputerName = Environment.MachineName.ToString();
                        //string computed_server_name = strComputerName + @"\SQLSERVER2012";
                        //string local_server_database_conn_string = "Data Source=" + computed_server_name + ";Initial Catalog=IMSProd;Integrated Security=True;TrustServerCertificate=True";
                        
                        //Env.local_server_database_conn_string = local_server_database_conn_string;
                        Env.installation_type = "Server";
                        ////Applying migrations 
                        DatabaseUpdater db_updater = new DatabaseUpdater();
                        db_updater.UpdateOrCreateDatabase();

                        ////Application.Run(new Abbey_Trading_Store.UI.Advanced.Screen_forms.frmCompany());
                        //Application.Run(new Abbey_Trading_Store.UI.Login_form());
                        ////Login_form.user = "Nessim";
                        ////Login_form.account_type = "admin";
                        ////Application.Run(new Abbey_Trading_Store.UI.Advanced.Dashboard());


                        ////this.BackColor = Color.White;\
                        ///

                        //Application.Run(new Abbey_Trading_Store.UI.Advanced.Screen_forms.frmSetup());

                        Application.Run(new Abbey_Trading_Store.UI.Login_form());

                    }
                    else
                    {
                        Env.installation_type = "Client";

                        //Application.Run(new Abbey_Trading_Store.UI.Advanced.Screen_forms.frmSetup());


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
