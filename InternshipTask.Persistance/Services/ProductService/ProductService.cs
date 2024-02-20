using InternshipTask.Application.Contracts;
using InternshipTask.Domain.ApplicationModels;
using InternshipTask.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace InternshipTask.Persistance.Services.ProductService
{
    public class ProductService : IProductService
    {

        public readonly ProductDataContext _context;
        public ProductService(ProductDataContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();

            if (products == null || products.Count == 0)
            {
                throw new InvalidOperationException("No products found");
            }

            return products;
        }

        public async Task<List<Product>> GetProductByName(string productName)
        {
            var products = await _context.Products.Where(p => p.Name == productName).ToListAsync();

            if (products == null || products.Count == 0)
            {
                throw new InvalidOperationException($"No products found with name '{productName}'");
            }

            return products;
        }

        public async Task<Product> GetProductByManufacturerEmail(string manufacturerEmail)
        {

            var product = await _context.Products.FirstOrDefaultAsync(p => p.ManufactureEmail == manufacturerEmail);
            if (product == null)
            {
                // Handle the case where no product is found with the specified manufacturerEmail.
                // You might throw an exception, return a default value, or handle it based on your requirements.
                throw new InvalidOperationException($"Product with manufacturer email '{manufacturerEmail}' not found");
            }
            return product;
        }

        public async Task<Product> GetProductByDate(DateTime productDate)
        {
            DateTime startDate = productDate.Date;
            DateTime endDate = startDate.AddDays(1);

            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.ProductDate >= startDate && p.ProductDate < endDate);

            if (product == null)
            {
                throw new InvalidOperationException($"No product found on date '{productDate.ToShortDateString()}'");
            }

            return product;
        }

        public async Task CreateProduct(Product newProduct)
        {
            var createdProductEntry = await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product newProduct)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.ManufactureEmail == newProduct.ManufactureEmail);

            if (existingProduct == null)
            {
                throw new ArgumentException($"Product with ManufactureEmail '{newProduct.ManufactureEmail}' not found", nameof(newProduct.ManufactureEmail));
            }
            // Update existingProduct properties with values from newProduct
            existingProduct.Name = newProduct.Name;
            existingProduct.ProductDate = newProduct.ProductDate;
            existingProduct.ManufacturePhone = newProduct.ManufacturePhone;
            existingProduct.ManufactureEmail = newProduct.ManufactureEmail;
            existingProduct.IsAvailable = newProduct.IsAvailable;
            existingProduct.CreatorId = newProduct.CreatorId;

            // Mark the existingProduct as modified
            _context.Update(existingProduct);

            // Save changes
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(string ManufactureEmail)
        {
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.ManufactureEmail == ManufactureEmail);

            if (existingProduct == null)
            {
                throw new ArgumentException("Product not found", nameof(existingProduct.Name));
            }

            _context.Products.Remove(existingProduct);

            await _context.SaveChangesAsync();
        }

        public async Task<bool> DoesManufactureEmailExist(string manufactureEmail)
        {            
            return await _context.Products.AnyAsync(p => p.ManufactureEmail == manufactureEmail);
        }

        public async Task<bool> DoesProductDateExist(DateTime productDate)
        {              
            return await _context.Products.AnyAsync(p => p.ProductDate.Date == productDate.Date);
        }
    }
}