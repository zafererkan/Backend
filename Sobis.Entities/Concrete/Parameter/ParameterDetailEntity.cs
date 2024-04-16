using Sobis.Core.Entities.Concrete;

namespace Sobis.Entities.Concrete.Parameter
{
    public class ParameterDetailEntity : EntityBase
    {
        public int ParamId { get; set; }
        public virtual ParameterEntity Param { get; set; }
        public string ParamDetailName { get; set; }
        public int? ParentDataId { get; set; } = 0;
        public int? Data { get; set; }
        public string DataValue { get; set; }
        public int? OrderNo { get; set; }

    }
}
