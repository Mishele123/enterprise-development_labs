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
public class CarModelService(ICarModelRepository CarModelsRepo, IMapper mapper) : ICarModels
{
    /// <summary>
    /// return all CarModels
    /// </summary>
    /// <returns>sequence of</returns>
    public IEnumerable<CarModelDto> ReadAll() => CarModelsRepo.ReadAll().Select(mapper.Map<CarModelDto>);

    /// <summary>
    /// return single CarModel by id
    /// </summary>
    /// <param name="id">CarModel id</param>
    /// <returns>CarModel</returns>
    public CarModelDto? Read(int id)
    {
        var carModel = CarModelsRepo.Read(id)
            ?? throw new InvalidOperationException($"Car model with ID: {id}");
        return mapper.Map<CarModelDto>(carModel);
    }

    /// <summary>
    /// create new CarModel
    /// </summary>
    /// <param name="modelDto">CarModel data to create</param>
    /// <returns>Created dto</returns>
    public CarModelDto Create(CarModelsCreateDto modelDto)
    {
        var entity = mapper.Map<CarModel>(modelDto);
        var newCarModel = CarModelsRepo.Create(entity);
        return mapper.Map<CarModelDto>(newCarModel);
    }

    /// <summary>
    /// update an existing CarModel
    /// </summary>
    /// <param name="id">CarModel id</param>
    /// <param name="modelDto">updated CarModel data</param>
    public bool Update(int id, CarModelsUpdateDto modelDto)
    {
        var existingModel = CarModelsRepo.Read(id);
        if (existingModel is null) return false;
        
        mapper.Map(modelDto, existingModel);
        return CarModelsRepo.Update(existingModel);
    }

    /// <summary>
    /// delete CarModel by its id 
    /// </summary>
    /// <param name="id">CarModel id</param>
    public bool Delete(int id)
    {
        var existingModel = CarModelsRepo.Read(id);
        if (existingModel is null) return false;

        return CarModelsRepo.Delete(id);
    }
}