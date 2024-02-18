using InternshipTask.Application.Exceptions;
using InternshipTask.Identity.IdentityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using InternshipTask.Application.Contracts;
using InternshipTask.Application.ApplicationModels.Identity;

namespace InternshipTask.Identity.Services.UserService
{
    internal class UserService : IUserService
    {
        private readonly UserManager<UserRole> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(UserManager<UserRole> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public Guid UserId  {
            get
            {
                var userIdString = _contextAccessor.HttpContext?.User?.FindFirstValue("UserId");

                if (Guid.TryParse(userIdString, out Guid userId))
                {
                    return userId;
                }
                else
                {
                    // Handle the case when parsing fails, for example, return a default Guid.
                    return Guid.Empty; // or throw an exception, or any other appropriate handling
                }
            }
        }

        public async Task<UserRole> GetUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new NotFoundException($"User with {userName} not found.", userName);
            }

            return new UserRole
            {
                UserId = user.UserId,
                UserName = user.UserName,
            };
        }

        public async Task<List<UserRole>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }
    }
}
