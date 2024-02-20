using AutoMapper;
using InternshipTask.Application.Contracts;
using InternshipTask.Application.Dto.Product;
using MediatR;

namespace InternshipTask.Application.CQRS.ProductCAndQ.Queries.GetProductByEmailManufacturer
{
    public class GetProductByManufacturerEmailQueryHandler : IRequestHandler<GetProductByManufacturerEmailQuery, GetProductDto>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetProductByManufacturerEmailQueryHandler(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<GetProductDto> Handle(GetProductByManufacturerEmailQuery request, CancellationToken cancellationToken)
        {
            var product = await _productService.GetProductByManufacturerEmail(request.ManufacturerEmail);
            return _mapper.Map<GetProductDto>(product);
        }
    }
}
