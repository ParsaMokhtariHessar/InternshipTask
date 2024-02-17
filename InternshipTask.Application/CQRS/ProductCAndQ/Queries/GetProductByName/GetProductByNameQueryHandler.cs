using AutoMapper;
using InternshipTask.Application.CQRS.ProductCAndQ.Queries.GetProductByName;
using InternshipTask.Application.Dto.Product;
using InternshipTask.Application.Services.ProductService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
