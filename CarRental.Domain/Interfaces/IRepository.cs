namespace CarRental.Domain.Interfaces;

/// <summary>
/// Interface for CRUD operations
/// </summary>
/// <typeparam name="T">Entity type</typeparam>
public interface IRepository<T>
{
    /// <summary>
    /// create entity
    /// </summary>
    /// <param name="entity">new entity</param>
    public Task<T> CreateAsync(T entity);
    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public Task<bool> UpdateAsync(T entity);
    /// <summary>
    /// delete entity by id
    /// </summary>
    /// <param name="id">the entity index what will be deleted</param>
    public Task<bool> DeleteAsync(int id);
    /// <summary>
    /// read entity by id
    /// </summary>
    /// <param name="id">entity id</param>
    /// <returns></returns>
    public Task<T?> ReadAsync(int id);
    /// <summary>
    /// read all
    /// </summary>
    /// <returns>return all entites</returns>
    public Task<IEnumerable<T>> ReadAllAsync();
}