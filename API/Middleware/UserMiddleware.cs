using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain.SeedWork;
using Domain.User.Entity;
using Domain.User.UseCases;
using Microsoft.AspNetCore.Http;

namespace API
{
    public class UserMiddleware
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IGetUserUseCase _getUserUseCase;

        public UserMiddleware(
            IHttpContextAccessor httpContextAccessor,
            IGetUserUseCase getUserUseCase)
        {
            _httpContextAccessor = httpContextAccessor;
            _getUserUseCase = getUserUseCase;
        }

        public async Task<DataTransfer> GetContext(string token = null!)
        {
            return new()
            {
                User = await GetUserFromAuthorizationToken(token),
            };
        }

        public async Task<User> GetUserFromAuthorizationToken(string token = null!)
        {
            var user = (token == null) switch
            {
                true => _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(
                        c => c.Type.Contains("e"))
                    ?.Value,
                false => (new JwtSecurityTokenHandler().ReadToken(token) as JwtSecurityToken)?.Claims.FirstOrDefault(
                        c => c.Type.Equals("email"))
                    ?.Value
            };
            if (user == null) return null;
            
            var getUserResult = await _getUserUseCase.Invoke(new GetUserCommand { EMail = user });
            return getUserResult.Data;
        }
    }
}