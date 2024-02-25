namespace Abbey_Trading_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BackupConfig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "ClientId", c => c.String());
            AddColumn("dbo.Settings", "ValidTill", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "ValidTill");
            DropColumn("dbo.Settings", "ClientId");
        }
    }
}
