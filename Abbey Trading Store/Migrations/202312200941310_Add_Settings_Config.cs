namespace Abbey_Trading_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Settings_Config : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        AppVersion = c.String(),
                        Messages = c.String(),
                        MessageAPIKey = c.String(),
                        MessageUsername = c.String(),
                        MessageFrom = c.String(),
                        Active = c.String(),
                        Date_configured = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Settings");
        }
    }
}
