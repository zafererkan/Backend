using AutoMapper;
using Sobis.Entities.Concrete;
using Sobis.Entities.Dto.Category;

namespace Sobis.Common.MappingProfile.AutoMapper.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryEntity, CategoryDto>().ReverseMap();
            CreateMap<CategoryEntity, CategoryAddDto>().ReverseMap();
            CreateMap<CategoryEntity, CategoryUpdateDto>().ReverseMap();
            CreateMap<CategoryEntity, CategoryDataDto>().ReverseMap();
            CreateMap<CategoryDto, CategoryAddDto>().ReverseMap();
            CreateMap<CategoryDto, CategoryUpdateDto>().ReverseMap();
            CreateMap<CategoryAddDto, CategoryUpdateDto>().ReverseMap();
            CreateMap<CategoryDto, CategoryDataDto>().ReverseMap();
        }
    }
}
