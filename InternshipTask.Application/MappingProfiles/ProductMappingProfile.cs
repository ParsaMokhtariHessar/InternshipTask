using AutoMapper;
using InternshipTask.Application.Dto.Product;
using InternshipTask.Domain.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipTask.Application.MappingProfiles
{
    internal class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<CreateProductDto,Product>();
            CreateMap<Product,GetProductDto>();
            CreateMap<UpdateProductDto,Product>();
        }
        
    }
}
