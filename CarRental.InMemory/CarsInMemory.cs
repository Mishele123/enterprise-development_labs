using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.InMemory.Seed;
namespace CarRental.InMemory;

/// <summary>
/// implementaion ICar Repository
/// </summary>
public class CarsInMemory(InMemoryData seed) : ICarRepository
{
    /// <summary>
    /// create entity
    /// </summary>
    /// <param name="entity">Car entity</param>
    public void Create(Car entity)
    {
        if (entity.Id == 0)
        {
            entity.Id = seed.Cars.Count > 0 ? seed.Cars.Max(cm => cm.Id) + 1 : 1;
        }
        seed.Cars.Add(entity);
    }

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public void Update(Car entity)
    {
        var idx = seed.Cars.FindIndex(x => x.Id == entity.Id);
        if (idx < 0) return;
        seed.Cars[idx] = entity;
    }

    /// <summary>
    /// read entity by id
    /// </summary>
    /// <param name="Id">entity id</param>
    /// <returns></returns>
    public Car? Read(int Id)
    {
        return seed.Cars.FirstOrDefault(cm => cm.Id == Id);
    }

    /// <summary>
    /// delete entity by id
    /// </summary>
    /// <param name="entity">the entity index what will be deleted</param>
    public void Delete(int id)
    {
        var deletableEntity = Read(id);
        if (deletableEntity != null)
        {
            seed.Cars.Remove(deletableEntity);
        }
    }

    /// <summary>
    /// read all
    /// </summary>
    /// <returns>return all entities</returns>
    public IEnumerable<Car>? ReadAll()
    {
        return [.. seed.Cars];
    }
}