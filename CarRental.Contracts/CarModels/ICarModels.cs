namespace CarRental.Application.Contracts.CarModels;

/// <summary>
/// Application service that provide CRUD operations for CarModels
/// </summary>
public interface ICarModels
{
    /// <summary>
    /// return all CarModels
    /// </summary>
    /// <returns>sequence of</returns>
    public IEnumerable<CarModelDto>? ReadAll();
    
    /// <summary>
    /// return single CarModel by id
    /// </summary>
    /// <param name="id">CarModel id</param>
    /// <returns>CarModel</returns>
    public CarModelDto? Read(int id);

    /// <summary>
    /// create new CarModel
    /// </summary>
    /// <param name="model">CarModel data to create</param>
    /// <returns>Created dto</returns>
    public CarModelDto Create(CarModelDto model);

    /// <summary>
    /// update an existing CarModel
    /// </summary>
    /// <param name="id">CarModel id</param>
    /// <param name="model">updated CarModel data</param>
    public void Update(int id, CarModelDto model);
    
    /// <summary>
    /// delete CarModel by its id 
    /// </summary>
    /// <param name="id">CarModel id</param>
    public void Delete(int id);
}