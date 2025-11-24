using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Domain.Seed;

namespace CarRental.InMemory;

/// <summary>
/// implementaion ICarModel Repository
/// </summary>
public class CarModelsInMemory(Seeder seed) : ICarModelRepository
{
    /// <summary>
    /// create entity
    /// </summary>
    /// <param name="entity">CarModel entity</param>
    public async Task<CarModel> CreateAsync(CarModel entity)
    {
        if (entity.Id == 0)
        {
            entity.Id = seed.CarModels.Count > 0 ? seed.CarModels.Max(cm => cm.Id) + 1 : 1;
        }
        seed.CarModels.Add(entity);
        return await Task.FromResult(entity);    
    }

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public async Task<bool> UpdateAsync(CarModel entity)
    {
        var idx = seed.CarModels.FindIndex(x => x.Id == entity.Id);
        if (idx < 0) return await Task.FromResult(false);
        seed.CarModels[idx] = entity;
        return await Task.FromResult(true);
    }

    /// <summary>
    /// read entity by id
    /// </summary>
    /// <param name="Id">entity id</param>
    /// <returns></returns>
    public async Task<CarModel?> ReadAsync(int id)
    {
        var result = seed.CarModels.FirstOrDefault(cm => cm.Id == id);
        return await Task.FromResult(result);
    }

    /// <summary>
    /// delete entity by id
    /// </summary>
    /// <param name="entity">the entity index what will be deleted</param>
    public async Task<bool> DeleteAsync(int id)
    {
        var deletableEntity = seed.CarModels.FirstOrDefault(cm => cm.Id == id);
        if (deletableEntity != null)
        {
            seed.CarModels.Remove(deletableEntity);
            return await Task.FromResult(true);
        }
        return await Task.FromResult(false);
    }

    /// <summary>
    /// read all
    /// </summary>
    /// <returns>return all entities</returns>
    public async  Task<IEnumerable<CarModel>> ReadAllAsync()
    {
        return await Task.FromResult(seed.CarModels.AsEnumerable());
    }
}