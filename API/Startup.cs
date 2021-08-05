using Application.UseCases.AuthUseCases;
using Application.UseCases.ToDoUseCases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using DataAccess.Repositories;
using Domain.Auth;
using Domain.ToDo.Port;
using Domain.ToDo.UseCases;
using Domain.User.Port;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


namespace API
{
    public class Startup
    {
        readonly string AllowSpecificOrigins = "_AllowSpecificOrigins";


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //add CORS policy 
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowSpecificOrigins,
                    builder => { builder.AllowAnyOrigin().AllowAnyHeader(); });
            });

            // services.AddResponseCaching();
            services.AddControllers();
            
            // add Auth
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.Issuer,
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.Audience,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                }
            );

            services.AddDbContext<DataAccess.DatabaseContext>(opt => opt.UseInMemoryDatabase("ToDoList"));
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "API", Version = "v1"}); });
            services.AddTransient<IToDoRepository, ToDoRepositories>();
            services.AddTransient<IUserRepository, UserRepositories>();
            services.AddTransient<IAddToDoUseCase, AddToDoUseCase>();
            services.AddTransient<IDeleteToDoUseCase, DeleteToDoUseCase>();
            services.AddTransient<IGetToDoUseCase, GetToDoUseCase>();
            services.AddTransient<IGetToDoListUseCase, GetToDoListUseCase>();
            services.AddTransient<IUpdateToDoUseCase, UpdateToDoUseCase>();
            services.AddTransient<IDoneToDoUseCase, DoneToDoUseCase>();
            services.AddTransient<IRegistrationUseCase, RegistrationUseCase>();
            services.AddTransient<ILoginUseCase, LoginUseCase>();
            services.AddTransient<IAuthService, AuthService>();

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(AllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}