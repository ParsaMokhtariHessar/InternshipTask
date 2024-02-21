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
                     Id = Guid.Parse("99da5af7-a7c9-41a3-276a-08dc327002ac"),
                     UserName = "parsaa",
                     NormalizedUserName = "PARSAA",
                     SecurityStamp = "F5HE5ITOIQO2N3S5ZHUONLICGAQYI56U",
                     PasswordHash = BCrypt.Net.BCrypt.HashPassword("P@ssword1")
                 }
            );
        }
    }
}
