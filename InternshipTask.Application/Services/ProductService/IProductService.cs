using InternshipTask.Application.Dto.Product;
using InternshipTask.Domain.Models;


namespace InternshipTask.Application.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductDto>>> GetAllProducts();
        Task<ServiceResponse<List<GetProductDto>>> GetProductById(Guid id);
        Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto newProduct, Guid userId);
        Task<ServiceResponse<GetProductDto>> UpdateProduct(UpdateProductDto UpdatedProduct, Guid userId);
        Task<ServiceResponse<List<GetProductDto>>> DeleteProduct(Guid id);
    }
}