namespace computer_reparatieshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reparatieopdrachtens", "RepairerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reparatieopdrachtens", "RepairerName");
        }
    }
}
