using InternshipTask.Application.Exceptions;
using InternshipTask.Identity.IdentityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace InternshipTask.Identity.Services.UserService
{
    internal class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(UserManager<User> userManager, IHttpContextAccessor contextAccessor)
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

        public async Task<User> GetUser(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new NotFoundException($"User with {userName} not found.", userName);
            }

            return new User
            {
                UserId = user.UserId,
                UserName = user.UserName,
            };
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }
    }
}
