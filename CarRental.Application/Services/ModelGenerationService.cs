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
    /// Return all ModelGenerations asynchronously
    /// </summary>
    /// <returns>sequence of ModelGenerationsDto</returns>
    public async Task<IEnumerable<ModelGenerationsDto>> ReadAllAsync()
    {
        var modelGenerations = await ModelGenerationRepo.ReadAllAsync();
        return modelGenerations.Select(mapper.Map<ModelGenerationsDto>);
    }

    /// <summary>
    /// Return single ModelGeneration by id asynchronously
    /// </summary>
    /// <param name="id">ModelGeneration id</param>
    /// <returns>ModelGenerationsDto</returns>
    public async Task<ModelGenerationsDto?> ReadAsync(int id)
    {
        var modelGeneration = await ModelGenerationRepo.ReadAsync(id);
        return modelGeneration is null ? null : mapper.Map<ModelGenerationsDto>(modelGeneration);
    }

    /// <summary>
    /// Create new ModelGeneration asynchronously
    /// </summary>
    /// <param name="modelDto">ModelGeneration data to create</param>
    /// <returns>Created dto</returns>
    public async Task<ModelGenerationsDto> CreateAsync(ModelGenerationsCreateDto modelDto)
    {
        var carModel = await CarModelRepo.ReadAsync(modelDto.ModelId)
            ?? throw new InvalidOperationException($"car model with id: {modelDto.ModelId} not found");

        var newModelGeneration = mapper.Map<ModelGeneration>(modelDto);
        newModelGeneration.Model = carModel;
        await ModelGenerationRepo.CreateAsync(newModelGeneration);
        return mapper.Map<ModelGenerationsDto>(newModelGeneration);
    }

    /// <summary>
    /// Update an existing ModelGeneration asynchronously
    /// </summary>
    /// <param name="id">ModelGeneration id</param>
    /// <param name="modelDto">updated ModelGeneration data</param>
    public async Task<bool> UpdateAsync(int id, ModelGenerationsUpdateDto modelDto)
    {
        var existingModelGeneration = await ModelGenerationRepo.ReadAsync(id);
        if (existingModelGeneration is null) return false;

        mapper.Map(modelDto, existingModelGeneration);
        return await ModelGenerationRepo.UpdateAsync(existingModelGeneration);
    }

    /// <summary>
    /// Delete ModelGeneration by its id asynchronously
    /// </summary>
    /// <param name="id">ModelGeneration id</param>
    public async Task<bool> DeleteAsync(int id)
    {
        var existingModelGeneration = await ModelGenerationRepo.ReadAsync(id);
        if (existingModelGeneration is null) return false;

        return await ModelGenerationRepo.DeleteAsync(id);
    }
}