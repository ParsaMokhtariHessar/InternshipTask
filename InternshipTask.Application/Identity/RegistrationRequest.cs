using System.ComponentModel.DataAnnotations;

namespace InternshipTask.Application.Identity
{
    public class RegistrationRequest
    {
        [Required]
        [MinLength(6)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;
    }
}
