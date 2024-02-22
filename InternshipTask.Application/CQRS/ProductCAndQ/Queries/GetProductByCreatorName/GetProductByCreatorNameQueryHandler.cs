using AutoMapper;
using InternshipTask.Application.Contracts;
using InternshipTask.Application.Dto.Product;
using InternshipTask.Identity.Services.UserService;
using MediatR;

namespace InternshipTask.Application.CQRS.ProductCAndQ.Queries.GetProductByCreatorName
{
    internal class GetProductByCreatorNameQueryHandler : IRequestHandler<GetProductByCreatorNameQuery, List<GetProductDto>>
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public GetProductByCreatorNameQueryHandler(IUserService userService, IProductService productService, IMapper mapper)
        {
            _userService = userService;
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<List<GetProductDto>> Handle(GetProductByCreatorNameQuery request, CancellationToken cancellationToken)
        {
            var creator = await _userService.GetUser(request.CreatorName!);
            var products = await _productService.GetProductByCreator(creator.UserId!);
            return _mapper.Map<List<GetProductDto>>(products);
        }
    }
}
