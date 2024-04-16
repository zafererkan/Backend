using FluentValidation;
using FluentValidation.Validators;
using Sobis.Entities.Dto.AppUser;

namespace Sobis.Entities.ValidationRules.FluentValidation.AppUser
{
    public class AppUserLoginDtoValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.UserName).EmailAddress(mode: EmailValidationMode.AspNetCoreCompatible);
            RuleFor(x => x.UserName).MinimumLength(5);

            RuleFor(x => x.Password).NotEmpty();
            //RuleFor(x => x.Password).MinimumLength(5);
        }
    }
}
