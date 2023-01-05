using InstallmentCalculationAPI.BusinessLogic;
using InstallmentCalculationAPI.Interface;
using InstallmentCalculationAPI.Log;
using InstallmentCalculationAPI.Middleware;
using InstallmentCalculationAPI.Repository.RepositoryCoreLogic;
using InstallmentCalculationAPI.Repository.RepositoryInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using Zip.InstallmentService.DataAccess.Context;
using Zip.InstallmentsService;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(System.String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ILog, LogNLog>();
builder.Services.AddScoped<IInstallmentCalculator, InstallmentCalculator>();
builder.Services.AddScoped<ICommandDataAccess, CommandDataAccess>();
builder.Services.AddScoped<IPaymentPlanFactory, PaymentPlanFactory>();
builder.Services.AddScoped<IQueryDataAccess, QueryDataAccess>();
//Adding versioning to API
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
});
var connectionString = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<PaymentPlanContext>(options=>options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Using middleware for exception handling
app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
public partial class Program { }