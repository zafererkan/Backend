using Sobis.Core.Enums;

namespace Sobis.Core.Utilities.Results.Concrete
{
    public class SuccessResult : Result
    {
        public SuccessResult(string Message) : base(true, ResultCode.Success, Message)
        {

        }

        public SuccessResult() : base(true)
        {

        }
    }
}
