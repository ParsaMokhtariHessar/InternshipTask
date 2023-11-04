using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace InternshipTask.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductDto>>> GetAllProducts();
        Task<ServiceResponse<List<GetProductDto>>> GetProductById(int id);
        Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto newProduct,int userId);
        Task<ServiceResponse<GetProductDto>> UpdateProduct(UpdateProductDto UpdatedProduct,int userId);
        Task<ServiceResponse<List<GetProductDto>>> DeleteProduct(int id);

    }
}