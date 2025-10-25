using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.InMemory.Seed;
namespace CarRental.InMemory;

/// <summary>
/// implementaion IModelGeneration Repository
/// </summary>
public class ModelGenerationInMemory(InMemoryData seed) : IModelGenerationRepository
{
    /// <summary>
    /// create entity
    /// </summary>
    /// <param name="entity">ModelGeneration entity</param>
    public void Create(ModelGeneration entity)
    {
        if (entity.Id == 0)
        {
            entity.Id = seed.Generations.Count > 0 ? seed.Generations.Max(cm => cm.Id) + 1 : 1;
        }
        seed.Generations.Add(entity);
    }

    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public void Update(ModelGeneration entity)
    {
        var idx = seed.Generations.FindIndex(x => x.Id == entity.Id);
        if (idx < 0) return;
        seed.Generations[idx] = entity;
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
    public void Delete(int id)
    {
        var deletableEntity = Read(id);
        if (deletableEntity != null)
        {
            seed.Generations.Remove(deletableEntity);
        }
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