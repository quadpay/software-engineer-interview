using Microsoft.EntityFrameworkCore;
using Zip.Installements.Infrastructure.Context;
using Zip.InstallmentsService.Interface;
using Zip.InstallmentsService.Service;
using MediatR;

namespace Zip.Installement.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Register mediatR service for command classes
            builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            var serviceAssemble = AppDomain.CurrentDomain.Load("Zip.Installements.Command");
            builder.Services.AddMediatR(serviceAssemble);

            //Register mediatR service for query classes
            var serviceAssembleQuery = AppDomain.CurrentDomain.Load("Zip.Installements.Query");
            builder.Services.AddMediatR(serviceAssembleQuery);

            //Code for api versioning
            builder.Services.AddApiVersioning(opt =>
            {
                //Code to setup api versioning
                opt.ReportApiVersions = true;
                opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
            });

            //Code to fix the swagger while using multiple version of api
            //Install package Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer
            builder.Services.AddVersionedApiExplorer(opt =>
            {
                opt.GroupNameFormat = "'v'VVV";
                opt.SubstituteApiVersionInUrl = true;
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ZipPayContext>(option => option.UseInMemoryDatabase("TestDb"));
            builder.Services.AddTransient<IPaymentInstallementPlan, PaymentInstallementPlan>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}