using FluentValidation;
using InternshipTask.Application.Contracts;
using InternshipTask.Application.Dto.Product;

namespace InternshipTask.Application.CQRS.ProductCAndQ.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductDto>
    {
        private readonly IProductService _productService;

        public UpdateProductCommandValidator(IProductService productService)
        {


            RuleFor(command => command.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

            RuleFor(command => command.ManufactureEmail)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("You must enter a valid {PropertyName}")
                .MustAsync(DoesProductExists).WithMessage("Product with this {PropertyName} not found");

            RuleFor(command => command.ProductDate)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .MustAsync(BeAUniqueDate).WithMessage("{PropertyName} must be a valid date");

            _productService = productService;
        }

        private async Task<bool> DoesProductExists(string manufactureEmail, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByManufacturerEmail(manufactureEmail);
            return product != null;
        }
        private async Task<bool> BeAUniqueDate(DateTime ProductDate, CancellationToken token)
        {
            var Product = await _productService.GetProductByDate(ProductDate);
            return Product == null;
        }

    }
}
