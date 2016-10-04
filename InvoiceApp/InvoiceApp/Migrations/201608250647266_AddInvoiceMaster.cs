namespace InvoiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInvoiceMaster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceMasters",
                c => new
                    {
                        InvoiceMasterID = c.Int(nullable: false, identity: true),
                        InvoiceNo = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Memo = c.String(),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceMasterID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceMasters", "CustomerID", "dbo.Customers");
            DropIndex("dbo.InvoiceMasters", new[] { "CustomerID" });
            DropTable("dbo.InvoiceMasters");
        }
    }
}
