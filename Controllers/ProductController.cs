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
        private static List<Product> Products = new List<Product>{
            new Product(),
            new Product { Id=1 ,Name = "Pouriya"}
        };
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<Product> GetProducts()
        {
            return Ok(Products);
        }
        [HttpGet]
        [Route("GetSingle/{id}")]
        public ActionResult<Product> GetSingleProduct(int id)
        {
            return Ok(Products.FirstOrDefault(c => c.Id == id ));
        }
        [HttpPost]
        [Route("PostSingle")]
        public ActionResult<Product> AddProduct(Product newProduct)
        {
            Products.Add(newProduct);
            return Ok(Products);
        }
    }
}