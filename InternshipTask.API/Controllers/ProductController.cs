using AutoMapper;
using InternshipTask.Application.CQRS.ProductCAndQ.Commands.CreateProduct;
using InternshipTask.Application.CQRS.ProductCAndQ.Commands.DeleteProduct;
using InternshipTask.Application.CQRS.ProductCAndQ.Commands.UpdateProduct;
using InternshipTask.Application.CQRS.ProductCAndQ.Queries.GetAllProduct;
using InternshipTask.Application.CQRS.ProductCAndQ.Queries.GetProductByEmailManufacturer;
using InternshipTask.Application.CQRS.ProductCAndQ.Queries.GetProductByName;
using InternshipTask.Application.Dto.Product;
using InternshipTask.Application.Services.ProductService;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InternshipTask.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ProductController(IProductService productService, IMapper mapper,IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<GetProductDto>>> GetProducts()
        {
            var products = await _mediator.Send(new GetAllProductQuery());
            return Ok(_mapper.Map<List<GetProductDto>>(products));
        }

        [HttpGet]
        [Route("GetByName/{name}")]
        public async Task<ActionResult<List<GetProductDto>>> GetProductsByName(string name)
        {
            var query = new GetByNameQuery { Name = name };
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpGet]
        [Route("GetByManufacturerEmail/{manufacturerEmail}")]
        public async Task<ActionResult<List<GetProductDto>>> GetProductsByManufacturerEmail(string manufacturerEmail)
        {
            var query = new GetByManufacturerEmailQuery { ManufacturerEmail = manufacturerEmail };
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> CreateProduct(CreateProductDto newProduct)
        {
            var command = new CreateProductCommand { ToBeCreatedProduct = newProduct };
            var response = await _mediator.Send(command);

            if (response == Unit.Value)
            {
                return NoContent(); // Assuming you want to return 204 No Content for successful creation without a specific resource representation.
            }

            return CreatedAtAction(nameof(CreateProduct), response);
        }

        [HttpPut]
        [Route("UpdateProducts")]
        public async Task<ActionResult> UpdateProducts(UpdateProductDto updatedProducts)
        {
            var command = new UpdateProductCommand { ToBeUpdatedProduct = updatedProducts };
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult> DeleteProduct(string ManufacturerEmail)
        {
            var command = new DeleteProductCommand { ManufacturerEmail = ManufacturerEmail };
            await _mediator.Send(command);

            return NoContent();
        }

    }
}