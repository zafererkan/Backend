using Sobis.Core;
using Sobis.Entities.Concrete.Parameter;
using System.Collections.Generic;

namespace Sobis.Entities.Dto.Parameter
{
    public class ParameterDetailDto : IDto
    {
        public int? Id { get; set; }
        public int ParamId { get; set; }
        public virtual ParameterEntity Param { get; set; }
        public string ParamDetailName { get; set; }
        public int? ParentDataId { get; set; } = 0;
        public int? Data { get; set; }
        public string DataValue { get; set; }
        public int? OrderNo { get; set; }
        public string Status { get; set; }
        public virtual List<int?> ParamIds { get; set; }
    }
}
