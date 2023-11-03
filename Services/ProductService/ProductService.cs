using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace InternshipTask.Services.ProductService
{
    public class ProductService : IProductService
    {
        
        private static List<Product> Products = new List<Product> {
            new Product(),
            new Product {Id = 2, Name = "Pouriya"}
        };
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public List<GetProductDto> GetAllProducts()
        {
            return Products.Select(c=>_mapper.Map<GetProductDto>(c)).ToList();
        }
        public GetProductDto GetProductById(int id)
        {
            var Product = Products.FirstOrDefault(c => c.Id == id);
            if(Product is not null)
                return _mapper.Map<GetProductDto>(Product);

            throw new Exception("Product not found!");
        }
        public List<GetProductDto> AddProduct(AddProductDto newProduct)
        {
            var NewProduct = _mapper.Map<Product>(newProduct);
            NewProduct.Id = Products.Max(c=> c.Id) + 1;
            Products.Add(NewProduct);
            return Products.Select(c=>_mapper.Map<GetProductDto>(c)).ToList();
        }

        public GetProductDto UpdateProduct(UpdateProductDto UpdatedProduct)
        {
            

            var Product = Products.FirstOrDefault(c => c.Id == UpdatedProduct.Id);
            if(Product is null)
                throw new Exception($"Product with Id '{UpdatedProduct.Id}' not found!");
            // _mapper.Map(UpdatedProduct,Product); Couldn't Implement try later!
            Product.Name = UpdatedProduct.Name;
            Product.ProductDate = UpdatedProduct.ProductDate;
            Product.ManufacturePhone = UpdatedProduct.ManufacturePhone;
            Product.ManufactureEmail = UpdatedProduct.ManufactureEmail;
            Product.IsAvailable = UpdatedProduct.IsAvailable;
            return _mapper.Map<GetProductDto>(Product);                        
        }

        public List<GetProductDto> DeleteProduct(int id)
        {
            var Product = Products.First(c => c.Id == id) ?? throw new Exception($"Product with Id '{id}' not found!");

            // _mapper.Map(UpdatedProduct,Product); Couldn't Implement try later!
            Products.Remove(Product);
            return Products.Select(c => _mapper.Map<GetProductDto>(c)).ToList();
        }
    }
}