namespace computer_reparatieshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reparatie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        TotalOrderCount = c.Int(nullable: false),
                        OpenOrderCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Reparatieopdrachtens", "Description", c => c.String());
            AddColumn("dbo.Reparatieopdrachtens", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Reparatieopdrachtens", "Customer_Id");
            AddForeignKey("dbo.Reparatieopdrachtens", "Customer_Id", "dbo.Customers", "Id");
            //DropColumn("dbo.Reparatieopdrachtens", "notes");
        }
        
        public override void Down()
        {
           // AddColumn("dbo.Reparatieopdrachtens", "notes", c => c.String());
            DropForeignKey("dbo.Reparatieopdrachtens", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Reparatieopdrachtens", new[] { "Customer_Id" });
            DropColumn("dbo.Reparatieopdrachtens", "Customer_Id");
            DropColumn("dbo.Reparatieopdrachtens", "Description");
            DropTable("dbo.Customers");
        }
    }
}
