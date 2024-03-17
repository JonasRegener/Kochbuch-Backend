using System.ComponentModel.DataAnnotations;

namespace Kochbuch_Backend.Models.User
{
    public class UserDto : UserLoginDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

    }
}
