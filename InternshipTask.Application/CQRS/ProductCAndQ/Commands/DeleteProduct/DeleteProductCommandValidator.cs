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
                .MustAsync(DoesProductExists).WithMessage("Product with this {PropertyName} not found!");
            RuleFor(command => command.ManufacturerEmail)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .EmailAddress().WithMessage("You must enter a valid {PropertyName}")
                .MustAsync(DoesProductExists).WithMessage("Product with this {PropertyName} not found!");
            RuleFor(command => command.RemoverId)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(command => command)
                .MustAsync(MatchTheCreatorId)
                .WithMessage("Only creators of a Product can delete it!");
            this._productService = productService;
        }

        private async Task<bool> MatchTheCreatorId(DeleteProductCommand DeleteCommand, CancellationToken token)
        {
            return await _productService.DoesIdOwnProduct(DeleteCommand.RemoverId, DeleteCommand.ManufacturerEmail!);
        }

        private async Task<bool> DoesProductExists(string manufactureEmail, CancellationToken cancellationToken)
        {
            return await _productService.DoesManufacturerEmailExist(manufactureEmail);
        }
    }
}
