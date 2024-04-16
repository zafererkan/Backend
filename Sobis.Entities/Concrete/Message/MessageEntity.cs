using Sobis.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.Entities.Concrete.Message
{
    public class MessageEntity : EntityBase
    {
        public string Message { get; set; }
        public byte[] data { get; set; }
    }
}
