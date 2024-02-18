namespace InternshipTask.Application.ApplicationModels.Identity
{
    public class AuthResponse
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
