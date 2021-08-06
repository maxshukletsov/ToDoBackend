using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.User.Port;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.AuthUseCases
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ClaimsIdentity> GetIdentity(string email, string password)
        {
            var user = await _userRepository.Get(email);
            var isIdentified = user != null && VerifyPassword(password, user.Password);
            Console.WriteLine(isIdentified);
            return isIdentified switch
            {
                true => new ClaimsIdentity(
                    new List<Claim> { new("email", user.Email) },
                    "Token",
                    ClaimsIdentity.DefaultNameClaimType,
                    null),
                false => null
            };
        }

        public async Task<ClaimsIdentity> GetAnonymousIdentity(string email)
        {
            var user = await _userRepository.Get(email);

            var claims = new List<Claim>
            {
                new("email", user.Email),
            };

            return new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, null);
        }


        public JwtSecurityToken AssignJwtSecurityToken(ClaimsIdentity identity) => 
            new(
            AuthOptions.Issuer,
            AuthOptions.Audience,
            notBefore: DateTime.Now,
            claims: identity.Claims,
            expires: DateTime.Now.Add(TimeSpan.FromMinutes(AuthOptions.Lifetime)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                SecurityAlgorithms.HmacSha256)
        );

        public string EncryptPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        public bool VerifyPassword(string password, string hashedPassword) =>
            BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}