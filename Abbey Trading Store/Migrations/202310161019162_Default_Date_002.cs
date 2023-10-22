namespace Abbey_Trading_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Default_Date_002 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "added_date", c => c.DateTime(precision: 0, defaultValueSql: "GetDate()", storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "added_date", c => c.DateTime(precision: 0, storeType: "datetime2"));
        }
    }
}
