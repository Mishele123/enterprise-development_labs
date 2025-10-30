using AutoMapper;
using CarRental.Application;
using CarRental.Application.Contracts.CarModels;
using CarRental.Application.Contracts.Cars;
using CarRental.Application.Contracts.Clients;
using CarRental.Application.Contracts.ModelGenerations;
using CarRental.Application.Contracts.RentalCars;
using CarRental.Application.Contracts.Reports;
using CarRental.Application.Services;
using CarRental.Domain.Interfaces;
using CarRental.InMemory;
using CarRental.InMemory.Seed;
using Microsoft.OpenApi.Models;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

var mapperConfig = new MapperConfiguration(
    config => config.AddProfile(new MappingProfile()),
    LoggerFactory.Create(builder => builder.AddConsole()));

IMapper? mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CarRental API",
        Version = "v1",
    });
    
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
    try
    {
        var applicationAssembly = typeof(CarService).Assembly;
        var applicationXmlFile = $"{applicationAssembly.GetName().Name}.xml";
        var applicationXmlPath = Path.Combine(AppContext.BaseDirectory, applicationXmlFile);
        if (File.Exists(applicationXmlPath))
        {
            c.IncludeXmlComments(applicationXmlPath);
        }
    }
    catch (Exception) {}
    try
    {
        var contractsAssembly = typeof(CarsCreateDto).Assembly;
        var contractsXmlFile = $"{contractsAssembly.GetName().Name}.xml";
        var contractsXmlPath = Path.Combine(AppContext.BaseDirectory, contractsXmlFile);
        if (File.Exists(contractsXmlPath))
        {
            c.IncludeXmlComments(contractsXmlPath);
        }
    }
    catch (Exception) {}
    try
    {
        var domainAssembly = typeof(ICarRepository).Assembly;
        var domainXmlFile = $"{domainAssembly.GetName().Name}.xml";
        var domainXmlPath = Path.Combine(AppContext.BaseDirectory, domainXmlFile);
        if (File.Exists(domainXmlPath))
        {
            c.IncludeXmlComments(domainXmlPath);
        }
    }
    catch (Exception) {}
});

builder.Services.AddSingleton<InMemoryData>();

builder.Services.AddScoped<ICarRepository, CarsInMemory>();
builder.Services.AddScoped<ICarModelRepository, CarModelsInMemory>();
builder.Services.AddScoped<IModelGenerationRepository, ModelGenerationsInMemory>();
builder.Services.AddScoped<IClientRepository, ClientsInMemory>();
builder.Services.AddScoped<IRentalCarRepository, RentalCarsInMemory>();

builder.Services.AddScoped<ICarsService, CarService>();
builder.Services.AddScoped<ICarModelsService, CarModelService>();
builder.Services.AddScoped<IModelGenerationsService, ModelGenerationService>();
builder.Services.AddScoped<IClientsService, ClientService>();
builder.Services.AddScoped<IRentalCarsService, RentalCarService>();
builder.Services.AddScoped<IReportsService, ReportService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();