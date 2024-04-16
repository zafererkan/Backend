using AutoMapper;
using Sobis.Entities.Concrete.Category;
using Sobis.Entities.Dto.Category;

namespace Sobis.Common.MappingProfile.AutoMapper.Profiles.Category
{
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<SubCategoryEntity, SubCategoryDto>().ReverseMap();                
            CreateMap<SubCategoryEntity, SubCategoryAddDto>().ReverseMap();
            CreateMap<SubCategoryEntity, SubCategoryUpdateDto>().ReverseMap();
            CreateMap<SubCategoryEntity, SubCategoryDataDto>().ReverseMap();
            CreateMap<SubCategoryDto, SubCategoryAddDto>().ReverseMap();
            CreateMap<SubCategoryDto, SubCategoryUpdateDto>().ReverseMap();
            CreateMap<SubCategoryAddDto, SubCategoryUpdateDto>().ReverseMap();
            CreateMap<SubCategoryDto, SubCategoryDataDto>().ReverseMap();
        }
    }
}
