namespace computer_reparatieshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reparatieopdrachtens", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Reparatieopdrachtens", "Customer_Id");
            AddForeignKey("dbo.Reparatieopdrachtens", "Customer_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reparatieopdrachtens", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Reparatieopdrachtens", new[] { "Customer_Id" });
            DropColumn("dbo.Reparatieopdrachtens", "Customer_Id");
        }
    }
}
