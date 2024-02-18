using FluentValidation;
using InternshipTask.Application.Contracts;
using InternshipTask.Application.Dto.Product;

namespace InternshipTask.Application.CQRS.ProductCAndQ.Commands.CreateProduct
{
    internal class CreateProductCommandValidator : AbstractValidator<CreateProductDto>
    {
        private readonly IProductService _productService;
        public CreateProductCommandValidator(IProductService productService)
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(p => p.ManufactureEmail)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("you must enter a valid {PropertyName}")
                .MustAsync(IsManufactureEmailUnique).WithMessage("Another Product with this {PropertyName} already exists!");

            RuleFor(p => p.ProductDate)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(IsProductDateUnique);

            this._productService = productService;
        }
        private Task<bool> IsProductDateUnique(DateTime ProductDate, CancellationToken token)
        {
            return _productService.IsProductDateUnique(ProductDate);
        }
        private Task<bool> IsManufactureEmailUnique(string ManufactureEmail, CancellationToken token)
        {
            return _productService.IsManufactureEmailUnique(ManufactureEmail);
        }
    }
}
