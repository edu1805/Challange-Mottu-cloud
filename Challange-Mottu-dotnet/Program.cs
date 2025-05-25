using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Cp2WebApplication.Infrastructure.Context;
using Cp2WebApplication.Domain.Entities;
using Cp2WebApplication.Infrastructure.Repositories;
using Cp2WebApplication.Infrastructure.Mappings;
using System.Reflection;


namespace Cp2WebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = builder.Configuration["Swagger:Title"] ?? "MotoMap - API",
                    Version = "v1",
                    Description =
                    "API para gerenciamento de motos no pátio da mottu - " + DateTime.Now.Year + "<br/><br/>" +
                    "Integrantes:<br/>" +
                    "- Eduardo Barriviera (RM555309) - https://github.com/edu1805<br/>" +
                    "- Thiago Freitas (RM556795) - https://github.com/thiglfa<br/>" +
                    "- Bruno Centurion Fernandes (RM556531) - https://github.com/brunocenturion"
                });

                // Caminho do XML gerado para doc
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swagger.IncludeXmlComments(xmlPath);

                // Permite usar [SwaggerOperation], [SwaggerResponse], etc.
                swagger.EnableAnnotations();
            });

            // Banco de dados Oracle
            builder.Services.AddDbContext<Cp2Context>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
            });

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            // injeção de repositório
            builder.Services.AddScoped<IRepository<Moto>, Repository<Moto>>();
            builder.Services.AddScoped<IRepository<Moto>, Repository<Moto>>();
            builder.Services.AddScoped<ILocalizacaoAtualRepository, LocalizacaoAtualRepository>();

            builder.WebHost.UseUrls("http://0.0.0.0:5000");

            var app = builder.Build();

            
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MotoMap API v1");
                c.RoutePrefix = "swagger"; // Força o caminho /swagger
                c.DocumentTitle = "MotoMap - API Documentation";
            });


            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
