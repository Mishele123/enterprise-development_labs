namespace CarRental.Application.Contracts.RentalCars;

/// <summary>
/// Apolication service that provide CRUD operations for RentalCars
/// </summary>
public interface IRentalCars
{
    /// <summary>
    /// return all RentalCars
    /// </summary>
    /// <returns>sequence of</returns>
    public IEnumerable<RentalCarsDto>? ReadAll();

    /// <summary>
    /// return single RentalCar by id
    /// </summary>
    /// <param name="id">RentalCar id</param>
    /// <returns>RentalCar</returns>
    public RentalCarsDto? Read(int id);

    /// <summary>
    /// create new RentalCar
    /// </summary>
    /// <param name="model">RentalCar data to create</param>
    /// <returns>Created dto</returns>
    public RentalCarsDto Create(RentalCarsDto model);

    /// <summary>
    /// update an existing RentalCar
    /// </summary>
    /// <param name="id">RentalCar id</param>
    /// <param name="model">updated RentalCar data</param>
    public void Update(int id, RentalCarsDto model);

    /// <summary>
    /// delete RentalCar by its id 
    /// </summary>
    /// <param name="id">RentalCar id</param>
    public void Delete(int id);
}