using InternshipTask.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using InternshipTask.Domain.ApplicationModels;

namespace InternshipTask.Application.Services.ProductService
{
    public class ProductService : IProductService
    {
        
        public readonly DataContext _context;
        public ProductService(DataContext context)
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

        public async Task<bool> IsManufactureEmailUnique(string manufactureEmail)
        {
            bool isUnique = await _context.Products.AllAsync(p =>
                p.ManufactureEmail != manufactureEmail);

            return isUnique;
        }

        public async Task<bool> IsProductDateUnique(DateTime productDate)
        {
            DateTime startDate = productDate.Date;
            DateTime endDate = startDate.AddDays(1); // Add one day to include the entire date range

            bool isUnique = await _context.Products.AllAsync(p =>
                p.ProductDate >= startDate && p.ProductDate < endDate);

            return isUnique;
        }
    }
}