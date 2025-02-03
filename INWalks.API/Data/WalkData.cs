using INWalks.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace INWalks.API.Data
{
    public class WalkData : IWalkData
    {
        private readonly INWalksDbContext _dbContext;
        public WalkData(INWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Walk> CreateWalkAsync(Walk walk)
        {
            await _dbContext.Walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllWalksAsync()
        {
            return await _dbContext.Walks.Include(x => x.Difficulty).Include(x => x.Region).ToListAsync();
        }
    }
}
