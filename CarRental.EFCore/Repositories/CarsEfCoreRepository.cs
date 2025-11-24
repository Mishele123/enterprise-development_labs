using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.EFCore.Repositories;

/// <summary>
/// Implementation of ICar Repository
/// </summary>
public class CarsEfCoreRepository(CarRentalDbContext db) : ICarRepository
{
    /// <summary>
    /// Create entity asynchronously
    /// </summary>
    /// <param name="entity">Car entity</param>
    public async Task<Car> CreateAsync(Car entity)
    {
        db.Cars.Add(entity);
        await db.SaveChangesAsync();
        return entity;
    }

    /// <summary>
    /// Update entity asynchronously
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public async Task<bool> UpdateAsync(Car entity)
    {
        var exists = await db.Cars.AnyAsync(c => c.Id == entity.Id);
        if (!exists) return false;

        db.Cars.Update(entity);
        await db.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Read entity by id asynchronously
    /// </summary>
    /// <param name="id">entity id</param>
    public async Task<Car?> ReadAsync(int id)
    {
        return await db.Cars
            .Include(c => c.Generation)
                .ThenInclude(g => g.Model)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    /// <summary>
    /// Delete entity by id asynchronously
    /// </summary>
    /// <param name="id">the entity index what will be deleted</param>
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await db.Cars.FindAsync(id);
        if (entity is null) return false;

        var hasCar = await db.Rentals.AnyAsync(r => r.RentedCar.Id == entity.Id);
        if (hasCar)
        {
            throw new InvalidOperationException(
                $"Cannot delete car '{entity.Id}' because it has in rented table");
        }

        db.Cars.Remove(entity);
        await db.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Read all entities asynchronously
    /// </summary>
    /// <returns>All entities</returns>
    public async Task<IEnumerable<Car>> ReadAllAsync()
    {
        return await db.Cars
            .Include(c => c.Generation)
            .ThenInclude(g => g.Model)
            .ToListAsync();
    }
}