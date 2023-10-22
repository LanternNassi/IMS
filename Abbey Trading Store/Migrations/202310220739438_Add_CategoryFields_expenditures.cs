namespace Abbey_Trading_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_CategoryFields_expenditures : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Expenditures", "Overall_category", c => c.String());
            AddColumn("dbo.Expenditures", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Expenditures", "Category");
            DropColumn("dbo.Expenditures", "Overall_category");
        }
    }
}
