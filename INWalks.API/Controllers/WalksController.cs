using AutoMapper;
using INWalks.API.Data;
using INWalks.API.Models.Domain;
using INWalks.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<IActionResult> CreateWalkAsync([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            if(addWalkRequestDto is null)
            {
                return BadRequest("walk request is not correct");
            }

            Walk walk = _mapper.Map<Walk>(addWalkRequestDto);
            walk = await _walkData.CreateWalkAsync(walk);

            WalkDto walkDto = _mapper.Map<WalkDto>(walk);
            return Ok(walkDto);
        }
    }
}
