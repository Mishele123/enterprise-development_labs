using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.InMemory.Seed;
namespace CarRental.InMemory;

/// <summary>
/// implementaion IClient Repository
/// </summary>
public class ClientsInMemory(InMemoryData seed) : IClientRepository
{
    /// <summary>
    /// create entity
    /// </summary>
    /// <param name="entity">Client entity</param>
    public Client Create(Client entity)
    {
        if (entity.Id == 0)
        {
            entity.Id = seed.Clients.Count > 0 ? seed.Clients.Max(cm => cm.Id) + 1 : 1;
        }
        seed.Clients.Add(entity);
        return entity;
    }

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public bool Update(Client entity)
    {
        var idx = seed.Clients.FindIndex(x => x.Id == entity.Id);
        if (idx < 0) return false;
        seed.Clients[idx] = entity;
        return true;
    }

    /// <summary>
    /// read entity by id
    /// </summary>
    /// <param name="Id">entity id</param>
    /// <returns></returns>
    public Client? Read(int Id)
    {
        return seed.Clients.FirstOrDefault(cm => cm.Id == Id);
    }

    /// <summary>
    /// delete entity by id
    /// </summary>
    /// <param name="entity">the entity index what will be deleted</param>
    public bool Delete(int id)
    {
        var deletableEntity = Read(id);
        if (deletableEntity != null)
        {
            seed.Clients.Remove(deletableEntity);
            return true;
        }
        return false;
    }

    /// <summary>
    /// read all
    /// </summary>
    /// <returns>return all entities</returns>
    public IEnumerable<Client> ReadAll()
    {
        return [.. seed.Clients];
    }
}