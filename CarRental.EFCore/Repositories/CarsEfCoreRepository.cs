using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.EFCore.Repositories;

/// <summary>
/// implementaion ICar Repository
/// </summary>
public class CarsEfCoreRepository(CarRentalDbContext db) : ICarRepository
{
    /// <summary>
    /// create entity
    /// </summary>
    /// <param name="entity">Car entity</param>
    public Car Create(Car entity)
    {
        db.Cars.Add(entity);
        db.SaveChanges();
        return entity;
    }

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public bool Update(Car entity)
    {
        if (!db.CarModels.Any(c => c.Id == entity.Id)) return false;
        db.Cars.Update(entity);
        db.SaveChanges();
        return true;
    }

    /// <summary>
    /// read entity by id
    /// </summary>
    /// <param name="Id">entity id</param>
    /// <returns></returns>
    public Car? Read(int Id)
    {
        return db.Cars.Find(Id);
    }

    /// <summary>
    /// delete entity by id
    /// </summary>
    /// <param name="entity">the entity index what will be deleted</param>
    public bool Delete(int id)
    {
        var entity = db.Cars.Find(id);
        if (entity is null) return false;
        var hasCar = db.Rentals.Any(r => r.RentedCar.Id == entity.Id);
        if (hasCar)
        {
            throw new InvalidOperationException(
                $"Cannot delete car '{entity.Id}' because it has in rented table");
        }
        db.Cars.Remove(entity);
        db.SaveChanges();
        return true;
    }

    /// <summary>
    /// read all
    /// </summary>
    /// <returns>return all entities</returns>
    public IEnumerable<Car> ReadAll()
    {
        return [.. db.Cars.Include(c => c.Generation).ThenInclude(g => g.Model)];
    }
}