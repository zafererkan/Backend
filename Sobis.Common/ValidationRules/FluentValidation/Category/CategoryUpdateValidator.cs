using FluentValidation;
using Sobis.Entities.Dto.Category;

namespace Sobis.Common.ValidationRules.FluentValidation
{
    public class CategoryUpdateValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Name).MaximumLength(50);
            RuleFor(x => x.Description).MaximumLength(50);

        }
    }
}
