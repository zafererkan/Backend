using Sobis.Core.Enums;
using Sobis.Core.Utilities.Results.Abstract;
using System;

namespace Sobis.Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult()
        {
                
        }
        public DataResult(bool isSucces, ResultCode resultCode, string message, T data) : base(isSucces, resultCode, message)
        {
            Data = data;
        }
        public DataResult(bool isSucces, ResultCode ResultCode, string Message) : base(isSucces, ResultCode, Message)
        {

        }
        public DataResult(bool isSucces, ResultCode ResultCode, T data) : base(isSucces, ResultCode)
        {
            Data = data;
        }
        public DataResult(bool isSucces, T data) : base(isSucces)
        {
            Data = data;
        }
        public DataResult(bool isSucces, string message) : base(isSucces, message)
        {
        }
        public DataResult(bool isSucces) : base(isSucces)
        {
        }

        public T Data { get; set; }
    }
}
