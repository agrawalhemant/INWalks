using INWalks.API.Models.Domain;

namespace INWalks.API.Data
{
    public interface IImageData
    {
        Task<Image> UploadImageAsync(Image image);
    }
}
