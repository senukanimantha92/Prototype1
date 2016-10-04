namespace InvoiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInvoiceDetail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        InvoiceDetailID = c.Int(nullable: false, identity: true),
                        InvoiceMasterID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Qty = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceDetailID)
                .ForeignKey("dbo.InvoiceMasters", t => t.InvoiceMasterID, cascadeDelete: true)
                .ForeignKey("dbo.Items", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.InvoiceMasterID)
                .Index(t => t.ItemID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceDetails", "ItemID", "dbo.Items");
            DropForeignKey("dbo.InvoiceDetails", "InvoiceMasterID", "dbo.InvoiceMasters");
            DropIndex("dbo.InvoiceDetails", new[] { "ItemID" });
            DropIndex("dbo.InvoiceDetails", new[] { "InvoiceMasterID" });
            DropTable("dbo.InvoiceDetails");
        }
    }
}
