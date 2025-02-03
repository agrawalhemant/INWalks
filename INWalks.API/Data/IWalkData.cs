using INWalks.API.Models.Domain;
using INWalks.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace INWalks.API.Data
{
    public interface IWalkData
    {
        Task<List<Walk>> GetAllWalksAsync(WalkFilters? filterBy = null, string? filterQuery = null);
        Task<Walk?> GetWalkByIdAsync(Guid id);
        Task<Walk> CreateWalkAsync(Walk walk);
        Task<Walk?> UpdateWalkByIdAsync(Guid id, Walk walk);
        Task<Walk?> DeleteWalkByIdAsync(Guid id);
    }
}
