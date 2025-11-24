using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.EFCore.Repositories;

public class CarModelsEfCoreRepository(CarRentalDbContext db) : ICarModelRepository
{
    /// <summary>
    /// Create entity asynchronously
    /// </summary>
    /// <param name="entity">CarModel entity</param>
    public async Task<CarModel> CreateAsync(CarModel entity)
    {
        db.CarModels.Add(entity);
        await db.SaveChangesAsync();
        return entity;
    }

    /// <summary>
    /// Update entity asynchronously
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public async Task<bool> UpdateAsync(CarModel entity)
    {
        var exists = await db.CarModels.AnyAsync(cm => cm.Id == entity.Id);
        if (!exists) return false;

        db.CarModels.Update(entity);
        await db.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Read entity by id asynchronously
    /// </summary>
    /// <param name="id">entity id</param>
    public async Task<CarModel?> ReadAsync(int id)
    {
        return await db.CarModels.FindAsync(id);
    }

    /// <summary>
    /// Delete entity by id asynchronously
    /// </summary>
    /// <param name="id">the entity index what will be deleted</param>
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await db.CarModels.FindAsync(id);
        if (entity is null)
            return false;

        var hasModelGeneration = await db.Generations.AnyAsync(g => g.Model.Id == entity.Id);
        if (hasModelGeneration)
        {
            throw new InvalidOperationException(
                $"Cannot delete car model '{entity.Name}' because it has in generations table");
        }

        db.CarModels.Remove(entity);
        await db.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Read all entities asynchronously
    /// </summary>
    /// <returns>All entities</returns>
    public async Task<IEnumerable<CarModel>> ReadAllAsync()
    {
        return await db.CarModels.ToListAsync();
    }
}