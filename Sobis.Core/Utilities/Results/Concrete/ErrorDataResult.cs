using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sobis.Core.Enums;

namespace Sobis.Core.Utilities.Results.Concrete
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(string message, T data) : base(false, ResultCode.AppError, message, data)
        {

        }
        public ErrorDataResult(T data) : base(false, data)
        {

        }
        //public ErrorDataResult(string message) : base(false, message)
        //{

        //}
        public ErrorDataResult(string message) : base(false, ResultCode.AppError, message)
        {

        }

        public ErrorDataResult() : base(false)
        {

        }
    }
}
