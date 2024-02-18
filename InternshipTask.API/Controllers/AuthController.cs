using InternshipTask.Application.ApplicationModels.Identity;
using InternshipTask.Identity.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace InternshipTask.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authenticationService;
        public AuthController(IAuthService authService)
        {
            _authenticationService = authService;
        }

        

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _authenticationService.Login(request));
            
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            return Ok(await _authenticationService.Register(request));
        }
    }
}