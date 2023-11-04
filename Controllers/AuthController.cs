using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternshipTask.Dto.User;
using Microsoft.AspNetCore.Mvc;

namespace InternshipTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserRegisterDto request)
        {
            ServiceResponse<int> response = await _authRepo.Register(
                new User { UserName = request.UserName }, request.Password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            ServiceResponse<string> response = await _authRepo.Login(
                request.UserName, request.Password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}