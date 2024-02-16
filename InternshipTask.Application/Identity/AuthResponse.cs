namespace InternshipTask.Application.Identity
{
    public class AuthResponse
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
