namespace computer_reparatieshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reparatieopdrachtens", "customerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reparatieopdrachtens", "customerID", c => c.Int(nullable: false));
        }
    }
}
