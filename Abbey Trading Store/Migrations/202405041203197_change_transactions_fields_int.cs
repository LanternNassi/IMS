namespace Abbey_Trading_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_transactions_fields_int : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "grandTotal", c => c.Long());
            AlterColumn("dbo.Transactions", "Paid_amount", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "Paid_amount", c => c.String());
            AlterColumn("dbo.Transactions", "grandTotal", c => c.Int());
        }
    }
}
