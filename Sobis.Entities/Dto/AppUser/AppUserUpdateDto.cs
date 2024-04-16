using Sobis.Core;
using System;

namespace Sobis.Entities.Dto.AppUser
{
    public class AppUserUpdateDto : IDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public int? Type { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Mod_User { get; set; }
        public DateTime? Mod_Date { get; set; }
    }
}
