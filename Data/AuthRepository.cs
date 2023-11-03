using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipTask.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        private readonly IConfiguration _configuration;
        public AuthRepository(DataContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;
        }

        public Task<ServiceResponse<string>> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        // public async Task<ServiceResponse<string>> Login(string Username, string password)
        // {
        //     ServiceResponse<string> response = new ServiceResponse<string>();
        //     User user = await _context.Users.FirstOrDefaultAsync(x => x.UserName.ToLower().Equals(UserName.ToLower()));
        //     if (user == null)
        //     {
        //         response.Success = false;
        //         response.Message = "User not found.";
        //     }
        //     else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        //     {
        //         response.Success = false;
        //         response.Message = "Wrong password";
        //     }
        //     else
        //     {
        //         response.Data = CreateToken(user);
        //     }

        //     return response;
        // }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            if (await UserExists(user.UserName))
            {
                response.Success = false;
                response.Message = "User already exists.";
                return response;
            }

            Hash.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            response.Data = user.Id;
            return response;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }


    }
}