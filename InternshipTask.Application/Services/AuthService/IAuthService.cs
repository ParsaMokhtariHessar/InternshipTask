using InternshipTask.Application.Identity;

namespace InternshipTask.Application.Services.AuthService
{
    internal interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
