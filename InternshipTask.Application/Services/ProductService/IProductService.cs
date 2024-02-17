using InternshipTask.Application.Dto.Product;
using InternshipTask.Domain.ApplicationModels;


namespace InternshipTask.Application.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetProductByName(string ProductName);
        Task<Product> GetProductByManufacturerEmail(string manufacturerEmail);
        Task<Product> GetProductByDate(DateTime productDate);
        Task CreateProduct(Product newProduct);
        Task UpdateProduct(Product ToBeUpdatedProduct);
        Task DeleteProduct(string ToBeDeletedProductName);
        Task<bool> IsProductDateUnique(DateTime productDate);
        Task<bool> IsManufactureEmailUnique(string ManufactureEmail);
    }
}