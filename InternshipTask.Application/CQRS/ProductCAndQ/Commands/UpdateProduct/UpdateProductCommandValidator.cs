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
            RuleFor(command => command.ManufacturerEmail)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("You must enter a valid {PropertyName}")
                .MustAsync(DoesProductExists).WithMessage("Product with this {PropertyName} not found");
            RuleFor(command => command.ProductDate)
                .NotEmpty().WithMessage("{PropertyName} is required");
                

            _productService = productService;
        }

        private async Task<bool> DoesProductExists(string manufactureEmail, CancellationToken cancellationToken)
        {
            return await _productService.DoesManufacturerEmailExist(manufactureEmail);            
        }
    }
}
