namespace computer_reparatieshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "LastName", c => c.String());
            DropColumn("dbo.Customers", "SecondName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "SecondName", c => c.String());
            DropColumn("dbo.Customers", "LastName");
        }
    }
}
