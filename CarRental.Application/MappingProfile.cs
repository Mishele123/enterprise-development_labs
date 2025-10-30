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
        CreateMap<CarModel, CarModelDto>()
            .ConstructUsing(src => new CarModelDto(
                src.Id,
                src.Name,
                src.DriveType,
                src.SeatCount,
                src.BodyType,
                src.VehicleClass
            ));

        CreateMap<CarModelsCreateDto, CarModel>();
        CreateMap<CarModelsUpdateDto, CarModel>();

        CreateMap<Car, CarsDto>()
            .ConstructUsing(src => new CarsDto(
                src.Id,
                src.Generation.Id,
                src.Generation.Model.Id,
                src.LicensePlate,
                src.Colour
            ));

        CreateMap<CarsCreateDto, Car>();
        CreateMap<CarsUpdateDto, Car>();

        CreateMap<Client, ClientsDto>()
            .ConstructUsing(src => new ClientsDto(
                src.Id,
                src.DriverLicenseNumber,
                src.FullName,
                src.DateOfBirth
            ));

        CreateMap<ClientsCreateDto, Client>();
        CreateMap<ClientsUpdateDto, Client>();

        CreateMap<ModelGeneration, ModelGenerationsDto>()
            .ConstructUsing(src => new ModelGenerationsDto(
                src.Id,
                src.Year,
                src.EngineVolume,
                src.TransmissionType,
                src.Model.Id,
                src.RentalCostPerHour
            ));

        CreateMap<ModelGenerationsCreateDto, ModelGeneration>();
        CreateMap<ModelGenerationsUpdateDto, ModelGeneration>();

        CreateMap<RentalCar, RentalCarsDto>()
            .ConstructUsing(src => new RentalCarsDto(
                src.Id,
                src.IssueTime,
                src.RentalHours,
                src.RentedCar.Id,
                src.Client.Id
            ));

        CreateMap<RentalCarsCreateDto, RentalCar>();
        CreateMap<RentalCarsUpdateDto, RentalCar>();
    }
}