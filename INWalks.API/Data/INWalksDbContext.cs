using INWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace INWalks.API.Data
{
    public class INWalksDbContext : DbContext
    {
        public INWalksDbContext(DbContextOptions<INWalksDbContext> options) : base(options)
        {
        }
        public DbSet<Walks> Walks { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
    }
}
