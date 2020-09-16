using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanInformationAPI.Models;
using LoanInformationAPI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace LoanInformationAPI
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
            services.AddSwaggerGen(c=>
            {
                c.SwaggerDoc("v1",new OpenApiInfo {Title="LOAN App in Swagger",Version="V1" });
            });
          
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            // Add API Versioning to as service to your project

            services.AddApiVersioning(
                config => {
                    config.DefaultApiVersion = new ApiVersion(1, 0);
                    config.AssumeDefaultVersionWhenUnspecified = true;
                    config.ReportApiVersions = true;
                }
                );
            services.AddScoped<ILoanRepository,LoanDataRepository>();
            services.AddControllers();
            services.AddDbContext<LoanDBContext>(s => s.UseSqlServer("Server = CTSDCLOUDMC95;Database =LoanManagement;User ID = IIHT\\dotnetcloudmc97; Trusted_Connection = Yes; "));
            services.AddLogging();

        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseSwagger();
         
          app.UseRouting();

           app.UseAuthorization();


            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LOAN API V1");

            });

            app.UseApiVersioning();




            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
