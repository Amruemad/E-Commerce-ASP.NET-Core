using Ecommerce.Models.Models;
using Ecommerce.Service.Contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration config;
        private readonly SymmetricSecurityKey key;
        private readonly UserManager<AppUser> userManager;

        public TokenService(IConfiguration _config, UserManager<AppUser> _userManger)
        {
            config = _config;
            userManager = _userManger;
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["jwt:Key"]));
        }

        public async Task<string> CreateToken(AppUser user)
        {
            var roles = await userManager.GetRolesAsync(user);

            // Creating new claims that will be added to the token
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),
            };

            // Add roles as claims
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // Creating signing credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Generating a TokenDescriptor and assigning its parameters with the previously created object
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds,
                Issuer = config["jwt:Issuer"],
                Audience = config["jwt:Audience"]
            };

            // Generating Token with TokenHandler and assigning TokenDescriptor to it
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
