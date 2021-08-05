using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using DataAccess.Repositories;
using Domain.Auth;
using Domain.SeedWork;
using Domain.User;

namespace Application.UseCases.AuthUseCases
{
    public class LoginUseCase : AbstractUseCase<string, LoginCommand>, ILoginUseCase
    {
        private readonly IAuthService _authService;

        public LoginUseCase(IAuthService authService)
        {
            _authService = authService;
        }

        public override async Task<UseCaseResult<string>> Work(LoginCommand command)
        {
            var (email, password, IsAnonymus) = command;
            var identity = IsAnonymus switch
            {
                true => await _authService.GetIdentity(email, password),
                false => await _authService.GetAnonymousIdentity(email)
            };
            if (identity == null)
                return Result.Ok(command.EMail, "Доступ закрыт");

            var jwtToken = _authService.AssignJwtSecurityToken(identity);
            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return Result.Ok(token, command.Password);
        }
    }
}