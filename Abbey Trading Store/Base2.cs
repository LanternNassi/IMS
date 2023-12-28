using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using Abbey_Trading_Store.DAL.DAL_Properties;

namespace Abbey_Trading_Store
{
    public partial class Base2 : DbContext
    {

        static string strComputerName = Environment.MachineName.ToString();
        static string computed_server_name = strComputerName + @"\SQLSERVER2012";
        static string local_server_database_conn_string = "Data Source=" + computed_server_name + ";Initial Catalog=IMSProd;Integrated Security=True;TrustServerCertificate=True";

        public Base2()
            : base(local_server_database_conn_string)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Base2>());
        }

        public virtual DbSet<BusinessAccount> BusinessAccounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DealerCust> DealerCusts { get; set; }
        public virtual DbSet<Modification> Modifications { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Transaction_Detail> Transaction_Details { get; set; }
        public virtual DbSet<Transaction_Tracker> Transaction_Trackers { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Expenditure_Categories> Expenditure_Categories { get; set; }
        public virtual DbSet<Expenditures> Expenditures { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.added_date)
                .HasPrecision(0);

            modelBuilder.Entity<DealerCust>()
                .Property(e => e.added_date)
                .HasPrecision(0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Added_date)
                .HasPrecision(0);

            modelBuilder.Entity<Transaction_Detail>()
                .Property(e => e.added_date)
                .HasPrecision(0);

            modelBuilder.Entity<Transaction_Tracker>()
                .Property(e => e.Added_date)
                .HasPrecision(0);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.transaction_date)
                .HasPrecision(0);

            modelBuilder.Entity<Expenditure_Categories>()
                .Property(e => e.Added_date)
                .HasPrecision(0);

            modelBuilder.Entity<Expenditures>()
                .Property(e => e.Added_date)
                .HasPrecision(0);

            modelBuilder.Entity<Settings>()
                .Property(e => e.Date_configured)
                .HasPrecision(0);
        }
    }
}
