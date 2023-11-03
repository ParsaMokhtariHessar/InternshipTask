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
            var _UpdatedProduct =_ProductService.UpdateProduct(UpdatedProduct); 
            if(_UpdatedProduct is null)
            {
                return NotFound(_UpdatedProduct);
            }
            else
            {
               return Ok(_UpdatedProduct); 
            }    
            
        }
        [HttpDelete]
        [Route("DeleteSingle/{id}")]
        public ActionResult<GetProductDto> DeleteSingleProduct(int id)
        {
            var _DeletedProduct =_ProductService.DeleteProduct(id); 
            if(_DeletedProduct is null)
            {
                return NotFound(_DeletedProduct);
            }
            else
            {
               return Ok(_DeletedProduct); 
            }
        }
    }
}