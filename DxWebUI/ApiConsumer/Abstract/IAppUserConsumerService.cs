using Sobis.BlazorWebUI.Client.ApiConsumer;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Entities.Dto.AppUser;

namespace DxWebUI.ApiConsumer.Abstract
{
    public interface IAppUserConsumerService : IApiConsumerService<AppUserDto, AppUserDto, AppUserAddDto, AppUserUpdateDto, AppUserDto>
    {
        Task<IResult> UpdateDefaultCompany(AppUserUpdateDefaultCompanyDto AppUserUpdateDefaultCompanyDto);
    }
}
