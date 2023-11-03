using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace InternshipTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;
        public ProductController(IProductService ProductService)
        {
            _ProductService = ProductService;
            
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<GetProductDto> GetProducts()
        {
            return Ok(_ProductService.GetAllProducts());
        }
        [HttpGet]
        [Route("GetSingle/{id}")]
        public ActionResult<GetProductDto> GetSingleProduct(int id)
        {
            return Ok(_ProductService.GetProductById(id));
        }
        [HttpPost]
        [Route("PostSingle")]
        public ActionResult<GetProductDto> AddProduct(AddProductDto newProduct)
        {            
            return Ok(_ProductService.AddProduct(newProduct));
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public ActionResult<GetProductDto> UpdateProduct(UpdateProductDto UpdatedProduct)
        {            
            return Ok(_ProductService.UpdateProduct(UpdatedProduct));
        }
    }
}