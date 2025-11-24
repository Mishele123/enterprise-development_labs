using AutoMapper;
using CarRental.Application.Contracts.Cars;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;

namespace CarRental.Application.Services;

/// <summary>
/// Crud client operations
/// </summary>
/// <param name="CarRepo"></param>
/// <param name="ModelGenerationRepo"></param>
/// <param name="mapper"></param>
public class CarService(
    ICarRepository CarRepo,
    IModelGenerationRepository ModelGenerationRepo,
    IMapper mapper
) : ICarsService
{
    /// <summary>
    /// Return all Cars asynchronously
    /// </summary>
    /// <returns>sequence of CarsDto</returns>
    public async Task<IEnumerable<CarsDto>> ReadAllAsync()
    {
        var cars = await CarRepo.ReadAllAsync();
        return cars.Select(mapper.Map<CarsDto>);
    }

    /// <summary>
    /// Return single Car by id asynchronously
    /// </summary>
    /// <param name="id">Car id</param>
    /// <returns>CarDto</returns>
    public async Task<CarsDto?> ReadAsync(int id)
    {
        var car = await CarRepo.ReadAsync(id);
        return car is null ? null : mapper.Map<CarsDto>(car);
    }

    /// <summary>
    /// Create new Car asynchronously
    /// </summary>
    /// <param name="modelDto">Car data to create</param>
    /// <returns>Created dto</returns>
    public async Task<CarsDto> CreateAsync(CarsCreateDto modelDto)
    {
        var generation = await ModelGenerationRepo.ReadAsync(modelDto.GenerationId)
            ?? throw new InvalidOperationException($"generation with id: {modelDto.GenerationId} not found");

        var newCar = mapper.Map<Car>(modelDto);
        newCar.Generation = generation;
        await CarRepo.CreateAsync(newCar);
        return mapper.Map<CarsDto>(newCar);
    }

    /// <summary>
    /// Update an existing Car asynchronously
    /// </summary>
    /// <param name="id">Car id</param>
    /// <param name="modelDto">updated Car data</param>
    public async Task<bool> UpdateAsync(int id, CarsUpdateDto modelDto)
    {
        var existingCar = await CarRepo.ReadAsync(id);
        if (existingCar is null) return false;

        mapper.Map(modelDto, existingCar);
        return await CarRepo.UpdateAsync(existingCar);
    }

    /// <summary>
    /// Delete Car by its id asynchronously
    /// </summary>
    /// <param name="id">Car id</param>
    public async Task<bool> DeleteAsync(int id)
    {
        var existingCar = await CarRepo.ReadAsync(id);
        if (existingCar is null) return false;

        return await CarRepo.DeleteAsync(id);
    }
}