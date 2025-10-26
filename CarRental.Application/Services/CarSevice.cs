using AutoMapper;
using CarRental.Application.Contracts.Cars;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
namespace CarRental.Application.Services;

/// <summary>
/// CRUD Car operations 
/// </summary>
/// <param name="repo"></param>
/// <param name="mapper"></param>
public class CarService(
    ICarRepository repo,
    IMapper mapper
) : ICars
{
    public List<CarsDto>? ReadAll()
    {
        var cars = repo.ReadAll();
        return mapper.Map<List<CarsDto>>(cars);
    }
    public CarsDto? Read(int Id)
    {
        var car = repo.Read(Id)
            ?? throw new InvalidOperationException($"Car with ID: {Id} not found");
        return mapper.Map<CarsDto>(car);
    }

    public void Create(CarsDto entityDto)
    {
        var generationId = repo.Read(entityDto.GenerationId)
            ?? throw new InvalidOperationException($"generation with id: {entityDto.GenerationId} not found");
        var modelId = repo.Read(entityDto.ModelId) 
            ?? throw new InvalidOperationException($"model with id: {entityDto.ModelId} not found");
        var newCar = mapper.Map<Car>(entityDto);

    }
}