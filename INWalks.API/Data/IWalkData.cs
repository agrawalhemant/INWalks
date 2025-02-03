using INWalks.API.Models.Domain;

namespace INWalks.API.Data
{
    public interface IWalkData
    {
        Task<Walk> CreateWalkAsync(Walk walk);
    }
}
