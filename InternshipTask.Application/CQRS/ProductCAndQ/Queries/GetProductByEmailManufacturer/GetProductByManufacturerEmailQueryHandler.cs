using AutoMapper;
using InternshipTask.Application.Dto.Product;
using InternshipTask.Application.Services.ProductService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
