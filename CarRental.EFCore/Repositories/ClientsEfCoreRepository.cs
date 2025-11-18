using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;

namespace CarRental.EFCore.Repositories;

public class ClientsEfCoreRepository(CarRentalDbContext db) : IClientRepository
{
    /// <summary>
    /// create entity
    /// </summary>
    /// <param name="entity">Client entity</param>
    public Client Create(Client entity)
    {
        db.Clients.Add(entity);
        db.SaveChanges();
        return entity;
    }

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public bool Update(Client entity)
    {
        if (!db.Clients.Any(c => c.Id == entity.Id)) return false;
        db.Clients.Update(entity);
        db.SaveChanges();
        return true;
    }

    /// <summary>
    /// read entity by id
    /// </summary>
    /// <param name="Id">entity id</param>
    /// <returns></returns>
    public Client? Read(int Id)
    {
        return db.Clients.Find(Id);
    }

    /// <summary>
    /// delete entity by id
    /// </summary>
    /// <param name="entity">the entity index what will be deleted</param>
    public bool Delete(int id)
    {
        var entity = db.Clients.Find(id);
        if (entity is null) return false;
        db.Clients.Remove(entity);
        db.SaveChanges();
        return true;
    }

    /// <summary>
    /// read all
    /// </summary>
    /// <returns>return all entities</returns>
    public IEnumerable<Client> ReadAll()
    {
        return [.. db.Clients];
    }
}
