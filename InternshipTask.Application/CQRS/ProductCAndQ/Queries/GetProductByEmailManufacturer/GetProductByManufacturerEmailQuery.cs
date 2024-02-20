using InternshipTask.Application.Dto.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipTask.Application.CQRS.ProductCAndQ.Queries.GetProductByEmailManufacturer
{
    public record GetProductByManufacturerEmailQuery : IRequest<GetProductDto>
    {
        public string ManufacturerEmail { get; init; } = string.Empty;
    }
}
