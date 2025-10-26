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
    ICarRepository CarRepo,
    IModelGenerationRepository ModelGenerationRepo,
    IMapper mapper
) : ICars
{
    /// <summary>
    /// return all Cars
    /// </summary>
    /// <returns>sequence of</returns>
    public IEnumerable<CarsDto>? ReadAll() => CarRepo.ReadAll().Select(mapper.Map<CarsDto>);

    /// <summary>
    /// return single Car by id
    /// </summary>
    /// <param name="id">Car id</param>
    /// <returns>Car</returns>
    public CarsDto? Read(int Id)
    {
        var car = CarRepo.Read(Id)
            ?? throw new InvalidOperationException($"Car with ID: {Id} not found");
        return mapper.Map<CarsDto>(car);
    }

    /// <summary>
    /// create new Car
    /// </summary>
    /// <param name="model">Car data to create</param>
    /// <returns>Created dto</returns>
    public CarsDto Create(CarsCreateDto modelDto)
    {
        var generation = ModelGenerationRepo.Read(modelDto.GenerationId)
            ?? throw new InvalidOperationException($"generation with id: {modelDto.GenerationId} not found");
        var newCar = mapper.Map<Car>(modelDto);
        newCar.Generation = generation;
        CarRepo.Create(newCar);
        return mapper.Map<CarsDto>(newCar);
    }

    /// <summary>
    /// update an existing Car
    /// </summary>
    /// <param name="id">Car id</param>
    /// <param name="model">updated Car data</param>
    public bool Update(int id, CarsUpdateDto modelDto)
    {
        var existingCar = CarRepo.Read(id);
        if (existingCar is null) return false;
        mapper.Map(modelDto, existingCar);

        return CarRepo.Update(existingCar);
    }

    /// <summary>
    /// delete Car by its id 
    /// </summary>
    /// <param name="id">Car id</param>
    public bool Delete(int id) => CarRepo.Delete(id);
}