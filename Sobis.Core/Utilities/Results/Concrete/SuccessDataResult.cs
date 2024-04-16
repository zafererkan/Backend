using Sobis.Core.Enums;

namespace Sobis.Core.Utilities.Results.Concrete
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(string message, T data) : base(true, ResultCode.Success, message, data)
        {

        }
        public SuccessDataResult(T data) : base(true, ResultCode.Success, data)
        {

        }
    }
}
