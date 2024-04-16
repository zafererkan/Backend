using FluentValidation;
using Sobis.Entities.Dto.Category;

namespace Sobis.Common.ValidationRules.FluentValidation.Category
{
    public class SubCategoryAddValidator : AbstractValidator<SubCategoryAddDto>
    {
        public SubCategoryAddValidator()
        {
            RuleFor(x => x.SubCategoryName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.CategoryId).NotEmpty().NotNull();
        }
    }
}
