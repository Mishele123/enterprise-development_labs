using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.InMemory.Seed;
namespace CarRental.InMemory;

/// <summary>
/// implementaion ICarModel Repository
/// </summary>
public class CarModelsInMemory(InMemoryData seed) : ICarModelRepository
{
    /// <summary>
    /// create entity
    /// </summary>
    /// <param name="entity">CarModel entity</param>
    public CarModel Create(CarModel entity)
    {
        if (entity.Id == 0)
        {
            entity.Id = seed.CarModels.Count > 0 ? seed.CarModels.Max(cm => cm.Id) + 1 : 1;
        }
        seed.CarModels.Add(entity);
        return entity;    
    }

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public bool Update(CarModel entity)
    {
        var idx = seed.CarModels.FindIndex(x => x.Id == entity.Id);
        if (idx < 0) return false;
        seed.CarModels[idx] = entity;
        return true;
    }

    /// <summary>
    /// read entity by id
    /// </summary>
    /// <param name="Id">entity id</param>
    /// <returns></returns>
    public CarModel? Read(int Id)
    {
        return seed.CarModels.FirstOrDefault(cm => cm.Id == Id);
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
            seed.CarModels.Remove(deletableEntity);
            return true;
        }
        return false;
    }

    /// <summary>
    /// read all
    /// </summary>
    /// <returns>return all entities</returns>
    public IEnumerable<CarModel>? ReadAll()
    {
        return [.. seed.CarModels];
    }
}