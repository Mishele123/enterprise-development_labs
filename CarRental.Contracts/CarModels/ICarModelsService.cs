namespace CarRental.Application.Contracts.CarModels;

/// <summary>
/// Application service that provide CRUD operations for CarModels
/// </summary>
public interface ICarModelsService
{
    /// <summary>
    /// return all CarModels
    /// </summary>
    /// <returns>sequence of</returns>
    public Task<IEnumerable<CarModelDto>> ReadAllAsync();
    
    /// <summary>
    /// return single CarModel by id
    /// </summary>
    /// <param name="id">CarModel id</param>
    /// <returns>CarModel</returns>
    public Task<CarModelDto?> ReadAsync(int id);

    /// <summary>
    /// create new CarModel
    /// </summary>
    /// <param name="modelDto">CarModel data to create</param>
    /// <returns>Created dto</returns>
    public Task<CarModelDto> CreateAsync(CarModelsCreateDto modelDto);

    /// <summary>
    /// update an existing CarModel
    /// </summary>
    /// <param name="id">CarModel id</param>
    /// <param name="modelDto">updated CarModel data</param>
    public Task<bool> UpdateAsync(int id, CarModelsUpdateDto modelDto);
    
    /// <summary>
    /// delete CarModel by its id 
    /// </summary>
    /// <param name="id">CarModel id</param>
    public Task<bool> DeleteAsync(int id);
}