using Sobis.Core.Enums;

namespace Sobis.Core.Utilities.Results.Concrete
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, ResultCode.AppError, message)
        {

        }

        public ErrorResult() : base(false)
        {

        }
    }
}
