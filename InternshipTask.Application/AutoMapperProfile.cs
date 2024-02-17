using AutoMapper;
using InternshipTask.Application.Dto.Product;
using InternshipTask.Domain.ApplicationModels;

namespace InternshipTask.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, GetProductDto>();
            CreateMap<CreateProductDto, Product>();
            // CreateMap<UpdateProductDto,Product>();
        }

    }
}