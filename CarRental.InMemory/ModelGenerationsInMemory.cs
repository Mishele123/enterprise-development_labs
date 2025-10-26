using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.InMemory.Seed;
namespace CarRental.InMemory;

/// <summary>
/// implementaion IModelGeneration Repository
/// </summary>
public class ModelGenerationsInMemory(InMemoryData seed) : IModelGenerationRepository
{
    /// <summary>
    /// create entity
    /// </summary>
    /// <param name="entity">ModelGeneration entity</param>
    public ModelGeneration Create(ModelGeneration entity)
    {
        if (entity.Id == 0)
        {
            entity.Id = seed.Generations.Count > 0 ? seed.Generations.Max(cm => cm.Id) + 1 : 1;
        }
        seed.Generations.Add(entity);
        return entity;
    }

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public bool Update(ModelGeneration entity)
    {
        var idx = seed.Generations.FindIndex(x => x.Id == entity.Id);
        if (idx < 0) return false;
        seed.Generations[idx] = entity;
        return true;
    }

    /// <summary>
    /// read entity by id
    /// </summary>
    /// <param name="Id">entity id</param>
    /// <returns></returns>
    public ModelGeneration? Read(int Id)
    {
        return seed.Generations.FirstOrDefault(cm => cm.Id == Id);
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
            seed.Generations.Remove(deletableEntity);
            return true;
        }
        return false;
    }

    /// <summary>
    /// read all
    /// </summary>
    /// <returns>return all entities</returns>
    public IEnumerable<ModelGeneration>? ReadAll()
    {
        return [.. seed.Generations];
    }
}