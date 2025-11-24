using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.EFCore.Repositories;

public class RentalCarsEfCoreRepository(CarRentalDbContext db) : IRentalCarRepository
{
    /// <summary>
    /// Create entity asynchronously
    /// </summary>
    /// <param name="entity">RentalCar entity</param>
    public async Task<RentalCar> CreateAsync(RentalCar entity)
    {
        db.Rentals.Add(entity);
        await db.SaveChangesAsync();
        return entity;
    }

    /// <summary>
    /// Update entity asynchronously
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public async Task<bool> UpdateAsync(RentalCar entity)
    {
        var exists = await db.Rentals.AnyAsync(r => r.Id == entity.Id);
        if (!exists) return false;

        db.Rentals.Update(entity);
        await db.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Read entity by id asynchronously
    /// </summary>
    /// <param name="id">entity id</param>
    public async Task<RentalCar?> ReadAsync(int id)
    {
        return await db.Rentals
            .Include(r => r.RentedCar)
                .ThenInclude(c => c.Generation)
                .ThenInclude(g => g.Model)
            .Include(r => r.Client)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    /// <summary>
    /// Delete entity by id asynchronously
    /// </summary>
    /// <param name="id">the entity index what will be deleted</param>
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await db.Rentals.FindAsync(id);
        if (entity is null) return false;

        db.Rentals.Remove(entity);
        await db.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Read all entities asynchronously
    /// </summary>
    /// <returns>All entities</returns>
    public async Task<IEnumerable<RentalCar>> ReadAllAsync()
    {
        return await db.Rentals
            .Include(r => r.RentedCar)
                .ThenInclude(c => c.Generation)
                .ThenInclude(g => g.Model)
            .Include(r => r.Client)
            .ToListAsync();
    }
}