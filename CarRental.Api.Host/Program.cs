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
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarRental API", Version = "v1" });
});

builder.Services.AddSingleton<InMemoryData>();

builder.Services.AddScoped<ICarRepository, CarsInMemory>();
builder.Services.AddScoped<ICarModelRepository, CarModelsInMemory>();
builder.Services.AddScoped<IModelGenerationRepository, ModelGenerationsInMemory>();
builder.Services.AddScoped<IClientRepository, ClientsInMemory>();
builder.Services.AddScoped<IRentalCarRepository, RentalCarsInMemory>();

builder.Services.AddScoped<ICars, CarService>();
builder.Services.AddScoped<ICarModels, CarModelService>();
builder.Services.AddScoped<IModelGenerations, ModelGenerationService>();
builder.Services.AddScoped<IClients, ClientService>();
builder.Services.AddScoped<IRentalCars, RentalCarService>();
builder.Services.AddScoped<IReports, ReportService>();

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