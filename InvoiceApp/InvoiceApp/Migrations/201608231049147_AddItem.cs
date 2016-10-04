namespace InvoiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type = c.String(),
                        Cost = c.Double(nullable: false),
                        SalesPrice = c.Double(nullable: false),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "AccountID", "dbo.Accounts");
            DropIndex("dbo.Items", new[] { "AccountID" });
            DropTable("dbo.Accounts");
            DropTable("dbo.Items");
        }
    }
}
