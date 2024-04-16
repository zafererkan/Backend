using FluentValidation;
using Sobis.Entities.Dto.Parameter;

namespace Sobis.Common.ValidationRules.FluentValidation.Parameter
{
    public class ParameterDetailAddDtoValidator : AbstractValidator<ParameterDetailDto>
    {
        public ParameterDetailAddDtoValidator()
        {
            RuleFor(x => x.ParamDetailName).NotEmpty().NotNull();
            RuleFor(x => x.ParamDetailName).MaximumLength(60);
        }
    }
}
