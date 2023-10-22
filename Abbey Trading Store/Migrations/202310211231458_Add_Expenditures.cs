namespace Abbey_Trading_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Expenditures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expenditures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Amount = c.String(),
                        Added_by = c.String(),
                        Added_date = c.DateTime(nullable: false, defaultValueSql: "GetDate()"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Expenditures");
        }
    }
}
