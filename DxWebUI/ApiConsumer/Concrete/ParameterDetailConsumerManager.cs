using AutoMapper;
using DxWebUI.ApiConsumer.Abstract;
using DxWebUI.Extensions;
using Sobis.Common.Dto;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Entities.Dto.Parameter;

namespace DxWebUI.ApiConsumer.Concrete
{
    public class ParameterDetailConsumerManager : IParameterDetailConsumerService
    {
        private readonly HttpClient _httpClient;
        string Url;
        public ParameterDetailConsumerManager(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            Url = "ParameterDetail";
        }

        public async Task<IResult> Add(ParameterDetailAddDto entity)
        {
            return await _httpClient.PostGetServiceResponseResultAsync($"api/{Url}/Add", entity);
        }

        public async Task<IResult> Delete(DeleteDto entity)
        {
            return await _httpClient.PostGetServiceResponseResultAsync($"api/{Url}/Delete", entity);
        }

        public async Task<IDataResult<ParameterDetailDto>> Get(GetDto entity)
        {
            return await _httpClient.PostGetServiceResponseDataResultAsync<ParameterDetailDto, GetDto>($"api/{Url}/Get", entity);
        }

        public async Task<IDataResult<IEnumerable<ParameterDetailDto>>> GetList(ParameterDetailDto entity)
        {
            return await _httpClient.PostGetServiceResponseDataResultAsync<IEnumerable<ParameterDetailDto>,
                ParameterDetailDto>($"api/{Url}/GetList", entity);
        }

        public async Task<IDataResult<IEnumerable<ParameterDetailDto>>> GetListByIdAsync(ParameterDetailDto entity)
        {
            return await _httpClient.PostGetServiceResponseDataResultAsync<IEnumerable<ParameterDetailDto>,
                ParameterDetailDto>($"api/{Url}/GetListByIdAsync", entity);
        }

        public Task<IDataResult<IEnumerable<ParameterDetailDto>>> GetListByIdAsync(GetDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Update(ParameterDetailAddDto entity)
        {
            return await _httpClient.PostGetServiceResponseResultAsync($"api/{Url}/Update", entity);
        }
    }
}
