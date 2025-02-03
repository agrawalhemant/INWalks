using INWalks.API.Models.Domain;
using INWalks.API.Models.DTO;
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
            return await GetWalkByIdAsync(walk.Id);
        }

        public async Task<Walk?> GetWalkByIdAsync(Guid id)
        {
            return await _dbContext.Walks.Include(x => x.Difficulty).Include(x => x.Region).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<Walk>> GetAllWalksAsync(WalkEnum? filterBy = null, string? filterQuery = null, WalkEnum? sortBy = null, int page = 1, int size = 5)
        {
            var walks = _dbContext.Walks.Include(x => x.Difficulty).Include(x => x.Region).AsQueryable();

            if(filterBy is not null && !string.IsNullOrEmpty(filterQuery))
            {
                if(filterBy == WalkEnum.Name)
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
                else if(filterBy == WalkEnum.Description)
                {
                    walks = walks.Where(x => x.Description.Contains(filterQuery));
                }
                else if(filterBy == WalkEnum.LengthInKms)
                {
                    walks = walks.Where(x => x.LengthInKms.ToString() == filterQuery);
                }
            }

            if(sortBy is not null)
            {
                if (sortBy == WalkEnum.Name)
                {
                    walks = walks.OrderBy(x => x.Name);
                }
                else if (sortBy == WalkEnum.Description)
                {
                    walks = walks.OrderBy(x => x.Description);
                }
                else if (sortBy == WalkEnum.LengthInKms)
                {
                    walks = walks.OrderBy(x => x.LengthInKms); 
                }
            }

            return await walks.Skip((page-1) * size).Take(size).ToListAsync();
        }

        public async Task<Walk?> UpdateWalkByIdAsync(Guid id, Walk walk)
        {
            Walk? existingWalk = await GetWalkByIdAsync(id);

            if (existingWalk is null)
                return null;

            existingWalk.Name = walk.Name;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.LengthInKms = walk.LengthInKms;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.DifficultyId = walk.DifficultyId;

            await _dbContext.SaveChangesAsync();
            existingWalk = await GetWalkByIdAsync(existingWalk.Id);
            return existingWalk;
        }

        public async Task<Walk?> DeleteWalkByIdAsync(Guid id)
        {
            Walk? walk = await GetWalkByIdAsync(id);

            if (walk is null)
                return null;

            _dbContext.Walks.Remove(walk);
            await _dbContext.SaveChangesAsync();
            return walk;
        }
    }
}
