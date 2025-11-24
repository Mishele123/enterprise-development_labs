using AutoMapper;
using CarRental.Application.Contracts.CarModels;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;

namespace CarRental.Application.Services;

/// <summary>
/// Crud car models operations
/// </summary>
/// <param name="CarModelsRepo"></param>
/// <param name="mapper"></param>
public class CarModelService(ICarModelRepository CarModelsRepo, IMapper mapper) : ICarModelsService
{
    /// <summary>
    /// return all CarModels asynchronously
    /// </summary>
    /// <returns>sequence of CarModelDto</returns>
    public async Task<IEnumerable<CarModelDto>> ReadAllAsync()
    {
        var carModels = await CarModelsRepo.ReadAllAsync();
        return carModels.Select(mapper.Map<CarModelDto>);
    }

    /// <summary>
    /// return single CarModel by id asynchronously
    /// </summary>
    /// <param name="id">CarModel id</param>
    /// <returns>CarModelDto</returns>
    public async Task<CarModelDto?> ReadAsync(int id)
    {
        var carModel = await CarModelsRepo.ReadAsync(id);
        return carModel is null ? null : mapper.Map<CarModelDto>(carModel);
    }

    /// <summary>
    /// create new CarModel asynchronously
    /// </summary>
    /// <param name="modelDto">CarModel data to create</param>
    /// <returns>Created dto</returns>
    public async Task<CarModelDto> CreateAsync(CarModelsCreateDto modelDto)
    {
        var entity = mapper.Map<CarModel>(modelDto);
        var newCarModel = await CarModelsRepo.CreateAsync(entity);
        return mapper.Map<CarModelDto>(newCarModel);
    }

    /// <summary>
    /// update an existing CarModel asynchronously
    /// </summary>
    /// <param name="id">CarModel id</param>
    /// <param name="modelDto">updated CarModel data</param>
    public async Task<bool> UpdateAsync(int id, CarModelsUpdateDto modelDto)
    {
        var existingModel = await CarModelsRepo.ReadAsync(id);
        if (existingModel is null) return false;

        mapper.Map(modelDto, existingModel);
        return await CarModelsRepo.UpdateAsync(existingModel);
    }

    /// <summary>
    /// delete CarModel by its id asynchronously
    /// </summary>
    /// <param name="id">CarModel id</param>
    public async Task<bool> DeleteAsync(int id)
    {
        var existingModel = await CarModelsRepo.ReadAsync(id);
        if (existingModel is null) return false;

        return await CarModelsRepo.DeleteAsync(id);
    }
}