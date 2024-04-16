using System;

namespace Sobis.Core.Entities.Concrete
{
    public class DtoAddBase : IDto
    {
        public int? Id { get; set; }
        public virtual int? CrUser { get; set; }
        public virtual DateTime? CrDate { get; set; } = DateTime.Now;
        public string Status { get; set; }
    }
}
