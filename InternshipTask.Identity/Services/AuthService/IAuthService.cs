using InternshipTask.Application.Identity;

namespace InternshipTask.Identity.Services.AuthService
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
