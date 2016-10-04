namespace InvoiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAmounttoInvoiceDetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.InvoiceDetails", "Amount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.InvoiceDetails", "Amount");
        }
    }
}
