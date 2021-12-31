namespace SelfServicePump.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agents",
                c => new
                    {
                        AgentId = c.Guid(nullable: false),
                        AgentEmailAddress = c.String(nullable: false),
                        AgentEarnings = c.Double(nullable: false),
                        CompanyName = c.String(nullable: false, maxLength: 200),
                        IsApproved = c.Boolean(nullable: false),
                        DateApproved = c.String(nullable: false),
                        Location = c.String(nullable: false, maxLength: 250),
                        BankName = c.String(nullable: false),
                        Hotline = c.String(nullable: false),
                        BankAccountName = c.String(nullable: false),
                        BankAccountNumber = c.String(nullable: false),
                        CreatedOn = c.String(nullable: false),
                        UpdatedOn = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.AgentId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.String(nullable: false, maxLength: 128),
                        CustomerEmailAddress = c.String(nullable: false),
                        CustomerPhoneNumber = c.String(nullable: false, maxLength: 14),
                        CreatedAt = c.String(nullable: false),
                        UpdatedAt = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        StationName = c.String(nullable: false, maxLength: 128),
                        StationLocation = c.String(nullable: false),
                        Amount = c.String(nullable: false),
                        Litres = c.String(nullable: false),
                        CustomerId = c.String(nullable: false),
                        TransactionStatus = c.String(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        TransactionID = c.String(),
                    })
                .PrimaryKey(t => t.StationName);
            
            CreateTable(
                "dbo.Wallets",
                c => new
                    {
                        CustomerID = c.String(nullable: false, maxLength: 128),
                        Amount = c.String(nullable: false),
                        CreatedAt = c.String(nullable: false),
                        UpdatedAt = c.String(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Wallets");
            DropTable("dbo.Transactions");
            DropTable("dbo.Customers");
            DropTable("dbo.Agents");
        }
    }
}
