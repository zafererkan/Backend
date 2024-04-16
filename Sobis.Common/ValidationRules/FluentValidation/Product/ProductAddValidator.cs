using FluentValidation;
using Sobis.Entities.Dto.Product;

namespace Sobis.Common.ValidationRules.FluentValidation.Product
{
    public class ProductAddValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddValidator()
        {
            RuleFor(x => x.CategoryId).NotNull();
            RuleFor(x => x.ProductName).NotNull().MaximumLength(200);
            RuleFor(x => x.Description).MaximumLength(500);
        }
    }
}
