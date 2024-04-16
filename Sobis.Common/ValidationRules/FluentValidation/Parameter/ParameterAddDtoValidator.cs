using FluentValidation;
using Sobis.Entities.Dto.Parameter;

namespace Sobis.Common.ValidationRules.FluentValidation.Parameter
{
    public class ParameterAddDtoValidator : AbstractValidator<ParameterDto>
    {
        public ParameterAddDtoValidator()
        {
            RuleFor(x => x.ParamName).NotEmpty().NotNull();
            RuleFor(x => x.ParamName).MaximumLength(60);
        }
    }
}
