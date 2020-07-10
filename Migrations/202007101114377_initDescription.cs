namespace computer_reparatieshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reparatieopdrachtens", "Description", c => c.String());
            DropColumn("dbo.Reparatieopdrachtens", "notes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reparatieopdrachtens", "notes", c => c.String());
            DropColumn("dbo.Reparatieopdrachtens", "Description");
        }
    }
}
