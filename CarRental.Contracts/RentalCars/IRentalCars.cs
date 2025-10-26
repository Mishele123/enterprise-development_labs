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
    public IEnumerable<RentalCarsDto> ReadAll();

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
    public RentalCarsDto Create(RentalCarsCreateDto model);

    /// <summary>
    /// update an existing RentalCar
    /// </summary>
    /// <param name="id">RentalCar id</param>
    /// <param name="model">updated RentalCar data</param>
    public bool Update(int id, RentalCarsUpdateDto model);

    /// <summary>
    /// delete RentalCar by its id 
    /// </summary>
    /// <param name="id">RentalCar id</param>
    public bool Delete(int id);
}