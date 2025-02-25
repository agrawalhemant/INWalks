﻿using INWalks.API.Models.Domain;
using INWalks.API.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace INWalks.API.Data
{
    public interface IRegionData
    {
        Task<List<Region>> GetAllRegionsAsync(RegionEnum? filterBy = null, string? filterQuery = null, RegionEnum? sortBy = null, int page = 1, int size = 5);
        Task<Region?> GetRegionByIdAsync(Guid id);
        Task<Region> CreateRegionAsync(Region region);
        Task<Region?> UpdateRegionAsync(Guid id, Region region);
        Task<Region?> DeleteRegionAsync(Guid id);
    }
}
