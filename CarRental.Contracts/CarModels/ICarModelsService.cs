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
    public IEnumerable<CarModelDto> ReadAll();
    
    /// <summary>
    /// return single CarModel by id
    /// </summary>
    /// <param name="id">CarModel id</param>
    /// <returns>CarModel</returns>
    public CarModelDto? Read(int id);

    /// <summary>
    /// create new CarModel
    /// </summary>
    /// <param name="modelDto">CarModel data to create</param>
    /// <returns>Created dto</returns>
    public CarModelDto Create(CarModelsCreateDto modelDto);

    /// <summary>
    /// update an existing CarModel
    /// </summary>
    /// <param name="id">CarModel id</param>
    /// <param name="modelDto">updated CarModel data</param>
    public bool Update(int id, CarModelsUpdateDto modelDto);
    
    /// <summary>
    /// delete CarModel by its id 
    /// </summary>
    /// <param name="id">CarModel id</param>
    public bool Delete(int id);
}