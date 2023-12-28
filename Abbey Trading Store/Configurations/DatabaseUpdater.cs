using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using Abbey_Trading_Store.Migrations;
using Abbey_Trading_Store.DAL.DAL_Properties;
using System.Data.Entity;

namespace Abbey_Trading_Store.Configurations
{
    public class DatabaseUpdater
    {


        public void UpdateOrCreateDatabase()
        {

            // Check if the database exists
            using (var context = new Base2())
            {
                bool databaseExists = context.Database.Exists();

                if (databaseExists)
                {
                    Console.WriteLine("Database exists. Applying pending migrations...");
                    UpdateDatabase();
                }
                else
                {
                    Console.WriteLine("Database does not exist. Creating a new database...");
                    CreateDatabase();
                }
            }
        }

        private void UpdateDatabase()
        {
            string strComputerName = Environment.MachineName.ToString();
            string computed_server_name = strComputerName + @"\SQLSERVER2012";
            string local_server_database_conn_string = "Data Source=" + computed_server_name + ";Initial Catalog=IMSProd;Integrated Security=True;TrustServerCertificate=True";


            // Create a DbMigrator instance
            DbMigrator migrator = new DbMigrator(new Configuration()
            {
                TargetDatabase = new System.Data.Entity.Infrastructure.DbConnectionInfo(local_server_database_conn_string, "System.Data.SqlClient")
            });

            // Get pending migrations and apply them
            var pendingMigrations = migrator.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                Console.WriteLine("Pending Migrations to Apply:");
                foreach (var migration in pendingMigrations)
                {
                    Console.WriteLine("- " + migration);
                }
                migrator.Update();
                Console.WriteLine("Migrations applied successfully.");
            }
            else
            {
                Console.WriteLine("No pending migrations to apply.");
            }
        }

        private void CreateDatabase()
        {
            // Create the database and apply migrations to create schema
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Base2, Migrations.Configuration>());
            using (var context = new Base2())
            {
                context.Database.Initialize(true);
                Console.WriteLine("Database created and schema updated.");
            }
        }

    }
}
