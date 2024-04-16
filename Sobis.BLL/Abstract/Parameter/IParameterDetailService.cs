using Sobis.Common.Dto;
using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Entities.Dto.Parameter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sobis.BLL.Abstract.Parameter
{
    public interface IParameterDetailService : IServiceSample
    {
        Task<IDataResult<ParameterDetailDto>> GetAsync(GetDto entity);
        Task<IDataResult<IEnumerable<ParameterDetailDto>>> GetAllAsync(ParameterDetailDto entity);
        Task<IDataResult<IEnumerable<ParameterDetailDto>>> GetListByParameterIdAsync(ParameterDetailDto entity);
        Task<IResult> AddAsync(ParameterDetailAddDto entity);
        Task<IResult> UpdateAsync(ParameterDetailAddDto entity);
    }
}
