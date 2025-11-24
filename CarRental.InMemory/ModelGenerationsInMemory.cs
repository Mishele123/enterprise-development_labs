using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Domain.Seed;

namespace CarRental.InMemory;

/// <summary>
/// Implementation of IModelGeneration Repository
/// </summary>
public class ModelGenerationsInMemory(Seeder seed) : IModelGenerationRepository
{
    /// <summary>
    /// Create entity asynchronously
    /// </summary>
    /// <param name="entity">ModelGeneration entity</param>
    public Task<ModelGeneration> CreateAsync(ModelGeneration entity)
    {
        if (entity.Id == 0)
        {
            entity.Id = seed.Generations.Count > 0 ? seed.Generations.Max(cm => cm.Id) + 1 : 1;
        }
        seed.Generations.Add(entity);
        return Task.FromResult(entity);
    }

    /// <summary>
    /// Update entity asynchronously
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public Task<bool> UpdateAsync(ModelGeneration entity)
    {
        var idx = seed.Generations.FindIndex(x => x.Id == entity.Id);
        if (idx < 0) return Task.FromResult(false);

        seed.Generations[idx] = entity;
        return Task.FromResult(true);
    }

    /// <summary>
    /// Read entity by id asynchronously
    /// </summary>
    /// <param name="id">entity id</param>
    public Task<ModelGeneration?> ReadAsync(int id)
    {
        var result = seed.Generations.FirstOrDefault(cm => cm.Id == id);
        return Task.FromResult(result);
    }

    /// <summary>
    /// Delete entity by id asynchronously
    /// </summary>
    /// <param name="id">the entity index what will be deleted</param>
    public Task<bool> DeleteAsync(int id)
    {
        var deletableEntity = seed.Generations.FirstOrDefault(cm => cm.Id == id);
        if (deletableEntity != null)
        {
            seed.Generations.Remove(deletableEntity);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    /// <summary>
    /// Read all entities asynchronously
    /// </summary>
    /// <returns>All entities</returns>
    public Task<IEnumerable<ModelGeneration>> ReadAllAsync()
    {
        return Task.FromResult(seed.Generations.AsEnumerable());
    }
}