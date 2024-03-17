using AutoMapper;
using Kochbuch_Backend.Contracts;
using Kochbuch_Backend.Data;
using Kochbuch_Backend.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Text;

namespace Kochbuch_Backend.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        public AuthManager(IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            this._mapper = mapper;
            this._userManager = userManager;
            this._configuration = configuration;
        }

        public async Task<AuthResponeDto> Login(UserLoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            bool isValidUser = await _userManager.CheckPasswordAsync(user, loginDto.Password);


            if (isValidUser == false || user == null)
            {
                return null;
            }

            var token = await GenerateToken(user);

            return new AuthResponeDto
            {
                Token = token,
                UserId = user.Id
            };
        }

        public async Task<IEnumerable<IdentityError>> Register(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.UserName = userDto.Email;

            var result = await _userManager.CreateAsync(user, userDto.Password);


            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }
            return result.Errors;
        }

        private async Task<string> GenerateToken(User user)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();

            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims).Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);


        }
        
    }
}
