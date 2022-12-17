using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Zip.Installments.DAL.AppContext;
using Zip.Installments.Validations.Controllers;
using Zip.InstallmentsService.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<OrdersDbContext>(x => x.UseInMemoryDatabase("testdb"));
builder.Services.AddServiceExtensions();

builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddFluentValidation(x=> x.RegisterValidatorsFromAssemblyContaining<CreateOrdersValidator>());

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
