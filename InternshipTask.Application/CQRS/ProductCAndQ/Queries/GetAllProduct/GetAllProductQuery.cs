using InternshipTask.Application.Dto.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipTask.Application.CQRS.ProductCAndQ.Queries.GetAllProduct
{
    public record GetAllProductQuery : IRequest<List<GetProductDto>>;
}
