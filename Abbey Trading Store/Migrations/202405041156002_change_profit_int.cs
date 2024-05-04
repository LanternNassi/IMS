namespace Abbey_Trading_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_profit_int : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "Total_Profit", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "Total_Profit", c => c.String());
        }
    }
}
