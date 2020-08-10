using System.Security.Cryptography;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Parking.Data.Entities;
using Parking.Data.Models;
using Parking.Core.Helpers;
using Parking.Core.Repositories;

namespace Parking.Api.Services
{
    public interface IAuthService
    {
        UserDetail Register(AppUser user);
        string Login(string email, string password);
        JwtSecurityToken GetValidToken(string token);
        string GenerateJwtToken(AppUser user);
    }
    public class AuthService : IAuthService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public AuthService(
            IUserRepository userRepository,
            IMapper mapper,
            IConfiguration configuration
        )
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public UserDetail Register(AppUser user)
        {
            user.Password = PasswordHelper.Hash(user.Password);

            /* create user and convert to UserDetail */
            var userDetail = this.mapper.Map<UserDetail>(
                this.userRepository.Create(user)
            );

            return userDetail;
        }

        public string Login(string email, string password)
        {
            var user = this.userRepository.FindByEmail(email);
            var isLoginCorrect = PasswordHelper.IsPasswordCorrect(password, user.Password);

            if (isLoginCorrect)
            {
                return this.GenerateJwtToken(user);
            }

            // TODO: vrati gresku
            return null;
        }

        public JwtSecurityToken GetValidToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:JwtKey"]);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(key),
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken)validatedToken;
        }

        public string GenerateJwtToken(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:JwtKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("id", user.Id.ToString()),
                    new Claim("email", user.Email)
                }),
                Expires = DateTime.UtcNow.AddDays(int.Parse(configuration["Jwt:Expires"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}