namespace InternshipTask.Models
{
    public class Product
    {
        public int Id {get; set;} = 0;
        public string? Name {get; set;} = "Parsa";
        public DateTime ProductDate {get; set;} = DateTime.Now;
        public string? ManufacturePhone {get; set;} = "09934463133";
        public string? ManufactureEmail {get; set;} = "MJ@Parsa.com";
        public bool IsAvailable {get; set;} = true;
        public User? Creator {get; set;}       
    }
}
    
