using DxWebUI.ApiConsumer.Abstract;
using DxWebUI.Extensions;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Entities.Concrete.ViewModel;
using Sobis.Entities.Dto.AppUser;

namespace DxWebUI.ApiConsumer.Concrete
{
    public class AuthConsumerManager : IAuthConsumerService
    {
        private readonly HttpClient _httpClient;
        private readonly string Url;
        public AuthConsumerManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
            Url = "Auth";
        }

        public async Task<IDataResult<UserAccessToken>> LoginAsync(AppUserLoginDto userForLoginDto)
        {
            return await _httpClient.PostGetServiceResponseDataResultAsync<UserAccessToken, AppUserLoginDto>($"api/{Url}/LoginAsync", userForLoginDto);
        }
    }
}
