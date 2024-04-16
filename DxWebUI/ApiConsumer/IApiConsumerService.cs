using Sobis.Common.Dto;
using Sobis.Core.Utilities.Results.Abstract;

namespace DxWebUI.ApiConsumer
{
    public interface IApiConsumerService<TResult, TPostValue, TAddPostValue, TUpdatePostValue, TEntityDataPostValue>
    {
        Task<IDataResult<IEnumerable<TResult>>> GetList(TPostValue entity);
        Task<IDataResult<IEnumerable<TEntityDataPostValue>>> GetListByIdAsync(GetDto entity);
        Task<IDataResult<TResult>> Get(GetDto entity);
        Task<IResult> Add(TAddPostValue entity);
        Task<IResult> Update(TUpdatePostValue entity);
        Task<IResult> Delete(DeleteDto entity);
    }
}
