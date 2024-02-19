using InternshipTask.Identity.IdentityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternshipTask.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(
                 new ApplicationUser
                 {
                     Id = Guid.Parse("a9f2cf0b-3ef2-4ac7-ba49-94e9e9c0c0a2"),
                     UserName = "parsa",
                     PasswordHash = BCrypt.Net.BCrypt.HashPassword("P@ssword1")
                 }
            );
        }
    }
}
