using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipTask.Application.Dto.Product
{
    public class UpdateProductDto
    {
        public string? Name { get; set; }
        public DateTime ProductDate { get; set; }
        public string? ManufacturePhone { get; set; }
        public string? ManufacturerEmail { get; set; }
        public bool IsAvailable { get; set; }
        public Guid ModifierId { get; set; }
    }
}