﻿using INWalks.API.Models.Domain;
using INWalks.API.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace INWalks.API.Data
{
    public class RegionData : IRegionData
    {
        private readonly INWalksDbContext _dbContext;
        public RegionData(INWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Region> CreateRegionAsync(Region region)
        {
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<List<Region>> GetAllRegionsAsync(RegionFilters? filterBy = null, string? filterQuery = null)
        {
            var region =  _dbContext.Regions.AsQueryable();
            if(filterBy is not null && !string.IsNullOrEmpty(filterQuery))
            {
                if(filterBy == RegionFilters.Name)
                {
                    region = region.Where(x => x.Name.Contains(filterQuery));
                }
                else if(filterBy == RegionFilters.Code)
                {
                    region = region.Where(x => x.Code.Contains(filterQuery));
                }
            }
            return await region.ToListAsync();
        }

        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            return await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateRegionAsync(Guid id, Region region)
        {
            var existsingRegion = await GetRegionByIdAsync(id);
            if (existsingRegion is null)
                return null;

            existsingRegion.Code = region.Code;
            existsingRegion.Name = region.Name;
            existsingRegion.RegionImageUrl = region.RegionImageUrl;
            await _dbContext.SaveChangesAsync();

            return existsingRegion;
        }
        public async Task<Region?> DeleteRegionAsync(Guid id)
        {
            var region = await GetRegionByIdAsync(id);
            if(region is null)
            {
                return null;
            }
            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }
    }
}
