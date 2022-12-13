var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var environment = builder.Environment;

//Add serilog to the application
builder.Logging.AddLoggingSetup(configuration);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddCore();
builder.Services.AddInfrastructure(configuration);
builder.Services.AddProblemDetailSetup(environment);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerSetup();
builder.Services.AddApiVersioningSetup();

var app = builder.Build();

app.UseProblemDetails();

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