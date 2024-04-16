using Sobis.Core;
using System;

namespace Sobis.Entities.Dto.AppUser
{
    public class AppUserDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public int? Type { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Phone { get; set; }
        public int? Cr_User { get; set; }
        public DateTime? Cr_Date { get; set; }
        public int? DefaultCompanyId { get; set; }
    }
}
