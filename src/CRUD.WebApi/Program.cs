
using CRUD.WebApi.Data;
using CRUD.WebApi.Repositories;
using Microsoft.OpenApi.Models;

namespace CRUD.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "CRUD Web API",
                        Version = "v1",
                        Description = "A simple CRUD Web API using Dapper and SQL Server"
                    });
            });

            // Dependency Injection
            #region Dependency Injection

            builder.Services.AddSingleton<DapperContext>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUD Web API v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
