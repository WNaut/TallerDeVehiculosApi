using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TallerDeVehiculosApi.Extencions;
using TallerDeVehiculosApi.Helpers;

namespace TallerDeVehiculosApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextServices(Configuration.GetConnectionString("TallerDb"));

            //Repository service
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddMvc(options => 
            {
                options.ReturnHttpNotAcceptable = true;
                //Adding XML support
                options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.AddNSwaggerService(env.EnvironmentName);
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //Adding AutoMapper
            AutoMapperHelper.AddAutomapper();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
