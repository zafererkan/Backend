using Sobis.Core.Enums;
using Sobis.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.Core.Utilities.Results.Concrete
{
    public class ServiceResponse<T>
    {
        T Data { get; set; }
        public bool IsSuccess { get; set; }
        public ResultCode ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }
}
