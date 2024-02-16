using System.Security.Claims;
using InternshipTask.Application.Dto.Product;
using InternshipTask.Application.Services.ProductService;
using InternshipTask.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternshipTask.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<Domain.Models.ServiceResponse<GetProductDto>>> GetProducts()
        {
            return Ok(await _productService.GetAllProducts());
        }
        [HttpGet]
        [Route("GetSingle/{id}")]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> GetSingleProduct(Guid id)
        {
            return Ok(await _productService.GetProductById(id));
        }
        [Authorize]
        [HttpPost]
        [Route("PostSingle")]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> AddProduct(AddProductDto newProduct)
        {
            Guid id = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
            return Ok(await _productService.AddProduct(newProduct, id));
        }
        [Authorize]
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> UpdateProduct(UpdateProductDto UpdatedProduct)
        {
            Guid id = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)!.Value);
            var Response = await _productService.UpdateProduct(UpdatedProduct, id);
            if (Response.Data is null)
            {
                return NotFound(Response);
            }
            else
            {
                return Ok(Response);
            }


        }
        [HttpDelete]
        [Route("DeleteSingle/{id}")]
        public async Task<ActionResult<ServiceResponse<GetProductDto>>> DeleteSingleProduct(Guid id)
        {
            var Response = await _productService.DeleteProduct(id);
            if (Response.Data is null)
            {
                return NotFound(Response);
            }
            else
            {
                return Ok(Response);
            }
        }
    }
}