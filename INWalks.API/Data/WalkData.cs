using INWalks.API.Models.Domain;

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
    }
}
