using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace InternshipTask.Services.ProductService
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
            serviceResponse.Data = dbProducts.Select(c=>_mapper.Map<GetProductDto>(c)).ToList();
            return serviceResponse;
            
        }
        public async Task<ServiceResponse<List<GetProductDto>>> GetProductById(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();
            var dbProducts = await _context.Products.ToListAsync();
            serviceResponse.Data = dbProducts.Select(c=>_mapper.Map<GetProductDto>(c)).ToList();
            return serviceResponse;

        }
        public async Task<ServiceResponse<List<GetProductDto>>> AddProduct(AddProductDto newProduct)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();
            var NewProduct = _mapper.Map<Product>(newProduct);
            _context.Products.Add(NewProduct);
            await _context.SaveChangesAsync();           
            serviceResponse.Data = await _context.Products.Select(c=>_mapper.Map<GetProductDto>(c)).ToListAsync();
            return serviceResponse;
        }  

        public async Task<ServiceResponse<GetProductDto>> UpdateProduct(UpdateProductDto updatedProduct)
        {
            var serviceResponse = new ServiceResponse<GetProductDto>();           
            try
            {              
                var product = await _context.Products.FirstOrDefaultAsync(c => c.Id == updatedProduct.Id);
                if(product is null)
                    throw new Exception($"Product with Id '{updatedProduct.Id}' not found!");
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

        public async Task<ServiceResponse<List<GetProductDto>>> DeleteProduct(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetProductDto>>();
            try
            {        
                var Product = await _context.Products.FirstOrDefaultAsync(c => c.Id == id);
                if(Product is null)
                    throw new Exception($"Product with Id '{id}' not found!");

                _context.Products.Remove(Product);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.Products.Select(c => _mapper.Map<GetProductDto>(c)).ToListAsync();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}  