using AutoMapper;
using CarRental.Api.Host;
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

builder.AddMySqlDbContext<CarRentalDbContext>("CarRentalDb");


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
    c.IncludeAllXmlComments(Assembly.GetExecutingAssembly());
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


builder.Services.AddTransient<DbSeederService>();

var app = builder.Build();

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<CarRentalDbContext>();
    await db.Database.MigrateAsync();
    var seeder = scope.ServiceProvider.GetRequiredService<DbSeederService>();
    await seeder.SeedAsync(forceReset: false);
    
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();