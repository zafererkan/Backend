using Sobis.Common.Dto;
using Sobis.Core.Utilities.Results.Abstract;
using System.Threading.Tasks;

namespace Sobis.BLL.Abstract
{
    public interface IServiceSample
    {
        Task<IResult> DeleteAsync(DeleteDto deleteDto);
    }
}
