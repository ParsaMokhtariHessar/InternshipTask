using AutoMapper;
using InternshipTask.Application.Dto.Product;
using InternshipTask.Domain.Models;
using InternshipTask.Infrastructure.Data;
using System.Data;
using Microsoft.EntityFrameworkCore;
using InternshipTask.Migrations;
using InternshipTask.Domain.ApplicationModels;

namespace InternshipTask.Application.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        public readonly DataContext _context;
        public ProductService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetProductDto>>> GetAllProducts()
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();
            var dbProducts = await _context.Products.ToListAsync();
            serviceResponse.Data = dbProducts.Select(c => _mapper.Map<GetProductDto>(c)).ToList();
            return serviceResponse;

        }
        public async Task<ServiceResponse<List<GetProductDto>>> GetProductById(Guid id)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();
            var dbProducts = await _context.Products.ToListAsync();
            serviceResponse.Data = dbProducts.Select(c => _mapper.Map<GetProductDto>(c)).ToList();
            return serviceResponse;

        }
        public async Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto newProduct, Guid userId)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();

            // Check if ManufactureEmail is unique
            if (await _context.Products.AnyAsync(p => p.ManufactureEmail == newProduct.ManufactureEmail))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "ManufactureEmail must be unique.";
                return serviceResponse;
            }

            // Check if ProductDate is unique
            if (await _context.Products.AnyAsync(p => p.ProductDate == newProduct.ProductDate))
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "ProductDate must be unique.";
                return serviceResponse;
            }

            var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == userId);

            if (user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found.";
                return serviceResponse;
            }

            var NewProduct = _mapper.Map<Product>(newProduct);
            NewProduct.Creator = user;
            _context.Products.Add(NewProduct);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Products.Select(c => _mapper.Map<GetProductDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductDto>> UpdateProduct(UpdateProductDto updatedProduct, Guid userId)
        {
            var serviceResponse = new ServiceResponse<GetProductDto>();

            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(c => c.Id == updatedProduct.Id);
                if (product is null)
                {
                    throw new Exception($"Product with Id '{updatedProduct.Id}' not found!");
                    // Check if the user ID matches the creator ID
                }
                if (product.Creator.Id != userId) // this is where the warning Derefrence of a possibly null reference happens
                {
                    throw new Exception("You don't have permission to update this product.");
                    // Alternatively, you can set the serviceResponse properties accordingly and return here
                }
                // _mapper.Map(UpdatedProduct,Product); Couldn't Implement try later!
                // _mapper.Map<Product>(UpdatedProduct);
                product.Name = updatedProduct.Name;
                product.ProductDate = updatedProduct.ProductDate;
                product.ManufacturePhone = updatedProduct.ManufacturePhone;
                product.ManufactureEmail = updatedProduct.ManufactureEmail;
                product.IsAvailable = updatedProduct.IsAvailable;
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetProductDto>(product);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }


            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductDto>>> DeleteProduct(Guid id)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();
            try
            {
                var Product = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
                if (Product is null)
                    throw new Exception($"Product with Id '{id}' not found!");

                _context.Products.Remove(Product);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Products.Select(c => _mapper.Map<GetProductDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

    }
}