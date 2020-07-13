namespace computer_reparatieshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerName : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reparatieopdrachtens", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Reparatieopdrachtens", new[] { "Customer_Id" });
            AddColumn("dbo.Reparatieopdrachtens", "CustomerName", c => c.String());
            DropColumn("dbo.Reparatieopdrachtens", "Customer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reparatieopdrachtens", "Customer_Id", c => c.Int());
            DropColumn("dbo.Reparatieopdrachtens", "CustomerName");
            CreateIndex("dbo.Reparatieopdrachtens", "Customer_Id");
            AddForeignKey("dbo.Reparatieopdrachtens", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
