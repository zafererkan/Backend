using DxWebUI.ApiConsumer.Abstract;
using DxWebUI.Extensions;
using Sobis.Common.Dto;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Entities.Dto.AppUser;

namespace DxWebUI.ApiConsumer.Concrete
{
    public class AppUserConsumerManager : IAppUserConsumerService
    {
        private readonly HttpClient _httpClient;
        private readonly string Url;
        public AppUserConsumerManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
            Url = "AppUsers";
        }
        public async Task<IResult> UpdateDefaultCompany(AppUserUpdateDefaultCompanyDto AppUserUpdateDefaultCompanyDto)
        {
            return await _httpClient.PostGetServiceResponseResultAsync($"api/{Url}/UpdateDefaultCompany", AppUserUpdateDefaultCompanyDto);
        }

        public async Task<IResult> Add(AppUserAddDto entity)
        {
            return await _httpClient.PostGetServiceResponseResultAsync($"api/{Url}/Add", entity);
        }

        public async Task<IResult> Delete(DeleteDto entity)
        {
            return await _httpClient.PostGetServiceResponseResultAsync($"api/{Url}/Delete", entity);
        }

        public async Task<IDataResult<AppUserDto>> Get(GetDto entity)
        {
            return await _httpClient.PostGetServiceResponseDataResultAsync<AppUserDto, GetDto>($"api/{Url}/Get", entity);
        }

        public async Task<IDataResult<IEnumerable<AppUserDto>>> GetList(AppUserDto entity)
        {
            return await _httpClient.PostGetServiceResponseDataResultAsync<IEnumerable<AppUserDto>,
                AppUserDto>($"api/{Url}/GetList", entity);
        }
        public async Task<IDataResult<IEnumerable<AppUserDto>>> GetListByDepartmentIdAsync(GetDto entity)
        {
            return await _httpClient.PostGetServiceResponseDataResultAsync<IEnumerable<AppUserDto>,
                GetDto>($"api/{Url}/GetListByDepartmentIdAsync", entity);
        }

        public async Task<IResult> Update(AppUserUpdateDto entity)
        {
            return await _httpClient.PostGetServiceResponseResultAsync($"api/{Url}/Update", entity);
        }

        public Task<IDataResult<IEnumerable<AppUserDto>>> GetListByIdAsync(GetDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
