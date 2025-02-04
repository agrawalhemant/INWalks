using INWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace INWalks.API.Data
{
    public class INWalksDbContext : DbContext
    {
        public INWalksDbContext(DbContextOptions<INWalksDbContext> options) : base(options)
        {
        }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
