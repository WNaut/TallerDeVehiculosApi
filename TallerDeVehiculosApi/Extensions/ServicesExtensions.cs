using ApplicationCore.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag.AspNetCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TallerDeVehiculosApi.Extencions
{
    /// <summary>
    /// Extension methods for the services
    /// </summary>
    public static class ServicesExtensions
    {
        //DbContext Service
        public static void AddDbContextServices(this IServiceCollection service, string connectionString)
        {
            var sb = new SqlConnectionStringBuilder();
            sb.DataSource = @"DESKTOP-HQ8RCTO";
            sb.InitialCatalog = "Taller";
            sb.IntegratedSecurity = true;


            service.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(connectionString)
                );
        }

        //NSwagger service
        public static void AddNSwaggerService(this IApplicationBuilder app, string envName)
        {
            app.UseSwaggerUi3(typeof(Startup).Assembly, settings =>
            {
                settings.SwaggerRoute = "/swagger/v1/swagger.json";
                settings.SwaggerUiRoute = "/swagger";
                settings.GeneratorSettings.Version = "1.0.0";
                settings.GeneratorSettings.Title = "Taller de Vehiculos API";
                settings.GeneratorSettings.Description = "Environment: " + envName;
                settings.GeneratorSettings.IsAspNetCore = true;
                settings.GeneratorSettings.DefaultPropertyNameHandling = NJsonSchema.PropertyNameHandling.CamelCase;
            });
        }
    }
}
