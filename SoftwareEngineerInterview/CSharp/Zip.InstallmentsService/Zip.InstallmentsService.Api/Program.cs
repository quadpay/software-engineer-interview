using Microsoft.EntityFrameworkCore;
using Zip.InstallmentsService.Infrastructure.DBContext;
using Zip.InstallmentsService.Infrastructure.Interfaces;
using Zip.InstallmentsService.Infrastructure.Repositories;
using Zip.InstallmentsService.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<PaymentPlanDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PaymentPlanDB"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure();
        });
});
builder.Services.AddTransient<IPaymentPlanRepository, PaymentPlanRepository>();
builder.Services.AddTransient<IPaymentPlanService, PaymentPlanService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
