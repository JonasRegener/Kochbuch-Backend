using System.ComponentModel.DataAnnotations;

namespace Kochbuch_Backend.Models.User
{
    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "You password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }

    }
}
