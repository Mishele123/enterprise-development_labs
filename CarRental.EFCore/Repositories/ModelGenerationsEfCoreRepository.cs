using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;

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
        return [.. db.Generations];
    }
}
