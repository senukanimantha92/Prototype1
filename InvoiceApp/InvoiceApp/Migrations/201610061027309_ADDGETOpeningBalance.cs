namespace InvoiceApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ADDGETOpeningBalance : DbMigration
    {
        public override void Up()
        {
            Sql(@"CREATE PROCEDURE GETOpeningBalance( @customer int)
                AS
                BEGIN
                DECLARE @Total FLOAT;
                DECLARE @Payment FLOAT;
                DECLARE @Balance FLOAT;

                SELECT @Total =  SUM(InvoiceMasters.Total) FROM InvoiceMasters WHERE CustomerID = @customer;
                SELECT @Payment = SUM(Payments.Amount) FROM Payments WHERE CustomerID = @customer;

                SET @Balance =  COALESCE( @Total,0) - COALESCE( @Payment,0);

                SELECT @Balance;
                END");
        }
        
        public override void Down()
        {
        }
    }
}
