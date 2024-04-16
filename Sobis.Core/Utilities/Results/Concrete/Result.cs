using Sobis.Core.Enums;
using Sobis.Core.Utilities.Results.Abstract;
using System;

namespace Sobis.Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result()
        {
        }
        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public Result(bool isSuccess, ResultCode resultCode) : this(isSuccess)
        {
            ResultCode = resultCode;
        }
        public Result(bool isSuccess, string resultMessage) : this(isSuccess)
        {
            ResultMessage = resultMessage;
        }
        public Result(bool isSuccess, ResultCode resultCode, string resultMessage) : this(isSuccess, resultCode)
        {
            ResultMessage = resultMessage;
        }
        public bool IsSuccess { get; set; }
        public ResultCode ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }

}
