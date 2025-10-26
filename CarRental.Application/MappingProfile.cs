using AutoMapper;
using CarRental.Application.Contracts.CarModels;
using CarRental.Application.Contracts.Cars;
using CarRental.Application.Contracts.Clients;
using CarRental.Application.Contracts.ModelGenerations;
using CarRental.Application.Contracts.RentalCars;
using CarRental.Domain.Entities;
namespace CarRental.Application;

/// <summary>
/// Configuration for mapping contracts and domain entities
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CarModel, CarModelDto>();
        CreateMap<CarModelsCreateDto, CarModel>();
        CreateMap<CarModelsUpdateDto, CarModel>();

        CreateMap<Car, CarsDto>();
        CreateMap<CarsCreateDto, Car>();
        CreateMap<CarsUpdateDto, Car>();

        CreateMap<Client, ClientsDto>();
        CreateMap<ClientsCreateDto, Client>();
        CreateMap<ClientsUpdateDto, Client>();

        CreateMap<ModelGeneration, ModelGenerationsDto>();
        CreateMap<ModelGenerationsCreateDto, ModelGeneration>();
        CreateMap<ModelGenerationsUpdateDto, ModelGeneration>();

        CreateMap<RentalCar, RentalCarsDto>();
        CreateMap<RentalCarsCreateDto, RentalCar>();
        CreateMap<RentalCarsUpdateDto,  RentalCar>();
    }
}