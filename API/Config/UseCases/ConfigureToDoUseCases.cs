using Application.UseCases.ToDoUseCases;
using Domain.ToDo.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace API.Config.UseCases
{
    public class ConfigureToDoUseCases
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAddToDoUseCase, AddToDoUseCase>();
            services.AddTransient<IDeleteToDoUseCase, DeleteToDoUseCase>();
            services.AddTransient<IGetToDoUseCase, GetToDoUseCase>();
            services.AddTransient<IGetToDoListUseCase, GetToDoListUseCase>();
            services.AddTransient<IUpdateToDoUseCase, UpdateToDoUseCase>();
            services.AddTransient<IDoneToDoUseCase, DoneToDoUseCase>();
        }
    }
}