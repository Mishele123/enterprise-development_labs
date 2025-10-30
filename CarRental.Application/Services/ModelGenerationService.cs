using AutoMapper;
using CarRental.Application.Contracts.ModelGenerations;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;

namespace CarRental.Application.Services;

/// <summary>
/// Crud model generation operations
/// </summary>
/// <param name="ModelGenerationRepo"></param>
/// <param name="CarModelRepo"></param>
/// <param name="mapper"></param>
public class ModelGenerationService(
    IModelGenerationRepository ModelGenerationRepo,
    ICarModelRepository CarModelRepo,
    IMapper mapper
) : IModelGenerationsService
{
    /// <summary>
    /// Return all ModelGenerations
    /// </summary>
    /// <returns>sequence of</returns>
    public IEnumerable<ModelGenerationsDto> ReadAll() => ModelGenerationRepo.ReadAll().Select(mapper.Map<ModelGenerationsDto>);

    /// <summary>
    /// Return single ModelGeneration by id
    /// </summary>
    /// <param name="id">ModelGeneration id</param>
    /// <returns>ModelGeneration</returns>
    public ModelGenerationsDto? Read(int id)
    {
        var modelGeneration = ModelGenerationRepo.Read(id);
        return modelGeneration is null ? null : mapper.Map<ModelGenerationsDto>(modelGeneration);
    }

    /// <summary>
    /// Create new ModelGeneration
    /// </summary>
    /// <param name="modelDto">ModelGeneration data to create</param>
    /// <returns>Created dto</returns>
    public ModelGenerationsDto Create(ModelGenerationsCreateDto modelDto)
    {
        var carModel = CarModelRepo.Read(modelDto.ModelId)
            ?? throw new InvalidOperationException($"car model with id: {modelDto.ModelId} not found");
        var newModelGeneration = mapper.Map<ModelGeneration>(modelDto);
        newModelGeneration.Model = carModel;
        ModelGenerationRepo.Create(newModelGeneration);
        return mapper.Map<ModelGenerationsDto>(newModelGeneration);
    }

    /// <summary>
    /// Update an existing ModelGeneration
    /// </summary>
    /// <param name="id">ModelGeneration id</param>
    /// <param name="modelDto">updated ModelGeneration data</param>
    public bool Update(int id, ModelGenerationsUpdateDto modelDto)
    {
        var existingModelGeneration = ModelGenerationRepo.Read(id);
        if (existingModelGeneration is null) return false;
        mapper.Map(modelDto, existingModelGeneration);

        return ModelGenerationRepo.Update(existingModelGeneration);
    }

    /// <summary>
    /// Delete ModelGeneration by its id 
    /// </summary>
    /// <param name="id">ModelGeneration id</param>
    public bool Delete(int id)
    {
        var existingModelGeneration = ModelGenerationRepo.Read(id);
        if (existingModelGeneration is null) return false;
        return ModelGenerationRepo.Delete(id);
    }
}