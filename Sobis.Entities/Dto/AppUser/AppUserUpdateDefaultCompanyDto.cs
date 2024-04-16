using Sobis.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobis.Entities.Dto.AppUser
{
    public class AppUserUpdateDefaultCompanyDto : IDto
    {
        public int? Id { get; set; }
        public int? CompanyId { get; set; }
    }
}
