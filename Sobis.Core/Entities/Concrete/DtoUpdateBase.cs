using System;

namespace Sobis.Core.Entities.Concrete
{
    public class DtoUpdateBase : IDto
    {
        public int? Id { get; set; }
        public virtual int? ModUser { get; set; }
        public virtual DateTime? ModDate { get; set; } = DateTime.Now;
        public string Status { get; set; }
    }
}
