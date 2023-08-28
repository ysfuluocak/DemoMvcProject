using DemoMvcProject.Entities.Dtos.ProductDtos;
using FluentValidation;

namespace DemoMvcProject.Business.Validation.FluentValidation
{
    public class ProductValidator : AbstractValidator<CreateProductDto>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(3).MaximumLength(50);

            RuleFor(p => p.Price).NotEmpty();
            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p => p.Price).PrecisionScale(10, 2, false);
        }
    }
}
