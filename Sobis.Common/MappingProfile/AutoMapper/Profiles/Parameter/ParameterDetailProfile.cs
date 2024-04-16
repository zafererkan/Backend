using AutoMapper;
using Sobis.Entities.Concrete.Parameter;
using Sobis.Entities.Dto.Parameter;

namespace Sobis.Common.MappingProfile.AutoMapper.Profiles.Parameter
{
    public class ParameterDetailProfile : Profile
    {
        public ParameterDetailProfile()
        {
            CreateMap<ParameterDetailEntity, ParameterDetailDto>().ReverseMap();
        }
    }
}
