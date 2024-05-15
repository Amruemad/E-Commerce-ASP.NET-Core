using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Presentation.Authorization
{
    public interface IJwtUtils
    {
        int? ValidateToken(string token);
    }
    
    public class JwtUtils : IJwtUtils
    {
        private readonly IConfiguration _appSettings;
        public JwtUtils(IConfiguration appSettings)
        {
            _appSettings = appSettings;
        }

        public int? ValidateToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings["jwt:Key"]);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _appSettings["jwt:Issuer"],
                    ValidAudience = _appSettings["jwt:Audience"],
                    ClockSkew = TimeSpan.Zero
                }, out var validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.NameId).Value);

                return userId;
            }
            catch
            {
                return null;
            }
        }
    }
}
