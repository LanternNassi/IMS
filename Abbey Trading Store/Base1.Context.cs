﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Abbey_Trading_Store
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IMSEntities : DbContext
    {
        public IMSEntities()
            : base("name=IMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
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
    }
}
