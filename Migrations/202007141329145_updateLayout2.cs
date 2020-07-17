namespace computer_reparatieshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateLayout2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VirtualModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Customer_Id = c.Int(),
                        reparatieopdrachten_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Reparatieopdrachtens", t => t.reparatieopdrachten_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.reparatieopdrachten_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VirtualModels", "reparatieopdrachten_Id", "dbo.Reparatieopdrachtens");
            DropForeignKey("dbo.VirtualModels", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.VirtualModels", new[] { "reparatieopdrachten_Id" });
            DropIndex("dbo.VirtualModels", new[] { "Customer_Id" });
            DropTable("dbo.VirtualModels");
        }
    }
}
