﻿using AutoMapper;
using INWalks.API.Data;
using INWalks.API.Models.Domain;
using INWalks.API.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace INWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionData _regionData;
        private readonly IMapper _mapper;
        public RegionsController(IRegionData regionData, IMapper mapper)
        {
            _regionData = regionData;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RegionDto>))]
        [Authorize(Roles ="Reader, Writer")]
        public async Task<IActionResult> GetAllRegionsAsync([FromQuery] RegionEnum? filterBy, [FromQuery] string? filterQuery, [FromQuery] RegionEnum? sortBy, int page = 1, int size = 5)
        {
            var regions = await _regionData.GetAllRegionsAsync(filterBy, filterQuery, sortBy, page, size);
            List<RegionDto> regionsDtos = _mapper.Map<List<RegionDto>>(regions);
            return Ok(regionsDtos);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegionDto))]
        [Authorize(Roles = "Reader, Writer")]
        public async Task<IActionResult> GetRegionByIdAsync([FromRoute] Guid id) {
            var region = await _regionData.GetRegionByIdAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            RegionDto regionDto = _mapper.Map<RegionDto>(region);
            return Ok(regionDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RegionDto))]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateRegionAsync([FromBody] AddRegionRequestDto regionRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Region region = _mapper.Map<Region>(regionRequest);
            region = await _regionData.CreateRegionAsync(region);

            RegionDto regionDto = _mapper.Map<RegionDto>(region);
            return Ok(regionDto);
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegionDto))]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto regionRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Region region = _mapper.Map<Region>(regionRequest);
            region = await _regionData.UpdateRegionAsync(id, region);
            if(region is null)
            {
                return NotFound();
            }
            RegionDto regionDto = _mapper.Map<RegionDto>(region);
            return Ok(regionDto);
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteRegionAsync([FromRoute] Guid id)
        {
            var region = await _regionData.DeleteRegionAsync(id);
            if (region is null)
            {
                return NotFound();
            }
            RegionDto regionDto = _mapper.Map<RegionDto>(region);
            return Ok(regionDto);
        }
    }
}
