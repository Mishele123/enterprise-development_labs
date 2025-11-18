using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarRental.EFCore.Repositories;

public class ModelGenerationsEfCoreRepository(CarRentalDbContext db) : IModelGenerationRepository
{
    /// <summary>
    /// create entity
    /// </summary>
    /// <param name="entity">ModelGeneration entity</param>
    public ModelGeneration Create(ModelGeneration entity)
    {
        db.Generations.Add(entity);
        db.SaveChanges();
        return entity;
    }

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public bool Update(ModelGeneration entity)
    {
        if (!db.Generations.Any(mg => mg.Id == entity.Id)) return false;
        db.Generations.Update(entity);
        db.SaveChanges();
        return true;
    }

    /// <summary>
    /// read entity by id
    /// </summary>
    /// <param name="Id">entity id</param>
    /// <returns></returns>
    public ModelGeneration? Read(int Id)
    {
        return db.Generations.Find(Id);
    }

    /// <summary>
    /// delete entity by id
    /// </summary>
    /// <param name="entity">the entity index what will be deleted</param>
    public bool Delete(int id)
    {
        var entity = db.Generations.Find(id);
        if (entity is null) return false;

        var hasCar = db.Cars.Any(c => c.Generation.Id == entity.Id);

        if (hasCar)
        {
            throw new InvalidOperationException(
                $"Cannot delete generation '{entity.Id}' because it has in cars table");
        }

        db.Generations.Remove(entity);
        db.SaveChanges();
        return true;
    }

    /// <summary>
    /// read all
    /// </summary>
    /// <returns>return all entities</returns>
    public IEnumerable<ModelGeneration> ReadAll()
    {
        return [.. db.Generations.Include(g => g.Model)];
    }
}
