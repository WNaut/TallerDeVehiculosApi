using ApplicationCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TallerDeVehiculosApi.Extencions
{
    public static class ServicesExtensions
    {
        public static void AddDbContextServices(this IServiceCollection service)
        {
            var sb = new SqlConnectionStringBuilder();
            sb.DataSource = @"DESKTOP-HQ8RCTO";
            sb.InitialCatalog = "Taller";
            sb.IntegratedSecurity = true;


            service.AddDbContext<ApplicationDbCotext>(
                options => options.UseSqlServer(sb.ToString())
                );
                
        }
    }
}
