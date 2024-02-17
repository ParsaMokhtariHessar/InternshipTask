using InternshipTask.Application.Dto.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipTask.Application.CQRS.ProductCAndQ.Queries.GetProductByName
{
    public record GetByNameQuery : IRequest<List<GetProductDto>>
    {
        public string Name { get; init; } = string.Empty;
    }
}
