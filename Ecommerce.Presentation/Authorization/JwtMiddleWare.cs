using Ecommerce.Service.Contract;
using Microsoft.Extensions.Options;

namespace Ecommerce.Presentation.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ConfigurationManager _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<ConfigurationManager> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IAppUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = jwtUtils.ValidateToken(token);
            if (userId != null)
            {
                // attach user to context on successful jwt validation
                context.Items["User"] = await userService.GetUserById(userId.Value);
            }

            await _next(context);
        }
    }
}
