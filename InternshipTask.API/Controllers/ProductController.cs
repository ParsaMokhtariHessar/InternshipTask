using AutoMapper;
using InternshipTask.Application.Contracts;
using InternshipTask.Application.CQRS.ProductCAndQ.Commands.CreateProduct;
using InternshipTask.Application.CQRS.ProductCAndQ.Commands.DeleteProduct;
using InternshipTask.Application.CQRS.ProductCAndQ.Commands.UpdateProduct;
using InternshipTask.Application.CQRS.ProductCAndQ.Queries.GetAllProduct;
using InternshipTask.Application.CQRS.ProductCAndQ.Queries.GetProductByCreatorName;
using InternshipTask.Application.CQRS.ProductCAndQ.Queries.GetProductByEmailManufacturer;
using InternshipTask.Application.CQRS.ProductCAndQ.Queries.GetProductByName;
using InternshipTask.Application.Dto.Product;
using InternshipTask.Identity.Services.UserService;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternshipTask.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        //private readonly IUserService _userService;
        public ProductController(IProductService productService, IMapper mapper,IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetAll")]
        public async Task<ActionResult<List<GetProductDto>>> GetProducts()
        {
            var products = await _mediator.Send(new GetAllProductQuery());
            return Ok(_mapper.Map<List<GetProductDto>>(products));
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetByName/{name}")]
        public async Task<ActionResult<List<GetProductDto>>> GetProductsByName(string name)
        {
            var query = new GetByNameQuery { Name = name };
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetByManufacturerEmail/{manufacturerEmail}")]
        public async Task<ActionResult<List<GetProductDto>>> GetProductsByManufacturerEmail(string manufacturerEmail)
        {
            var query = new GetProductByManufacturerEmailQuery { ManufacturerEmail = manufacturerEmail };
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetByCreator/{CreatorName}")]
        public async Task<ActionResult<List<GetProductDto>>> GetProductsByCreator(string CreatorName)
        {
            var query = new GetProductByCreatorNameQuery { CreatorName = CreatorName };
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> CreateProduct(CreateProductDto newProduct)
        {
            var userId = HttpContext.User.FindFirst("Id")?.Value;
            newProduct.CreatorId = Guid.Parse(userId!);
            var command = new CreateProductCommand { ToBeCreatedProduct = newProduct };
            var response = await _mediator.Send(command);
           return CreatedAtAction(nameof(CreateProduct), response);

        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<ActionResult> UpdateProducts(UpdateProductDto toBeupdatedProduct)
        {
            var userId = HttpContext.User.FindFirst("Id")?.Value;
            toBeupdatedProduct.ModifierId = Guid.Parse(userId!);
            var command = new UpdateProductCommand { ToBeUpdatedProduct = toBeupdatedProduct };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        [Route("Delete/{ManufacturerEmail}")]
        public async Task<ActionResult> DeleteProduct(string ManufacturerEmail)
        {
            var userId = HttpContext.User.FindFirst("Id")?.Value;           
            var command = new DeleteProductCommand { RemoverId = Guid.Parse(userId!), ManufacturerEmail = ManufacturerEmail };
            await _mediator.Send(command);

            return NoContent();
        }

    }
}