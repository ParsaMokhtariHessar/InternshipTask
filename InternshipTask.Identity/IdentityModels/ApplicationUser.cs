using Microsoft.AspNetCore.Identity;

namespace InternshipTask.Identity.IdentityModels
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        // Remove Email-related properties
        public override string? Email { get; set; } = string.Empty;
        public override bool EmailConfirmed { get; set; } = true;
        public override string? NormalizedEmail { get; set; } = string.Empty;
        public Guid UserId { get; set; } = Guid.NewGuid();
    }
}