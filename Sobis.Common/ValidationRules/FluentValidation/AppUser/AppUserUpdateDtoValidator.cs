using FluentValidation;
using Sobis.Entities.Dto.AppUser;

namespace Sobis.Entities.ValidationRules.FluentValidation.AppUser
{
    public class AppUserUpdateDtoValidator : AbstractValidator<AppUserUpdateDto>
    {
        public AppUserUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).MaximumLength(60);

            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MaximumLength(50);

            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Surname).MaximumLength(60);

            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).MaximumLength(120);

            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Phone).MaximumLength(15);

            RuleFor(x => x.Mod_User).NotEmpty();

            RuleFor(x => x.Mod_Date).NotEmpty();
        }
    }
}
