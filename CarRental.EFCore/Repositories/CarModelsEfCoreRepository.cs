using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarRental.EFCore.Repositories;

public class CarModelsEfCoreRepository(CarRentalDbContext db) : ICarModelRepository
{
    /// <summary>
    /// create entity
    /// </summary>
    /// <param name="entity">CarModel entity</param>
    public CarModel Create(CarModel entity)
    {
        db.CarModels.Add(entity);
        db.SaveChanges();
        return entity;
    }

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public bool Update(CarModel entity)
    {
        if (!db.CarModels.Any(cm => cm.Id == entity.Id)) return false;
        db.CarModels.Update(entity);
        db.SaveChanges();
        return true;
    }

    /// <summary>
    /// read entity by id
    /// </summary>
    /// <param name="Id">entity id</param>
    /// <returns></returns>
    public CarModel? Read(int Id)
    {
        return db.CarModels.Find(Id);
    }

    /// <summary>
    /// delete entity by id
    /// </summary>
    /// <param name="entity">the entity index what will be deleted</param>
    public bool Delete(int id)
    {
        var entity = db.CarModels.Find(id);
        if (entity is null) return false;
        db.CarModels.Remove(entity);
        db.SaveChanges();
        return true;
    }

    /// <summary>
    /// read all
    /// </summary>
    /// <returns>return all entities</returns>
    public IEnumerable<CarModel> ReadAll()
    {
        return [.. db.CarModels];
    }
}
