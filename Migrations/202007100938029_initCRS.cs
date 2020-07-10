namespace computer_reparatieshop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initCRS : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reparatieopdrachtens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        startdate = c.DateTime(nullable: false),
                        enddate = c.DateTime(nullable: false),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reparatieopdrachtens");
        }
    }
}
