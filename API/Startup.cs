using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UseCases.ToDoUseCases;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using DataAccess;
using DataAccess.Repositories;
using Domain.ToDo.Port;
using Domain.ToDo.UseCases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


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
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowSpecificOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader();

                    });
            });

            // services.AddResponseCaching();
            services.AddControllers();
            
            services.AddDbContext<DataAccess.DatabaseContext>(opt => opt.UseInMemoryDatabase("ToDoList"));
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "API", Version = "v1"}); });
            services.AddTransient<IToDoRepository, ToDoRepositories>();
            services.AddTransient<IAddToDoUseCase, AddToDoUseCase>();
            services.AddTransient<IDeleteToDoUseCase, DeleteToDoUseCase>();
            services.AddTransient<IGetToDoUseCase, GetToDoUseCase>();
            services.AddTransient<IGetToDoListUseCase, GetToDoListUseCase>();
            services.AddTransient<IUpdateToDoUseCase, UpdateToDoUseCase>();
            services.AddTransient<IDoneToDoUseCase, DoneToDoUseCase>();
            
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