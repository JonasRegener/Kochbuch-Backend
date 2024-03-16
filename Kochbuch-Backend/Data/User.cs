using Microsoft.AspNetCore.Identity;

namespace Kochbuch_Backend.Data
{
    public class User : IdentityUser

    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
