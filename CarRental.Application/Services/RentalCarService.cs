using AutoMapper;
using CarRental.Application.Contracts.RentalCars;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;

/// <summary>
/// Crud operations for rental car
/// </summary>
/// <param name="RentalCarRepo"></param>
/// <param name="CarRepo"></param>
/// <param name="ClientRepo"></param>
public class RentalCarService(
    IRentalCarRepository RentalCarRepo,
    ICarRepository CarRepo,
    IClientRepository ClientRepo,
    IMapper mapper
) : IRentalCars
{
    /// <summary>
    /// Return all RentalCars
    /// </summary>
    /// <returns>sequence of</returns>
    public IEnumerable<RentalCarsDto> ReadAll() => RentalCarRepo.ReadAll().Select(mapper.Map<RentalCarsDto>);

    /// <summary>
    /// Return single RentalCar by id
    /// </summary>
    /// <param name="id">RentalCar id</param>
    /// <returns>RentalCar</returns>
    public RentalCarsDto? Read(int id)
    {
        var rentalCar = RentalCarRepo.Read(id)
            ?? throw new InvalidOperationException($"rental car with id: {id} not found");
        return mapper.Map<RentalCarsDto>(rentalCar);
    }

    /// <summary>
    /// Create new RentalCar
    /// </summary>
    /// <param name="model">RentalCar data to create</param>
    /// <returns>Created dto</returns>
    public RentalCarsDto Create(RentalCarsCreateDto modelDto)
    {
        var car = CarRepo.Read(modelDto.RentedCarId)
            ?? throw new InvalidOperationException($"car with id: {modelDto.RentedCarId} not found");
        var client = ClientRepo.Read(modelDto.ClientId)
            ?? throw new InvalidOperationException($"client with id: {modelDto.ClientId} not found");
        var newRentalCar = mapper.Map<RentalCar>(modelDto);
        newRentalCar.RentedCar = car;
        newRentalCar.Client = client;
        RentalCarRepo.Create(newRentalCar);
        return mapper.Map<RentalCarsDto>(newRentalCar);
    }

    /// <summary>
    /// Update an existing RentalCar
    /// </summary>
    /// <param name="id">RentalCar id</param>
    /// <param name="model">updated RentalCar data</param>
    public bool Update(int id, RentalCarsUpdateDto modelDto)
    {
        var existingRentalCar = RentalCarRepo.Read(id);
        if (existingRentalCar is null) return false;
        if (modelDto.RentalHours > 0 && CanUpdateRentalDuration(existingRentalCar) 
            && modelDto.RentalHours >= existingRentalCar.RentalHours)
        {
            existingRentalCar.RentalHours = modelDto.RentalHours;
            return RentalCarRepo.Update(existingRentalCar);
        }
        return false;
    }

    /// <summary>
    /// check to valid
    /// </summary>
    /// <param name="rental"></param>
    /// <returns></returns>
    private bool CanUpdateRentalDuration(RentalCar rental) => 
        rental.IssueTime.AddHours(rental.RentalHours) > DateTime.Now;
    
    /// <summary>
    /// Delete RentalCar by its id 
    /// </summary>
    /// <param name="id">RentalCar id</param>
    public bool Delete(int id) => RentalCarRepo.Delete(id);
}