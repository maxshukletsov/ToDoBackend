using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Application.UseCases.AuthUseCases
{
    public static class AuthOptions
    {
        public const string Issuer = "ToDoBackendServer";
        public const string Audience = "ToDoWebClient";
        public const int Lifetime = 10;

        private const string Key = "supersecretkeyforsupersecretapp";

        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new(Encoding.ASCII.GetBytes(Key));
    }
}