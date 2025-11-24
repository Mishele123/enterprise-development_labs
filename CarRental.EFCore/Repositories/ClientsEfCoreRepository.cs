using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.EFCore.Repositories;

public class ClientsEfCoreRepository(CarRentalDbContext db) : IClientRepository
{
    /// <summary>
    /// Create entity asynchronously
    /// </summary>
    /// <param name="entity">Client entity</param>
    public async Task<Client> CreateAsync(Client entity)
    {
        db.Clients.Add(entity);
        await db.SaveChangesAsync();
        return entity;
    }

    /// <summary>
    /// Update entity asynchronously
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public async Task<bool> UpdateAsync(Client entity)
    {
        var exists = await db.Clients.AnyAsync(c => c.Id == entity.Id);
        if (!exists) return false;

        db.Clients.Update(entity);
        await db.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Read entity by id asynchronously
    /// </summary>
    /// <param name="id">entity id</param>
    public async Task<Client?> ReadAsync(int id)
    {
        return await db.Clients.FindAsync(id);
    }

    /// <summary>
    /// Delete entity by id asynchronously
    /// </summary>
    /// <param name="id">the entity index what will be deleted</param>
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await db.Clients.FindAsync(id);
        if (entity is null) return false;

        var hasRental = await db.Rentals.AnyAsync(r => r.Client.Id == entity.Id);

        if (hasRental)
        {
            throw new InvalidOperationException(
                $"Cannot delete client '{entity.Id}' because it has in rentals table");
        }

        db.Clients.Remove(entity);
        await db.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Read all entities asynchronously
    /// </summary>
    /// <returns>All entities</returns>
    public async Task<IEnumerable<Client>> ReadAllAsync()
    {
        return await db.Clients.ToListAsync();
    }
}