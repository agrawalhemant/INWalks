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
            CreateMap<Walk, UpdateWalkRequestDto>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            #endregion

            #region Difficulty model mapper
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
            #endregion

            #region Image model mapper
            CreateMap<ImageUploadRequestDto, Image>()
                .ForMember(dest => dest.FileExtension, opt => opt.MapFrom(src => Path.GetExtension(src.File.FileName)))
                .ForMember(dest => dest.FileSizeInBytes, opt => opt.MapFrom(src => src.File.Length))
                .ReverseMap();
            #endregion
        }
    }
}
