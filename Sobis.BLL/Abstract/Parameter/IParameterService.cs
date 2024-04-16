using Sobis.Core.Utilities.Results.Abstract;
using Sobis.Entities.Dto.Parameter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sobis.BLL.Abstract.Parameter
{
    public interface IParameterService : IServiceSample
    {
        Task<IDataResult<ParameterDto>> GetAsync(int? ID);
        Task<IDataResult<IEnumerable<ParameterDto>>> GetAllAsync(ParameterDto entity);
        
        Task<IResult> AddAsync(ParameterDto entity);
        Task<IResult> UpdateAsync(ParameterDto entity);
    }
}
