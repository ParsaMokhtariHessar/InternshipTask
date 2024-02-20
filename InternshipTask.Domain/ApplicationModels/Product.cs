namespace InternshipTask.Domain.ApplicationModels
{
    public class Product
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime ProductDate { get; set; }
        public string? ManufacturePhone { get; set; }
        public string? ManufactureEmail { get; set; }
        public bool IsAvailable { get; set; } = true;
        public Guid CreatorId { get; set; }
    }
}

