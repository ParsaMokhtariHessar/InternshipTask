using AutoMapper;
using InternshipTask.Application.Exceptions;
using InternshipTask.Application.Services.ProductService;
using InternshipTask.Domain.ApplicationModels;
using MediatR;

namespace InternshipTask.Application.CQRS.ProductCAndQ.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public CreateProductCommandHandler(IMapper mapper,IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }
        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator = new CreateProductCommandValidator(_productService);
            var validationResult = await validator.ValidateAsync(request.ToBeCreatedProduct, cancellationToken);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Product", validationResult);
            // convert to domain entity object
            var ProductToCreate = _mapper.Map<Product>(request.ToBeCreatedProduct);
            //additional logic for id is available and creator to be done
            //.......
            // add to database
            await _productService.CreateProduct(ProductToCreate);

            // retun record id
            return Unit.Value;

        }
    }
}
