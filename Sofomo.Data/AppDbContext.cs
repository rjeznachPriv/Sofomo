using Sofomo.Domain.Entities;
using System.Data.Entity;

namespace Sofomo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public DbSet<Location> Locations { get; set; }
    }
}
