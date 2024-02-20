using MediatR;
using InternshipTask.Application.Exceptions;
using InternshipTask.Application.Contracts;
namespace InternshipTask.Application.CQRS.ProductCAndQ.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductService _productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {

            var validator = new DeleteProductCommandValidator(_productService);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException("Invalid Product", validationResult);
            }
           
            var productToDelete = await _productService.GetProductByManufacturerEmail(request.ManufacturerEmail);

            if (productToDelete.ManufacturerEmail == null)
            {
                throw new InvalidOperationException("ManufactureEmail is null for the product to be deleted.");
            }

            if (productToDelete == null)
            {               
                throw new InvalidOperationException($"Product with manufacturer email '{request.ManufacturerEmail}' not found");
            }

            await _productService.DeleteProduct(productToDelete.ManufacturerEmail);
            
            return Unit.Value;
        }
    }
}
