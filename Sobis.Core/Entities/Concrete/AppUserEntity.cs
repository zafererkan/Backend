using Sobis.Core.Entities.Abstract;

namespace Sobis.Core.Entities.Concrete
{
    public class AppUserEntity : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public int? Type { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
        public string Phone { get; set; }
        public int? DefaultCompanyId { get; set; }
        //public virtual ICollection<AdressEntity> Adresses { get; set; }
        //public virtual ICollection<CreditCardEntity> CreditCards { get; set; }
    }
}
