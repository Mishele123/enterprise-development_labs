namespace CarRental.Application.Contracts.Cars;

/// <summary>
/// Application service that provide CRUD operations for Cars
/// </summary>
public interface ICarsService
{
    /// <summary>
    /// return all Cars
    /// </summary>
    /// <returns>sequence of</returns>
    public Task<IEnumerable<CarsDto>> ReadAllAsync();

    /// <summary>
    /// return single Car by id
    /// </summary>
    /// <param name="id">Car id</param>
    /// <returns>Car</returns>
    public Task<CarsDto?> ReadAsync(int id);

    /// <summary>
    /// create new Car
    /// </summary>
    /// <param name="modelDto">Car data to create</param>
    /// <returns>Created dto</returns>
    public Task<CarsDto> CreateAsync(CarsCreateDto modelDto);

    /// <summary>
    /// update an existing Car
    /// </summary>
    /// <param name="id">Car id</param>
    /// <param name="modelDto">updated Car data</param>
    public Task<bool> UpdateAsync(int id, CarsUpdateDto modelDto);

    /// <summary>
    /// delete Car by its id 
    /// </summary>
    /// <param name="id">Car id</param>
    public Task<bool> DeleteAsync(int id);
}