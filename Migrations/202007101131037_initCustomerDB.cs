namespace computer_reparatieshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initCustomerDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerDatabases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        TotalOrderCount = c.Int(nullable: false),
                        OpenOrderCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CustomerDatabases");
        }
    }
}
