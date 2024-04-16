using Sobis.Core.Entities.Abstract;
using System;

namespace Sobis.Core.Entities.Concrete
{
    public abstract class EntityBase : IEntity
    {
        public int? Id { get; set; }
        public virtual int? CrUser { get; set; }
        public virtual DateTime? CrDate { get; set; } = DateTime.Now;
        public virtual int? ModUser { get; set; }
        public virtual DateTime? ModDate { get; set; } = DateTime.Now;
        public string Status { get; set; }
    }
}
