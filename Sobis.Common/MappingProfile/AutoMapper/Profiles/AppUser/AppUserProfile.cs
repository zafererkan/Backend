using AutoMapper;
using Sobis.Entities.Dto.AppUser;

namespace Sobis.Common.MappingProfile.AutoMapper.Profiles.AppUser
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<Core.Entities.Concrete.AppUserEntity, AppUserAddDto>().ReverseMap();

            CreateMap<Core.Entities.Concrete.AppUserEntity, AppUserUpdateDto>().ReverseMap();

            CreateMap<Core.Entities.Concrete.AppUserEntity, AppUserDeleteDto>().ReverseMap();

            CreateMap<IEnumerable<Core.Entities.Concrete.AppUserEntity>, IEnumerable<AppUserDto>>().ReverseMap();

            CreateMap<Core.Entities.Concrete.AppUserEntity, AppUserDto>().ReverseMap();
        }
    }
}
