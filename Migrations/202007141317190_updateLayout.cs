namespace computer_reparatieshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateLayout : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reparatieopdrachtens", "custemerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reparatieopdrachtens", "custemerId", c => c.Int(nullable: false));
        }
    }
}
