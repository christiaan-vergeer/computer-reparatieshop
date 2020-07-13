namespace computer_reparatieshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "EmailAddress", c => c.String());
            DropColumn("dbo.Customers", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "EmailAddress");
        }
    }
}
