using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Parking.Api.Services;
using Parking.Core.Repositories;

namespace Parking.Api.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate next;

        public JwtMiddleware(RequestDelegate next) => this.next = next;

        /* in part from: https://github.com/cornflourblue/aspnet-core-3-jwt-authentication-api/blob/master/Helpers/JwtMiddleware.cs */
        public async Task Invoke(
            HttpContext context,
            IAuthService authService,
            IUserRepository userRepository,
            IConfiguration configuration
        ) {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token == null)
            {
                await next(context);
            }

            JwtSecurityToken jwtToken;
            try {
                jwtToken = authService.GetValidToken(token);
                var userId = long.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                var user = userRepository.GetOne(userId);
                context.Items["AppUser"] = user;
                await next(context);
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}