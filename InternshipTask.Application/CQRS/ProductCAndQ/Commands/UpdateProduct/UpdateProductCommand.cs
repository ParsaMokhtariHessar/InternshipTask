using InternshipTask.Application.Dto.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipTask.Application.CQRS.ProductCAndQ.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public UpdateProductDto? ToBeUpdatedProduct { get; set; }
    }
}
