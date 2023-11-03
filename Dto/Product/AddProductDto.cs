using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipTask.Dto.Product
{
    public class AddProductDto
    {
        public string? Name {get; set;} = "Parsa";
        public DateTime ProductDate {get; set;} = DateTime.Now;
        public string? ManufacturePhone {get; set;} = "09934463133";
        public string? ManufactureEmail {get; set;} = "MJ@Parsa.com";
        public bool IsAvailable {get; set;} = true;
    }
}