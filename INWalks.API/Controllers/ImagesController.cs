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
    public class ImagesController : ControllerBase
    {
        private readonly IImageData _imageData;
        private readonly IMapper _mapper;
        public ImagesController(IImageData imageData, IMapper mapper)
        {
            _imageData = imageData;
            _mapper = mapper;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImageAsync([FromForm] ImageUploadRequestDto imageUploadRequestDto )
        {
            ValidateFileUpload(imageUploadRequestDto);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Image image = _mapper.Map<Image>(imageUploadRequestDto);
            image = await _imageData.UploadImageAsync(image);
            return Ok(image);
        }

        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            var supportedExtesnsions = new List<string> { ".png", ".jpg", ".jpeg"};

            if (!supportedExtesnsions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("file", "file format not supported");
            }

            if(request.File.Length > 10485670)
            {
                ModelState.AddModelError("file", "file size more than 10 MB");
            }
        }
    }
}
