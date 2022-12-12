using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zip.InstallmentsService.Data.Interface;
using Zip.InstallmentsService.Data.Models;
using Zip.InstallmentsService.Data.Repository;
using Zip.InstallmentsService.Entity.Dto;
using Zip.InstallmentsService.Core.Implementation;
using Zip.InstallmentsService.Core.Interface;

namespace Zip.InstallmentsService.Service
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
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("PaymentPlan"));
            //services.AddMvc();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Implement Swagger UI",
                    Description = "A simple example to Implement Swagger UI",
                });
            });

            //Logging
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<ApplicationLogs>>();
            services.AddSingleton(typeof(ILogger), logger);

            //services.AddLogging(config =>
            //{
            //    config.AddDebug();
            //    config.AddConsole();
            //});

            services.AddApplicationInsightsTelemetry();

            services.AddScoped<IPaymentPlanProvider, PaymentPlanProvider>();
            services.AddScoped<IPaymentPlanRepository, PaymentPlanRepository>();
            services.AddScoped<IInstallmentProvider, InstallmentProvider>();

            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Showing API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
