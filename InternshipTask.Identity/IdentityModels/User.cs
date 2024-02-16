using Microsoft.AspNetCore.Identity;

namespace InternshipTask.Identity.IdentityModels
{
    public class User : IdentityUser<Guid>
    {
        // Remove Email-related properties
        public override string Email { get; set; }
        public override bool EmailConfirmed { get; set; }
        public override string NormalizedEmail { get; set; }
        public Guid UserId { get; set; }
    }
}