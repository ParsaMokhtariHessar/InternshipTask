using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipTask
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product,GetProductDto>();
            CreateMap<AddProductDto,Product>();
            // CreateMap<UpdateProductDto,Product>();
        }
        
    }
}