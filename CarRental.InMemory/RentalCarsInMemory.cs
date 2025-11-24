using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Domain.Seed;

namespace CarRental.InMemory;

/// <summary>
/// Implementation of IRentalCar Repository
/// </summary>
public class RentalCarsInMemory(Seeder seed) : IRentalCarRepository
{
    /// <summary>
    /// Create entity asynchronously
    /// </summary>
    /// <param name="entity">RentalCar entity</param>
    public Task<RentalCar> CreateAsync(RentalCar entity)
    {
        if (entity.Id == 0)
        {
            entity.Id = seed.Rentals.Count > 0 ? seed.Rentals.Max(cm => cm.Id) + 1 : 1;
        }
        seed.Rentals.Add(entity);
        return Task.FromResult(entity);
    }

    /// <summary>
    /// Update entity asynchronously
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public Task<bool> UpdateAsync(RentalCar entity)
    {
        var idx = seed.Rentals.FindIndex(x => x.Id == entity.Id);
        if (idx < 0) return Task.FromResult(false);

        seed.Rentals[idx] = entity;
        return Task.FromResult(true);
    }

    /// <summary>
    /// Read entity by id asynchronously
    /// </summary>
    /// <param name="id">entity id</param>
    public Task<RentalCar?> ReadAsync(int id)
    {
        var result = seed.Rentals.FirstOrDefault(cm => cm.Id == id);
        return Task.FromResult(result);
    }

    /// <summary>
    /// Delete entity by id asynchronously
    /// </summary>
    /// <param name="id">the entity index what will be deleted</param>
    public Task<bool> DeleteAsync(int id)
    {
        var deletableEntity = seed.Rentals.FirstOrDefault(cm => cm.Id == id);
        if (deletableEntity != null)
        {
            seed.Rentals.Remove(deletableEntity);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    /// <summary>
    /// Read all entities asynchronously
    /// </summary>
    /// <returns>All entities</returns>
    public Task<IEnumerable<RentalCar>> ReadAllAsync()
    {
        return Task.FromResult(seed.Rentals.AsEnumerable());
    }
}