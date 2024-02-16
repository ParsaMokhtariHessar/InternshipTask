using InternshipTask.Identity.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();
            builder.HasData(
                 new User
                 {
                     UserId = Guid.Parse("a9f2cf0b-3ef2-4ac7-ba49-94e9e9c0c0a2"),
                     UserName = "parsa",
                     PasswordHash = BCrypt.Net.BCrypt.HashPassword("P@ssword1")
                 }
            );
        }
    }
}
