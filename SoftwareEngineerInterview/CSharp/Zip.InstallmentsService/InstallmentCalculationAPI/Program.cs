using InstallmentCalculationAPI.BusinessLogic;
using InstallmentCalculationAPI.Interface;
using InstallmentCalculationAPI.Log;
using InstallmentCalculationAPI.Repository.RepositoryCoreLogic;
using InstallmentCalculationAPI.Repository.RepositoryInterface;
using NLog;
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
var connectionString = builder.Configuration.GetConnectionString("ConStr");

var app = builder.Build();

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
