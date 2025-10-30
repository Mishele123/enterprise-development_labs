using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.InMemory.Seed;

namespace CarRental.InMemory;


/// <summary>
/// implementaion IRentalCar Repository
/// </summary>
public class RentalCarsInMemory(InMemoryData seed) : IRentalCarRepository
{
    /// <summary>
    /// create entity
    /// </summary>
    /// <param name="entity">RentalCar entity</param>
    public RentalCar Create(RentalCar entity)
    {
        if (entity.Id == 0)
        {
            entity.Id = seed.Rentals.Count > 0 ? seed.Rentals.Max(cm => cm.Id) + 1 : 1;
        }
        seed.Rentals.Add(entity);
        return entity;
    }

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public bool Update(RentalCar entity)
    {
        var idx = seed.Rentals.FindIndex(x => x.Id == entity.Id);
        if (idx < 0) return false;
        seed.Rentals[idx] = entity;
        return true;
    }

    /// <summary>
    /// read entity by id
    /// </summary>
    /// <param name="Id">entity id</param>
    /// <returns></returns>
    public RentalCar? Read(int Id)
    {
        return seed.Rentals.FirstOrDefault(cm => cm.Id == Id);
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
            seed.Rentals.Remove(deletableEntity);
            return true;
        }
        return false;
    }

    /// <summary>
    /// read all
    /// </summary>
    /// <returns>return all entities</returns>
    public IEnumerable<RentalCar> ReadAll()
    {
        return [.. seed.Rentals];
    }
}