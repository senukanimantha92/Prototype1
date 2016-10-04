namespace InvoiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTotaltoInvoiceMaster : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceMasters", "Total", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InvoiceMasters", "Total");
        }
    }
}
