using FluentValidation;
using Sobis.Entities.Dto.Category;

namespace Sobis.Common.ValidationRules.FluentValidation.Category
{
    public class SubCategoryUpdateValidator : AbstractValidator<SubCategoryUpdateDto>
    {
        public SubCategoryUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.SubCategoryName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(x => x.CategoryId).NotEmpty().NotNull();
        }
    }
}
