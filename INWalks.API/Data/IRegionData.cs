using INWalks.API.Models.Domain;
using INWalks.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace INWalks.API.Data
{
    public interface IRegionData
    {
        Task<List<Region>> GetAllRegionsAsync(RegionFilters? filterBy = null, string? filterQuery = null);
        Task<Region?> GetRegionByIdAsync(Guid id);
        Task<Region> CreateRegionAsync(Region region);
        Task<Region?> UpdateRegionAsync(Guid id, Region region);
        Task<Region?> DeleteRegionAsync(Guid id);
    }
}
