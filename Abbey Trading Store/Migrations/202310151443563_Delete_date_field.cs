namespace Abbey_Trading_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Delete_date_field : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BusinessAccount", "Date_added");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BusinessAccount", "Date_added", c => c.DateTime(nullable: false));
        }
    }
}
