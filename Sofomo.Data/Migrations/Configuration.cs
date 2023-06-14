namespace Sofomo.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Sofomo.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Sofomo.Data.AppDbContext context)
        {
            context.Locations.Add(new Domain.Entities.Location { 
                Id = Guid.NewGuid(),
                Latitude = 1,
                Longitude = 1,
                City = "Wroclaw",
                Country = "Poland",
                IPorURL = "127.0.0.1"
            });
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
