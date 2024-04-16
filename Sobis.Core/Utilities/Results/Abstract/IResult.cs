using Sobis.Core.Entities.Abstract;
using Sobis.Core.Enums;
using System;

namespace Sobis.Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        bool IsSuccess { get; set; }
        ResultCode ResultCode { get; set; }
        string ResultMessage { get; set; }
        //Exception Exception { get; }
        //object RetVal { get; }
    }
}
