using INWalks.API.Models.Domain;

namespace INWalks.API.Data
{
    public interface IWalkData
    {
        Task<List<Walk>> GetAllWalksAsync();
        Task<Walk> CreateWalkAsync(Walk walk);
    }
}
