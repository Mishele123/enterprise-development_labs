namespace CarRental.Application.Contracts.Cars;

/// <summary>
/// Application service that provide CRUD operations for Cars
/// </summary>
public interface ICars
{
    /// <summary>
    /// return all Cars
    /// </summary>
    /// <returns>sequence of</returns>
    public IEnumerable<CarsDto>? ReadAll();

    /// <summary>
    /// return single Car by id
    /// </summary>
    /// <param name="id">Car id</param>
    /// <returns>Car</returns>
    public CarsDto? Read(int id);

    /// <summary>
    /// create new Car
    /// </summary>
    /// <param name="model">Car data to create</param>
    /// <returns>Created dto</returns>
    public CarsDto Create(CarsDto model);

    /// <summary>
    /// update an existing Car
    /// </summary>
    /// <param name="id">Car id</param>
    /// <param name="model">updated Car data</param>
    public void Update(int id, CarsDto model);

    /// <summary>
    /// delete Car by its id 
    /// </summary>
    /// <param name="id">Car id</param>
    public void Delete(int id);
}