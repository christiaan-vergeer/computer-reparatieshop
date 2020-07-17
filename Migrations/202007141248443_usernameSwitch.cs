namespace computer_reparatieshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usernameSwitch : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reparatieopdrachtens", "CustomerName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reparatieopdrachtens", "CustomerName", c => c.String());
        }
    }
}
