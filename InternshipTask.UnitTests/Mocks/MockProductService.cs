using InternshipTask.Application.Contracts;
using InternshipTask.Domain.ApplicationModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipTask.UnitTests.Mocks
{
    public class MockProductService
    {
        public static Mock<IProductService> GetMockProductService()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "MockProduct1",
                    ProductDate = DateTime.Parse("2001"),
                    ManufacturerPhone = "0911",
                    ManufacturerEmail = "me1@me.com",
                    IsAvailable = true,
                    CreatorId = Guid.NewGuid()
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "MockProduct2",
                    ProductDate = DateTime.Parse("2002"),
                    ManufacturerPhone = "0912",
                    ManufacturerEmail = "me2@me.com",
                    IsAvailable = true,
                    CreatorId = Guid.NewGuid()
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "MockProduct2",
                    ProductDate = DateTime.Parse("2003"),
                    ManufacturerPhone = "0913",
                    ManufacturerEmail = "me3@me.com",
                    IsAvailable = false,
                    CreatorId = Guid.NewGuid()
                }
            };

            var mockrepo = new Mock<IProductService>();
            // Mock for GetProductByName
            mockrepo.Setup(r => r.GetProductByName(It.IsAny<string>()))
                     .ReturnsAsync((string productName) => products.Where(p => p.Name == productName).ToList());

            // Mock for GetProductByManufacturerEmail
            mockrepo.Setup(r => r.GetProductByManufacturerEmail(It.IsAny<string>()))
                     .ReturnsAsync((string manufacturerEmail) => products.FirstOrDefault(p => p.ManufacturerEmail == manufacturerEmail));

            // Mock for GetProductByDate
            mockrepo.Setup(r => r.GetProductByDate(It.IsAny<DateTime>()))
                     .ReturnsAsync((DateTime productDate) =>
                         products.FirstOrDefault(p => p.ProductDate.Date == productDate.Date));

            // Mock for GetProductByCreator
            mockrepo.Setup(r => r.GetProductByCreator(It.IsAny<Guid>()))
                     .ReturnsAsync((Guid creatorId) => products.Where(p => p.CreatorId == creatorId).ToList());

            // Mock for CreateProduct
            mockrepo.Setup(r => r.CreateProduct(It.IsAny<Product>()))
                     .Callback<Product>((newProduct) =>
                     {
                         newProduct.Id = Guid.NewGuid();
                         products.Add(newProduct);
                     })
                     .Returns(Task.CompletedTask);

            // Mock for UpdateProduct
            mockrepo.Setup(r => r.UpdateProduct(It.IsAny<Product>()))
                     .Callback<Product>((updatedProduct) =>
                     {
                         var existingProduct = products.FirstOrDefault(p => p.ManufacturerEmail == updatedProduct.ManufacturerEmail);
                         if (existingProduct != null)
                         {
                             // Update existingProduct properties with values from updatedProduct
                             existingProduct.Name = updatedProduct.Name;
                             existingProduct.ProductDate = updatedProduct.ProductDate;
                             existingProduct.ManufacturerPhone = updatedProduct.ManufacturerPhone;
                             existingProduct.IsAvailable = updatedProduct.IsAvailable;
                             existingProduct.CreatorId = updatedProduct.CreatorId;
                         }
                     })
                     .Returns(Task.CompletedTask);

            // Mock for DeleteProduct
            mockrepo.Setup(r => r.DeleteProduct(It.IsAny<string>()))
                     .Callback<string>((manufacturerEmail) =>
                     {
                         var existingProduct = products.FirstOrDefault(p => p.ManufacturerEmail == manufacturerEmail);
                         if (existingProduct != null)
                         {
                             products.Remove(existingProduct);
                         }
                     })
                     .Returns(Task.CompletedTask);

            // Mock for DoesManufacturerEmailExist
            mockrepo.Setup(r => r.DoesManufacturerEmailExist(It.IsAny<string>()))
                     .ReturnsAsync((string manufacturerEmail) => !products.Any(p => p.ManufacturerEmail == manufacturerEmail));

            // Mock for DoesProductDateExist
            mockrepo.Setup(r => r.DoesProductDateExist(It.IsAny<DateTime>()))
                     .ReturnsAsync((DateTime productDate) => products.Any(p => p.ProductDate.Date == productDate.Date));

            // Mock for DoesIdOwnProduct
            mockrepo.Setup(r => r.DoesIdOwnProduct(It.IsAny<Guid>(), It.IsAny<string>()))
                     .ReturnsAsync((Guid id, string manufacturerEmail) =>
                     {
                         var theProduct = products.FirstOrDefault(p => p.ManufacturerEmail == manufacturerEmail);
                         return theProduct != null && theProduct.CreatorId == id;
                     });

            return mockrepo;
        }
    }
}
