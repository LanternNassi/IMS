namespace Abbey_Trading_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Default_Date_003 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DealerCust", "added_date", c => c.DateTime(precision: 0, defaultValueSql: "GetDate()", storeType: "datetime2"));
            AlterColumn("dbo.Modifications", "added_date", c => c.DateTimeOffset(precision: 7, defaultValueSql: "GetDate()"));
            AlterColumn("dbo.Products", "Added_date", c => c.DateTime(precision: 0, defaultValueSql: "GetDate()", storeType: "datetime2"));
            AlterColumn("dbo.Transaction Details", "added_date", c => c.DateTime(precision: 0, defaultValueSql: "GetDate()", storeType: "datetime2"));
            AlterColumn("dbo.Transaction Tracker", "Added_date", c => c.DateTime(precision: 0, defaultValueSql: "GetDate()", storeType: "datetime2"));
            AlterColumn("dbo.Transactions", "transaction_date", c => c.DateTime(precision: 0, defaultValueSql: "GetDate()", storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "transaction_date", c => c.DateTime(precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.Transaction Tracker", "Added_date", c => c.DateTime(precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.Transaction Details", "added_date", c => c.DateTime(precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.Products", "Added_date", c => c.DateTime(precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.Modifications", "added_date", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.DealerCust", "added_date", c => c.DateTime(precision: 0, storeType: "datetime2"));
        }
    }
}
