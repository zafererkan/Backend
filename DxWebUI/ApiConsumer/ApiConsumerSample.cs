using DxWebUI.Extensions;
using Sobis.Common.Dto;
using Sobis.Core.Utilities.Results.Abstract;

namespace Sobis.BlazorWebUI.Client.ApiConsumer
{
    public class ApiConsumerSample
    {
        private readonly HttpClient _httpClient;
        private readonly string Url;
        public ApiConsumerSample(HttpClient httpClient)
        {
            _httpClient = httpClient;
            Url = "TEntity";
        }

        //public async Task<IResult> Add(TEntityAddDto entity)
        //{
        //    return await _httpClient.PostGetServiceResponseResultAsync($"api/{Url}/Add", entity);
        //}

        //public async Task<IResult> Delete(DeleteDto entity)
        //{
        //    return await _httpClient.PostGetServiceResponseResultAsync($"api/{Url}/Delete", entity);
        //}

        //public async Task<IDataResult<TEntityDto>> Get(GetDto entity)
        //{
        //    return await _httpClient.PostGetServiceResponseDataResultAsync<TEntityDto, GetDto>($"api/{Url}/Get", entity);
        //}

        //public async Task<IDataResult<IEnumerable<TEntityDataDto>>> GetListByIdAsync(GetDto entity)
        //{
        //    return await _httpClient.PostGetServiceResponseDataResultAsync<IEnumerable<TEntityDataDto>, GetDto>($"api/{Url}/GetListByIdAsync", entity);
        //}

        //public async Task<IDataResult<IEnumerable<TEntityDto>>> GetList(TEntityDto entity)
        //{
        //    return await _httpClient.PostGetServiceResponseDataResultAsync<IEnumerable<TEntityDto>,
        //        TEntityDto>($"api/{Url}/GetList", entity);
        //}

        //public async Task<IResult> Update(TEntityUpdateDto entity)
        //{
        //    return await _httpClient.PostGetServiceResponseResultAsync($"api/{Url}/Update", entity);
        //}
    }
}
