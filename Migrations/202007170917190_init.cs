namespace computer_reparatieshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VirtualModels", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.VirtualModels", "reparatieopdrachten_Id", "dbo.Reparatieopdrachtens");
            DropIndex("dbo.VirtualModels", new[] { "Customer_Id" });
            DropIndex("dbo.VirtualModels", new[] { "reparatieopdrachten_Id" });
            CreateTable(
                "dbo.Repairers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailAddress = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Reparatieopdrachtens", "CustomerName", c => c.String());
            AddColumn("dbo.Reparatieopdrachtens", "RepairerName", c => c.String());
            DropTable("dbo.VirtualModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VirtualModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Customer_Id = c.Int(),
                        reparatieopdrachten_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Reparatieopdrachtens", "RepairerName");
            DropColumn("dbo.Reparatieopdrachtens", "CustomerName");
            DropTable("dbo.Repairers");
            CreateIndex("dbo.VirtualModels", "reparatieopdrachten_Id");
            CreateIndex("dbo.VirtualModels", "Customer_Id");
            AddForeignKey("dbo.VirtualModels", "reparatieopdrachten_Id", "dbo.Reparatieopdrachtens", "Id");
            AddForeignKey("dbo.VirtualModels", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
