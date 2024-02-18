using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternshipTask.Domain.ApplicationModels;
using System.Globalization;

namespace InternshipTask.Persistance.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder) 
        {
            builder.HasData(
                new Product
                {
                    Id = Guid.Parse("3726979c-1c78-4308-9e8a-84f5c390fb3a"),
                    Name = "NadineSoft",
                    ProductDate = DateTime.ParseExact("2024-01-01", "yyyy-mm-dd", CultureInfo.InvariantCulture),
                    ManufacturePhone = "09994994949",
                    ManufactureEmail = "nadine@nadinsoft.com",
                    IsAvailable = true,
                    CreatorId = Guid.Parse("a9f2cf0b-3ef2-4ac7-ba49-94e9e9c0c0a2")
                }                                                                           
            );
               
        }
    }
}
