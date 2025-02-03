using INWalks.API.Models.Domain;
using INWalks.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace INWalks.API.Data
{
    public interface IWalkData
    {
        Task<List<Walk>> GetAllWalksAsync(WalkEnum? filterBy = null, string? filterQuery = null, WalkEnum? sortBy = null, int page = 1, int size = 5);
        Task<Walk?> GetWalkByIdAsync(Guid id);
        Task<Walk> CreateWalkAsync(Walk walk);
        Task<Walk?> UpdateWalkByIdAsync(Guid id, Walk walk);
        Task<Walk?> DeleteWalkByIdAsync(Guid id);
    }
}
