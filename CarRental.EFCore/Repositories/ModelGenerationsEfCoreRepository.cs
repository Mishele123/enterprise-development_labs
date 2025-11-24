using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.EFCore.Repositories;

public class ModelGenerationsEfCoreRepository(CarRentalDbContext db) : IModelGenerationRepository
{
    /// <summary>
    /// Create entity asynchronously
    /// </summary>
    /// <param name="entity">ModelGeneration entity</param>
    public async Task<ModelGeneration> CreateAsync(ModelGeneration entity)
    {
        db.Generations.Add(entity);
        await db.SaveChangesAsync();
        return entity;
    }

    /// <summary>
    /// Update entity asynchronously
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public async Task<bool> UpdateAsync(ModelGeneration entity)
    {
        var exists = await db.Generations.AnyAsync(mg => mg.Id == entity.Id);
        if (!exists) return false;

        db.Generations.Update(entity);
        await db.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Read entity by id asynchronously
    /// </summary>
    /// <param name="id">entity id</param>
    public async Task<ModelGeneration?> ReadAsync(int id)
    {
        return await db.Generations
            .Include(g => g.Model)
            .FirstOrDefaultAsync(g => g.Id == id);
    }

    /// <summary>
    /// Delete entity by id asynchronously
    /// </summary>
    /// <param name="id">the entity index what will be deleted</param>
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await db.Generations.FindAsync(id);
        if (entity is null) return false;

        var hasCar = await db.Cars.AnyAsync(c => c.Generation.Id == entity.Id);

        if (hasCar)
        {
            throw new InvalidOperationException(
                $"Cannot delete generation '{entity.Id}' because it has in cars table");
        }

        db.Generations.Remove(entity);
        await db.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Read all entities asynchronously
    /// </summary>
    /// <returns>All entities</returns>
    public async Task<IEnumerable<ModelGeneration>> ReadAllAsync()
    {
        return await db.Generations
            .Include(g => g.Model)
            .ToListAsync();
    }
}