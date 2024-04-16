using Sobis.BlazorWebUI.Client.ApiConsumer;
using Sobis.Common.Dto;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Entities.Dto.Parameter;

namespace DxWebUI.ApiConsumer.Abstract
{
    public interface IParameterDetailConsumerService : IApiConsumerService<ParameterDetailDto, ParameterDetailDto, ParameterDetailAddDto, ParameterDetailAddDto, ParameterDetailDto>
    {
        Task<IDataResult<IEnumerable<ParameterDetailDto>>> GetListByIdAsync(ParameterDetailDto entity);
    }
}
