using InternshipTask.Application.ApplicationModels.Identity;

namespace InternshipTask.Identity.Services.UserService
{
    public interface IUserService
    {
        Task<List<UserRole>> GetUsers();
        Task<UserRole> GetUser(string userName);
        public Guid UserId { get; }
    }
}
