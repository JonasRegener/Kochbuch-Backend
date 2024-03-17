using Kochbuch_Backend.Data;
using Kochbuch_Backend.Models.User;
using Microsoft.AspNetCore.Identity;

namespace Kochbuch_Backend.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(UserDto userDto);

        Task<AuthResponeDto> Login(UserLoginDto userDto);
    }
}
