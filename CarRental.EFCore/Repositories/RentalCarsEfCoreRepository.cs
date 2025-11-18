using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.EFCore.Repositories;

public class RentalCarsEfCoreRepository(CarRentalDbContext db) : IRentalCarRepository
{
    /// <summary>
    /// create entity
    /// </summary>
    /// <param name="entity">RentalCar entity</param>
    public RentalCar Create(RentalCar entity)
    {
        db.Rentals.Add(entity);
        db.SaveChanges();
        return entity;
    }

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public bool Update(RentalCar entity)
    {
        if (!db.Rentals.Any(r => r.Id == entity.Id)) return false;
        db.Rentals.Update(entity);
        db.SaveChanges();
        return true;
    }

    /// <summary>
    /// read entity by id
    /// </summary>
    /// <param name="Id">entity id</param>
    /// <returns></returns>
    public RentalCar? Read(int Id)
    {
        return db.Rentals.Find(Id);
    }

    /// <summary>
    /// delete entity by id
    /// </summary>
    /// <param name="entity">the entity index what will be deleted</param>
    public bool Delete(int id)
    {
        var entity = db.Rentals.Find(id);
        if (entity is null) return false;
        db.Rentals.Remove(entity);
        db.SaveChanges();
        return true;
    }

    /// <summary>
    /// read all
    /// </summary>
    /// <returns>return all entities</returns>
    public IEnumerable<RentalCar> ReadAll()
    {
        return [.. db.Rentals.Include(r => r.RentedCar)
            .ThenInclude(c => c.Generation)
            .ThenInclude(g => g.Model)
            .Include(r => r.Client)];
    }
}
