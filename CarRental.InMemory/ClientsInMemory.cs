using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Domain.Seed;

namespace CarRental.InMemory;

/// <summary>
/// Implementation of IClient Repository
/// </summary>
public class ClientsInMemory(Seeder seed) : IClientRepository
{
    /// <summary>
    /// Create entity asynchronously
    /// </summary>
    /// <param name="entity">Client entity</param>
    public Task<Client> CreateAsync(Client entity)
    {
        if (entity.Id == 0)
        {
            entity.Id = seed.Clients.Count > 0 ? seed.Clients.Max(cm => cm.Id) + 1 : 1;
        }
        seed.Clients.Add(entity);
        return Task.FromResult(entity);
    }

    /// <summary>
    /// Update entity asynchronously
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public Task<bool> UpdateAsync(Client entity)
    {
        var idx = seed.Clients.FindIndex(x => x.Id == entity.Id);
        if (idx < 0) return Task.FromResult(false);

        seed.Clients[idx] = entity;
        return Task.FromResult(true);
    }

    /// <summary>
    /// Read entity by id asynchronously
    /// </summary>
    /// <param name="id">entity id</param>
    public Task<Client?> ReadAsync(int id)
    {
        var result = seed.Clients.FirstOrDefault(cm => cm.Id == id);
        return Task.FromResult(result);
    }

    /// <summary>
    /// Delete entity by id asynchronously
    /// </summary>
    /// <param name="id">the entity index what will be deleted</param>
    public Task<bool> DeleteAsync(int id)
    {
        var deletableEntity = seed.Clients.FirstOrDefault(cm => cm.Id == id);
        if (deletableEntity != null)
        {
            seed.Clients.Remove(deletableEntity);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    /// <summary>
    /// Read all entities asynchronously
    /// </summary>
    /// <returns>All entities</returns>
    public Task<IEnumerable<Client>> ReadAllAsync()
    {
        return Task.FromResult(seed.Clients.AsEnumerable());
    }
}