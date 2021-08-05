using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.UseCases.AuthUseCases
{
    public interface IAuthService
    {
        public Task<ClaimsIdentity> GetIdentity(string email, string password);
        public Task<ClaimsIdentity> GetAnonymousIdentity(string email);
        public JwtSecurityToken AssignJwtSecurityToken(ClaimsIdentity identity);
        //public bool VerifyPassword(string password, string hashedPassword);
        //public string EncryptPassword(string password);
    }
}