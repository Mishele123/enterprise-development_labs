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
    public void Create(T entity);
    /// <summary>
    /// Update entity
    /// </summary>
    /// <param name="entity">updatable entity</param>
    public void Update(T entity);
    /// <summary>
    /// delete entity
    /// </summary>
    /// <param name="entity">the entity what will be deleted</param>
    public void Delete(T entity);
    /// <summary>
    /// read entity by id
    /// </summary>
    /// <param name="Id">entity id</param>
    /// <returns></returns>
    public T Read(int Id);
    /// <summary>
    /// read all
    /// </summary>
    /// <returns>return all datas</returns>
    public IEnumerable<T> ReadAll();
}