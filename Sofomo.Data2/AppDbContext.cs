using Microsoft.EntityFrameworkCore;
using Sofomo.Domain.Entities;

namespace Sofomo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Location> Locations { get; set; }

    }
}
