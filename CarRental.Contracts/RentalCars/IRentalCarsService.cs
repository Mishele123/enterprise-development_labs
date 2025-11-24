namespace CarRental.Application.Contracts.RentalCars;

/// <summary>
/// Apolication service that provide CRUD operations for RentalCars
/// </summary>
public interface IRentalCarsService
{
    /// <summary>
    /// return all RentalCars
    /// </summary>
    /// <returns>sequence of</returns>
    public Task<IEnumerable<RentalCarsDto>> ReadAllAsync();

    /// <summary>
    /// return single RentalCar by id
    /// </summary>
    /// <param name="id">RentalCar id</param>
    /// <returns>RentalCar</returns>
    public Task<RentalCarsDto?> ReadAsync(int id);

    /// <summary>
    /// create new RentalCar
    /// </summary>
    /// <param name="model">RentalCar data to create</param>
    /// <returns>Created dto</returns>
    public Task<RentalCarsDto> CreateAsync(RentalCarsCreateDto model);

    /// <summary>
    /// update an existing RentalCar
    /// </summary>
    /// <param name="id">RentalCar id</param>
    /// <param name="model">updated RentalCar data</param>
    public Task<bool> UpdateAsync(int id, RentalCarsUpdateDto model);

    /// <summary>
    /// delete RentalCar by its id 
    /// </summary>
    /// <param name="id">RentalCar id</param>
    public Task<bool> DeleteAsync(int id);
}