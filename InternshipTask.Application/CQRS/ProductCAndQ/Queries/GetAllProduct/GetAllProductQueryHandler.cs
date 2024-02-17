using AutoMapper;
using InternshipTask.Application.CQRS.ProductCAndQ.Queries.GetAllProduct;
using InternshipTask.Application.Dto.Product;
using InternshipTask.Application.Services.ProductService;
using MediatR;

namespace InternshipTask.Application.CQRS.ProductCAndQ.Queries
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<GetProductDto>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<List<GetProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllProducts();
            return _mapper.Map<List<GetProductDto>>(products);
        }
    }
}
