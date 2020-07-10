namespace computer_reparatieshop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using computer_reparatieshop.Models;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.ComputerReparatieshopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.ComputerReparatieshopContext context)
        {
            context.Reparaties.AddOrUpdate(x => x.Id,
                new Reparatie() { Id = 1, Name = "Jane Austen" },
                new Reparatie() { Id = 2, Name = "Charles Dickens" },
                new Reparatie() { Id = 3, Name = "Miguel de Cervantes" }
                );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
