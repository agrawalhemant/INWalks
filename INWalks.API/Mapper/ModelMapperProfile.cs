using AutoMapper;
using INWalks.API.Models.Domain;
using INWalks.API.Models.DTO;

namespace INWalks.API.Mapper
{
    public class ModelMapperProfile : Profile
    {
        public ModelMapperProfile()
        {
            #region Region model mapper
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Region, AddRegionRequestDto>().ReverseMap();
            CreateMap<Region, UpdateRegionRequestDto>().ReverseMap();
            #endregion

            #region Walk model mapper
            CreateMap<Walk, AddWalkRequestDto>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            #endregion
        }
    }
}
