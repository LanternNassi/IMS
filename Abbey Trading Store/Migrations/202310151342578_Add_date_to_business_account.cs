namespace Abbey_Trading_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_date_to_business_account : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusinessAccount",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Description = c.String(),
                        Tel_1 = c.String(maxLength: 50),
                        Tel_2 = c.String(maxLength: 50),
                        Tel_3 = c.String(maxLength: 50),
                        Valid = c.String(maxLength: 50),
                        Location = c.String(maxLength: 50),
                        Date_added = c.DateTime(nullable: false),
                        Server_id = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(maxLength: 255),
                        description = c.String(maxLength: 255),
                        added_date = c.DateTime(precision: 0, storeType: "datetime2"),
                        added_by = c.String(maxLength: 255),
                        Server_id = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.DealerCust",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        type = c.String(maxLength: 255),
                        Name = c.String(maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Contact = c.String(maxLength: 255),
                        address = c.String(maxLength: 255),
                        added_date = c.DateTime(precision: 0, storeType: "datetime2"),
                        added_by = c.String(maxLength: 255),
                        Server_id = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Modifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Action = c.String(maxLength: 255),
                        Reason = c.String(maxLength: 255),
                        Added_by = c.String(maxLength: 255),
                        added_date = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Product = c.String(maxLength: 255),
                        Category = c.String(maxLength: 255),
                        Description = c.String(maxLength: 255),
                        Rate = c.String(maxLength: 255),
                        Selling_price = c.String(maxLength: 255),
                        Quantity = c.Decimal(precision: 18, scale: 4),
                        Added_date = c.DateTime(precision: 0, storeType: "datetime2"),
                        Added_by = c.String(maxLength: 255),
                        Server_id = c.Int(),
                        Wholesale_price = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Transaction Details",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        product_name = c.String(maxLength: 255),
                        rate = c.Int(),
                        Qty = c.String(maxLength: 255),
                        total = c.Int(),
                        dea_cust_name = c.String(maxLength: 255),
                        added_date = c.DateTime(precision: 0, storeType: "datetime2"),
                        added_by = c.String(maxLength: 255),
                        Invoice_id = c.Int(),
                        Profit = c.String(maxLength: 255),
                        Type = c.String(maxLength: 255),
                        Server_id = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Transaction Tracker",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Transaction_id = c.Int(),
                        Paid_amount = c.String(maxLength: 255),
                        Added_date = c.DateTime(precision: 0, storeType: "datetime2"),
                        Updated_by = c.String(maxLength: 255),
                        Server_id = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        type = c.String(maxLength: 255),
                        dea_cust_name = c.String(maxLength: 255),
                        grandTotal = c.Int(),
                        transaction_date = c.DateTime(precision: 0, storeType: "datetime2"),
                        discount = c.Int(),
                        added_by = c.String(maxLength: 255),
                        Paid_amount = c.String(maxLength: 255),
                        Return_amount = c.Int(),
                        Total_Profit = c.String(maxLength: 255),
                        Paid = c.String(maxLength: 255),
                        Taken = c.String(maxLength: 255),
                        Server_id = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        User = c.String(maxLength: 255),
                        Contact = c.String(maxLength: 255),
                        Gender = c.String(maxLength: 255),
                        Added_by = c.String(maxLength: 255),
                        Type = c.String(maxLength: 255),
                        Server_id = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Transactions");
            DropTable("dbo.Transaction Tracker");
            DropTable("dbo.Transaction Details");
            DropTable("dbo.Products");
            DropTable("dbo.Modifications");
            DropTable("dbo.DealerCust");
            DropTable("dbo.Categories");
            DropTable("dbo.BusinessAccount");
        }
    }
}
