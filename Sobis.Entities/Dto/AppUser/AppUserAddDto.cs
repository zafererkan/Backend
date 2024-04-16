using Sobis.Core;
using System;

namespace Sobis.Entities.Dto.AppUser
{
    public class AppUserAddDto : IDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public int? Type => 1;
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Cr_User { get; set; }
        public string Status { get; set; }
        public DateTime? Cr_Date { get; set; }
    }
}
