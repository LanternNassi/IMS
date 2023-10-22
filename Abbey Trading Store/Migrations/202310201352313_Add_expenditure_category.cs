namespace Abbey_Trading_Store.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_expenditure_category : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BusinessAccount", newName: "BusinessAccounts");
            RenameTable(name: "dbo.DealerCust", newName: "DealerCusts");
            RenameTable(name: "dbo.Transaction Details", newName: "Transaction_Detail");
            RenameTable(name: "dbo.Transaction Tracker", newName: "Transaction_Tracker");
            CreateTable(
                "dbo.Expenditure_Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Overall_category = c.String(),
                        Description = c.String(),
                        Added_by = c.String(),
                        Added_date = c.DateTime(nullable: false, defaultValueSql: "GetDate()"),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.BusinessAccounts", "Name", c => c.String());
            AlterColumn("dbo.BusinessAccounts", "Tel_1", c => c.String());
            AlterColumn("dbo.BusinessAccounts", "Tel_2", c => c.String());
            AlterColumn("dbo.BusinessAccounts", "Tel_3", c => c.String());
            AlterColumn("dbo.BusinessAccounts", "Valid", c => c.String());
            AlterColumn("dbo.BusinessAccounts", "Location", c => c.String());
            AlterColumn("dbo.Categories", "title", c => c.String());
            AlterColumn("dbo.Categories", "description", c => c.String());
            AlterColumn("dbo.Categories", "added_date", c => c.DateTime(defaultValueSql: "GetDate()"));
            AlterColumn("dbo.Categories", "added_by", c => c.String());
            AlterColumn("dbo.DealerCusts", "type", c => c.String());
            AlterColumn("dbo.DealerCusts", "Name", c => c.String());
            AlterColumn("dbo.DealerCusts", "Email", c => c.String());
            AlterColumn("dbo.DealerCusts", "Contact", c => c.String());
            AlterColumn("dbo.DealerCusts", "address", c => c.String());
            AlterColumn("dbo.DealerCusts", "added_date", c => c.DateTime(defaultValueSql: "GetDate()"));
            AlterColumn("dbo.DealerCusts", "added_by", c => c.String());
            AlterColumn("dbo.Modifications", "Action", c => c.String());
            AlterColumn("dbo.Modifications", "Reason", c => c.String());
            AlterColumn("dbo.Modifications", "Added_by", c => c.String());
            AlterColumn("dbo.Modifications", "added_date", c => c.DateTimeOffset(precision: 7, defaultValueSql: "GetDate()"));
            AlterColumn("dbo.Products", "product", c => c.String());
            AlterColumn("dbo.Products", "Category", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Rate", c => c.String());
            AlterColumn("dbo.Products", "Selling_price", c => c.String());
            AlterColumn("dbo.Products", "Added_date", c => c.DateTime(defaultValueSql: "GetDate()"));
            AlterColumn("dbo.Products", "Added_by", c => c.String());
            AlterColumn("dbo.Products", "Wholesale_price", c => c.String());
            AlterColumn("dbo.Transaction_Detail", "product_name", c => c.String());
            AlterColumn("dbo.Transaction_Detail", "Qty", c => c.String());
            AlterColumn("dbo.Transaction_Detail", "dea_cust_name", c => c.String());
            AlterColumn("dbo.Transaction_Detail", "added_date", c => c.DateTime(defaultValueSql: "GetDate()"));
            AlterColumn("dbo.Transaction_Detail", "added_by", c => c.String());
            AlterColumn("dbo.Transaction_Detail", "Profit", c => c.String());
            AlterColumn("dbo.Transaction_Detail", "Type", c => c.String());
            AlterColumn("dbo.Transaction_Tracker", "Paid_amount", c => c.String());
            AlterColumn("dbo.Transaction_Tracker", "Added_date", c => c.DateTime(defaultValueSql: "GetDate()"));
            AlterColumn("dbo.Transaction_Tracker", "Updated_by", c => c.String());
            AlterColumn("dbo.Transactions", "type", c => c.String());
            AlterColumn("dbo.Transactions", "dea_cust_name", c => c.String());
            AlterColumn("dbo.Transactions", "transaction_date", c => c.DateTime(defaultValueSql: "GetDate()"));
            AlterColumn("dbo.Transactions", "added_by", c => c.String());
            AlterColumn("dbo.Transactions", "Paid_amount", c => c.String());
            AlterColumn("dbo.Transactions", "Total_Profit", c => c.String());
            AlterColumn("dbo.Transactions", "Paid", c => c.String());
            AlterColumn("dbo.Transactions", "Taken", c => c.String());
            AlterColumn("dbo.Users", "user", c => c.String());
            AlterColumn("dbo.Users", "Contact", c => c.String());
            AlterColumn("dbo.Users", "Gender", c => c.String());
            AlterColumn("dbo.Users", "Added_by", c => c.String());
            AlterColumn("dbo.Users", "Type", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Type", c => c.String(maxLength: 255));
            AlterColumn("dbo.Users", "Added_by", c => c.String(maxLength: 255));
            AlterColumn("dbo.Users", "Gender", c => c.String(maxLength: 255));
            AlterColumn("dbo.Users", "Contact", c => c.String(maxLength: 255));
            AlterColumn("dbo.Users", "user", c => c.String(maxLength: 255));
            AlterColumn("dbo.Transactions", "Taken", c => c.String(maxLength: 255));
            AlterColumn("dbo.Transactions", "Paid", c => c.String(maxLength: 255));
            AlterColumn("dbo.Transactions", "Total_Profit", c => c.String(maxLength: 255));
            AlterColumn("dbo.Transactions", "Paid_amount", c => c.String(maxLength: 255));
            AlterColumn("dbo.Transactions", "added_by", c => c.String(maxLength: 255));
            AlterColumn("dbo.Transactions", "transaction_date", c => c.DateTime(precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.Transactions", "dea_cust_name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Transactions", "type", c => c.String(maxLength: 255));
            AlterColumn("dbo.Transaction_Tracker", "Updated_by", c => c.String(maxLength: 255));
            AlterColumn("dbo.Transaction_Tracker", "Added_date", c => c.DateTime(precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.Transaction_Tracker", "Paid_amount", c => c.String(maxLength: 255));
            AlterColumn("dbo.Transaction_Detail", "Type", c => c.String(maxLength: 255));
            AlterColumn("dbo.Transaction_Detail", "Profit", c => c.String(maxLength: 255));
            AlterColumn("dbo.Transaction_Detail", "added_by", c => c.String(maxLength: 255));
            AlterColumn("dbo.Transaction_Detail", "added_date", c => c.DateTime(precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.Transaction_Detail", "dea_cust_name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Transaction_Detail", "Qty", c => c.String(maxLength: 255));
            AlterColumn("dbo.Transaction_Detail", "product_name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Products", "Wholesale_price", c => c.String(maxLength: 255));
            AlterColumn("dbo.Products", "Added_by", c => c.String(maxLength: 255));
            AlterColumn("dbo.Products", "Added_date", c => c.DateTime(precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.Products", "Selling_price", c => c.String(maxLength: 255));
            AlterColumn("dbo.Products", "Rate", c => c.String(maxLength: 255));
            AlterColumn("dbo.Products", "Description", c => c.String(maxLength: 255));
            AlterColumn("dbo.Products", "Category", c => c.String(maxLength: 255));
            AlterColumn("dbo.Products", "product", c => c.String(maxLength: 255));
            AlterColumn("dbo.Modifications", "added_date", c => c.DateTimeOffset(precision: 7));
            AlterColumn("dbo.Modifications", "Added_by", c => c.String(maxLength: 255));
            AlterColumn("dbo.Modifications", "Reason", c => c.String(maxLength: 255));
            AlterColumn("dbo.Modifications", "Action", c => c.String(maxLength: 255));
            AlterColumn("dbo.DealerCusts", "added_by", c => c.String(maxLength: 255));
            AlterColumn("dbo.DealerCusts", "added_date", c => c.DateTime(precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.DealerCusts", "address", c => c.String(maxLength: 255));
            AlterColumn("dbo.DealerCusts", "Contact", c => c.String(maxLength: 255));
            AlterColumn("dbo.DealerCusts", "Email", c => c.String(maxLength: 255));
            AlterColumn("dbo.DealerCusts", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.DealerCusts", "type", c => c.String(maxLength: 255));
            AlterColumn("dbo.Categories", "added_by", c => c.String(maxLength: 255));
            AlterColumn("dbo.Categories", "added_date", c => c.DateTime(precision: 0, storeType: "datetime2"));
            AlterColumn("dbo.Categories", "description", c => c.String(maxLength: 255));
            AlterColumn("dbo.Categories", "title", c => c.String(maxLength: 255));
            AlterColumn("dbo.BusinessAccounts", "Location", c => c.String(maxLength: 50));
            AlterColumn("dbo.BusinessAccounts", "Valid", c => c.String(maxLength: 50));
            AlterColumn("dbo.BusinessAccounts", "Tel_3", c => c.String(maxLength: 50));
            AlterColumn("dbo.BusinessAccounts", "Tel_2", c => c.String(maxLength: 50));
            AlterColumn("dbo.BusinessAccounts", "Tel_1", c => c.String(maxLength: 50));
            AlterColumn("dbo.BusinessAccounts", "Name", c => c.String(maxLength: 50));
            DropTable("dbo.Expenditure_Categories");
            RenameTable(name: "dbo.Transaction_Tracker", newName: "Transaction Tracker");
            RenameTable(name: "dbo.Transaction_Detail", newName: "Transaction Details");
            RenameTable(name: "dbo.DealerCusts", newName: "DealerCust");
            RenameTable(name: "dbo.BusinessAccounts", newName: "BusinessAccount");
        }
    }
}
