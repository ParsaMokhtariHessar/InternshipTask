using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternshipTask.src.Core.Domain.Models;

namespace InternshipTask.Infrastructure.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}