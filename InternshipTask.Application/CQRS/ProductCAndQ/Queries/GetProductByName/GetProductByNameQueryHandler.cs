using AutoMapper;
using InternshipTask.Application.Contracts;
using InternshipTask.Application.CQRS.ProductCAndQ.Queries.GetProductByName;
using InternshipTask.Application.Dto.Product;
using MediatR;

namespace InternshipTask.Application.CQRS.ProductCAndQ.Queries
{
    public class GetByNameQueryHandler : IRequestHandler<GetByNameQuery, List<GetProductDto>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetByNameQueryHandler(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<List<GetProductDto>> Handle(GetByNameQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetProductByName(request.Name);
            return _mapper.Map<List<GetProductDto>>(products);
        }
    }
}
