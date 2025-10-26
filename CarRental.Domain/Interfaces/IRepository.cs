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
    public T Create(T entity);
    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public bool Update(T entity);
    /// <summary>
    /// delete entity by id
    /// </summary>
    /// <param name="entity">the entity index what will be deleted</param>
    public bool Delete(int id);
    /// <summary>
    /// read entity by id
    /// </summary>
    /// <param name="Id">entity id</param>
    /// <returns></returns>
    public T? Read(int Id);
    /// <summary>
    /// read all
    /// </summary>
    /// <returns>return all entites</returns>
    public IEnumerable<T> ReadAll();
}