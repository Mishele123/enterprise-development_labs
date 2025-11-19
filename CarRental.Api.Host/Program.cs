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
using CarRental.EFCore;
using CarRental.EFCore.Repositories;
using CarRental.ServiceDefaults;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

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
    catch (Exception) { }
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
    catch (Exception) { }
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
    catch (Exception) { }
});


builder.Services.AddScoped<ICarRepository, CarsEfCoreRepository>();
builder.Services.AddScoped<ICarModelRepository, CarModelsEfCoreRepository>();
builder.Services.AddScoped<IModelGenerationRepository, ModelGenerationsEfCoreRepository>();
builder.Services.AddScoped<IClientRepository, ClientsEfCoreRepository>();
builder.Services.AddScoped<IRentalCarRepository, RentalCarsEfCoreRepository>();

builder.Services.AddScoped<ICarsService, CarService>();
builder.Services.AddScoped<ICarModelsService, CarModelService>();
builder.Services.AddScoped<IModelGenerationsService, ModelGenerationService>();
builder.Services.AddScoped<IClientsService, ClientService>();
builder.Services.AddScoped<IRentalCarsService, RentalCarService>();
builder.Services.AddScoped<IReportsService, ReportService>();


var cs = builder.Configuration.GetConnectionString("CarRentalDb");
builder.Services.AddDbContext<CarRentalDbContext>(opt =>
{
    opt.UseMySql(cs, ServerVersion.AutoDetect(cs));
});

builder.Services.AddTransient<DbSeederService>();

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<CarRentalDbContext>();
    db.Database.Migrate();
    var seeder = scope.ServiceProvider.GetRequiredService<DbSeederService>();
    seeder.Seed(forceReset: false);

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();