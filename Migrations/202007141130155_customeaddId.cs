namespace computer_reparatieshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customeaddId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reparatieopdrachtens", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Reparatieopdrachtens", new[] { "Customer_Id" });
            AddColumn("dbo.Reparatieopdrachtens", "custemerId", c => c.Int(nullable: false));
            DropColumn("dbo.Reparatieopdrachtens", "Customer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reparatieopdrachtens", "Customer_Id", c => c.Int());
            DropColumn("dbo.Reparatieopdrachtens", "custemerId");
            CreateIndex("dbo.Reparatieopdrachtens", "Customer_Id");
            AddForeignKey("dbo.Reparatieopdrachtens", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
