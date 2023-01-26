using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Reflection;
using ZipPayment.API.ExtensionHelpers;
using ZipPayment.API.Middleware;

//Configure serilogger
Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs/ZipPayment.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//use serialog for logging
builder.Host.UseSerilog();

builder.Services.AddControllers(option => {

    //return not acceptable for the the data format not supported by Api
    option.ReturnHttpNotAcceptable = true;

    //option.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
    //option.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
    //option.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
    //option.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status404NotFound));
    //option.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status200OK));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option => 
{
    option.SwaggerDoc("ZipPaymentOpenAPISpecification", new() {
        Title = "ZipPayment API",
        Version = "v1",
    });

    var xmlcommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlcommentFile);
    option.IncludeXmlComments(xmlCommentsFullPath);
});

//add autoMapper for mapping between entities and Domain objects, DTOs
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//add api versioning support
builder.Services.AddApiVersioning(option => {
    option.AssumeDefaultVersionWhenUnspecified = true;
    option.DefaultApiVersion = new ApiVersion(1, 0);
    option.ReportApiVersions = true;
    });

//add business and data services
builder.Services.RegisterDataService(builder.Configuration);
builder.Services.RegisterBusinessServices();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(option => {
        option.SwaggerEndpoint("/swagger/ZipPaymentOpenAPISpecification/swagger.json", "ZipPayment API");
        option.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseRouting();

//Add Custom exception Handler middleware
app.UseCustomExceptionHandler();

app.UseAuthorization();

app.UseEndpoints(endpoints => {

    endpoints.MapControllers();
});

app.Run();
