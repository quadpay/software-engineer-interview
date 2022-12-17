using InstallmentCalculationAPI.BusinessLogic;
using InstallmentCalculationAPI.Interface;
using InstallmentRepository;
using InstallmentRepository.RepositoryCoreLogic;
using InstallmentRepository.RepositoryInterface;
using Zip.InstallmentsService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IInstallmentCalculator, InstallmentCalculator>();
builder.Services.AddScoped<ICommandDataAccess, CommandDataAccess>();
builder.Services.AddScoped<IPaymentPlanFactory, PaymentPlanFactory>();
builder.Services.AddScoped<IGetInstallmentDetails, GetInstallmentDetails>();
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
