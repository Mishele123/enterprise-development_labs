using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Domain.Seed;

namespace CarRental.InMemory;

/// <summary>
/// Implementation of ICar Repository
/// </summary>
public class CarsInMemory(Seeder seed) : ICarRepository
{
    /// <summary>
    /// Create entity asynchronously
    /// </summary>
    /// <param name="entity">Car entity</param>
    public Task<Car> CreateAsync(Car entity)
    {
        if (entity.Id == 0)
        {
            entity.Id = seed.Cars.Count > 0 ? seed.Cars.Max(cm => cm.Id) + 1 : 1;
        }
        seed.Cars.Add(entity);
        return Task.FromResult(entity);
    }

    /// <summary>
    /// Update entity asynchronously
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public Task<bool> UpdateAsync(Car entity)
    {
        var idx = seed.Cars.FindIndex(x => x.Id == entity.Id);
        if (idx < 0) return Task.FromResult(false);

        seed.Cars[idx] = entity;
        return Task.FromResult(true);
    }

    /// <summary>
    /// Read entity by id asynchronously
    /// </summary>
    /// <param name="id">entity id</param>
    public Task<Car?> ReadAsync(int id)
    {
        var result = seed.Cars.FirstOrDefault(cm => cm.Id == id);
        return Task.FromResult(result);
    }

    /// <summary>
    /// Delete entity by id asynchronously
    /// </summary>
    /// <param name="id">the entity index what will be deleted</param>
    public Task<bool> DeleteAsync(int id)
    {
        var deletableEntity = seed.Cars.FirstOrDefault(cm => cm.Id == id);
        if (deletableEntity != null)
        {
            seed.Cars.Remove(deletableEntity);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    /// <summary>
    /// Read all entities asynchronously
    /// </summary>
    /// <returns>All entities</returns>
    public Task<IEnumerable<Car>> ReadAllAsync()
    {
        return Task.FromResult(seed.Cars.AsEnumerable());
    }
}