using Sobis.Common.Dto;
using Sobis.Core.Utilities.Results.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sobis.BLL.Abstract
{
    public interface IServiceBase<TEntity, TAddEntity, TUpdateEntity, TDataEntity>
    {
        Task<IResult> DeleteAsync(DeleteDto deleteDto);
        Task<IDataResult<IEnumerable<TEntity>>> GetAllAsync(TEntity entity);
        Task<IDataResult<IEnumerable<TDataEntity>>> GetListByIdAsync(GetDto entity);
        Task<IDataResult<TEntity>> GetAsync(GetDto entity);
        Task<IResult> AddAsync(TAddEntity entity);        
        Task<IResult> UpdateAsync(TUpdateEntity entity);
        Task<IResult> AddBulkAsync(IEnumerable<TAddEntity> entity);
        Task<IResult> UpdateBulkAsync(IEnumerable<TUpdateEntity> entity);
    }
}
