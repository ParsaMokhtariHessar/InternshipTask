using InternshipTask.Application.ApplicationModels.Identity;

namespace InternshipTask.Identity.Services.AuthService
{
    public interface IAuthService
    {
        // This is the auth service
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
