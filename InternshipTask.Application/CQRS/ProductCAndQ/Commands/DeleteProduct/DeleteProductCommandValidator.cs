using FluentValidation;
using InternshipTask.Application.Contracts;

namespace InternshipTask.Application.CQRS.ProductCAndQ.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        private readonly IProductService _productService;
        public DeleteProductCommandValidator(IProductService productService)
        {
            RuleFor(command => command.ManufacturerEmail)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("You must enter a valid {PropertyName}")
                .MustAsync(IsProductThere).WithMessage("Product with this {PropertyName} not found!");
            this._productService = productService;
        }

        private async Task<bool> IsProductThere(string manufacturerEmail, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByManufacturerEmail(manufacturerEmail);

            return !(product==null);
        }
    }
}
