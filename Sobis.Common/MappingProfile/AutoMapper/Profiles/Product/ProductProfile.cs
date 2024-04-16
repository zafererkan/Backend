using AutoMapper;
using Sobis.Entities.Concrete.Product;
using Sobis.Entities.Dto.Product;

namespace Sobis.Common.MappingProfile.AutoMapper.Profiles.Product
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductDto>()
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.SubCategoryName)).ReverseMap();
            //.ReverseMap(); //Formember
            CreateMap<ProductEntity, ProductAddDto>().ReverseMap();
            CreateMap<ProductEntity, ProductUpdateDto>().ReverseMap();
            CreateMap<ProductEntity, ProductDataDto>().ReverseMap();
            CreateMap<ProductDto, ProductAddDto>().ReverseMap();
            CreateMap<ProductDto, ProductUpdateDto>().ReverseMap();
            CreateMap<ProductAddDto, ProductUpdateDto>().ReverseMap();
            CreateMap<ProductDto, ProductDataDto>().ReverseMap();
        }

    }
}
