using Sobis.Core.Entities.Concrete;
using System;

namespace Sobis.Entities.Dto.Parameter
{
    public class ParameterDetailAddDto : DtoAddBase
    {

        public int ParamId { get; set; }
        public string ParamDetailName { get; set; }
        public int? ParentDataId { get; set; } = 0;
        public int? Data { get; set; }
        public string DataValue { get; set; }
        public int? OrderNo { get; set; }
    }
}
