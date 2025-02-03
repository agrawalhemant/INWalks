using AutoMapper;
using Azure.Core;
using INWalks.API.Data;
using INWalks.API.Models.Domain;
using INWalks.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace INWalks.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWalkData _walkData;
        public WalksController(IMapper mapper, IWalkData walkData)
        {
            _mapper = mapper;
            _walkData = walkData;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalksAsync([FromQuery] WalkFilters? filterBy, [FromQuery] string? filterQuery)
        {
            List<Walk> walks = await _walkData.GetAllWalksAsync(filterBy, filterQuery);
            List <WalkDto> walksDto = _mapper.Map<List<WalkDto>>(walks);
            return Ok(walksDto);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetWalkByIdAsync([FromRoute] Guid id)
        {
            Walk? walk = await _walkData.GetWalkByIdAsync(id);
            if(walk is null)
            {
                return NotFound();
            }
            WalkDto walkDto = _mapper.Map<WalkDto>(walk);
            return Ok(walkDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWalkAsync([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Walk walk = _mapper.Map<Walk>(addWalkRequestDto);
            walk = await _walkData.CreateWalkAsync(walk);

            WalkDto walkDto = _mapper.Map<WalkDto>(walk);
            return Ok(walkDto);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateWalkByIdAsync([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Walk? walk = _mapper.Map<Walk>(updateWalkRequestDto);

            walk = await _walkData.UpdateWalkByIdAsync(id, walk);
            if(walk is null)
            {
                return NotFound();
            }

            WalkDto walkDto = _mapper.Map<WalkDto>(walk);
            return Ok(walkDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteWalkByIDAsync(Guid id)
        {
            Walk? walk = await _walkData.DeleteWalkByIdAsync(id);

            if(walk is null)
            {
                return NotFound();
            }

            WalkDto walkDto = _mapper.Map<WalkDto>(walk);
            return Ok(walkDto);
        }
    }
}
