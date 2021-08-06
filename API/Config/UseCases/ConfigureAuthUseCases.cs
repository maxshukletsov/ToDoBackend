using Application.UseCases.AuthUseCases;
using Domain.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace API.Config.UseCases
{
    public class ConfigureAuthUseCases
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRegistrationUseCase, RegistrationUseCase>();
            services.AddTransient<ILoginUseCase, LoginUseCase>();
            services.AddTransient<IAuthService, AuthService>();
        }
    }
}