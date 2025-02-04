using INWalks.API.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace INWalks.API.Data
{
    public class LocalImageData : IImageData
    {
        private readonly INWalksDbContext _dbContext;
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LocalImageData(INWalksDbContext dbContext, IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _env = env;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Image> UploadImageAsync(Image image)
        {
            var filePath = Path.Combine(_env.ContentRootPath, "Images", $"{image.FileName}{image.FileExtension}");

            //upload image to local images folder
            using var stream = new FileStream(filePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            // https://locahost:7193/Images/abc.png
            var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

            image.FilePath = urlFilePath;

            await _dbContext.Images.AddAsync(image);
            await _dbContext.SaveChangesAsync();

            return image;
        }
    }
}
