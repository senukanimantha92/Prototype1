namespace InvoiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPayment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        Balance = c.Double(nullable: false),
                        Amount = c.Double(nullable: false),
                        PaymentMethod = c.String(),
                        PaymentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Payments", new[] { "CustomerID" });
            DropTable("dbo.Payments");
        }
    }
}
