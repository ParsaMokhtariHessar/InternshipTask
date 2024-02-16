using InternshipTask.Identity.IdentityModels;

namespace InternshipTask.Identity.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUser(string userName);
        public Guid UserId { get; }
    }
}
