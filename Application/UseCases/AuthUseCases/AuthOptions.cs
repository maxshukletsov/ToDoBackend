using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Application.UseCases.AuthUseCases
{
    public static class AuthOptions
    {
        public const string Issuer = "DrTrialBackendServer";
        public const string Audience = "DrTrialWebClient";
        public const int Lifetime = 60;

        private const string Key = "mysupersecret_secretkey!123";

        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new(Encoding.ASCII.GetBytes(Key));
    }
}