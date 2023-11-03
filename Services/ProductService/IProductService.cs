using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace InternshipTask.Services.ProductService
{
    public interface IProductService
    {
        List<GetProductDto> GetAllProducts();
        GetProductDto GetProductById(int id);
        List<GetProductDto> AddProduct(AddProductDto newProduct);
        GetProductDto UpdateProduct(UpdateProductDto UpdatedProduct);

    }
}