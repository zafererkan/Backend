using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Entities.Concrete.ViewModel;
using Sobis.Entities.Dto.AppUser;

namespace DxWebUI.ApiConsumer.Abstract
{
    public interface IAuthConsumerService
    {
        Task<IDataResult<UserAccessToken>> LoginAsync(AppUserLoginDto userForLoginDto);
    }
}
