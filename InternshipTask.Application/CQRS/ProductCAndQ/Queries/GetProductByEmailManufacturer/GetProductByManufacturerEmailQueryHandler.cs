using AutoMapper;
using InternshipTask.Application.Contracts;
using InternshipTask.Application.Dto.Product;
using MediatR;

namespace InternshipTask.Application.CQRS.ProductCAndQ.Queries.GetProductByEmailManufacturer
{
    public class GetByManufacturerEmailQueryHandler : IRequestHandler<GetByManufacturerEmailQuery, List<GetProductDto>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetByManufacturerEmailQueryHandler(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<List<GetProductDto>> Handle(GetByManufacturerEmailQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetProductByManufacturerEmail(request.ManufacturerEmail);
            return _mapper.Map<List<GetProductDto>>(products);
        }
    }
}
