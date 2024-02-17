using InternshipTask.Application.Dto.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipTask.Application.CQRS.ProductCAndQ.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Unit>
    {
        public CreateProductDto ToBeCreatedProduct { get; set; } = new CreateProductDto();
    }
}
