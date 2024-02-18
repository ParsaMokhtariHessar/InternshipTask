using AutoMapper;
using InternshipTask.Application.Contracts;
using InternshipTask.Application.Exceptions;
using InternshipTask.Domain.ApplicationModels;
using MediatR;

namespace InternshipTask.Application.CQRS.ProductCAndQ.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
                // Validate incoming data
                var validator = new UpdateProductCommandValidator(_productService);
                if(request.ToBeUpdatedProduct == null)
                {
                    throw new BadRequestException("ToBeUpdatedProduct cannot be null");
                }
                var validationResult = await validator.ValidateAsync(request.ToBeUpdatedProduct, cancellationToken);
           
                if (validationResult.Errors.Any())
                    throw new BadRequestException("Invalid Product", validationResult);

                // Perform the update operation
                await _productService.UpdateProduct(_mapper.Map<Product>(request.ToBeUpdatedProduct));

            return Unit.Value;
        }
    }
}
