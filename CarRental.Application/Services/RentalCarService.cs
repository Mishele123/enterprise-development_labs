using AutoMapper;
using CarRental.Application.Contracts.RentalCars;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;

namespace CarRental.Application.Services;

/// <summary>
/// Crud operations for rental car
/// </summary>
/// <param name="RentalCarRepo"></param>
/// <param name="CarRepo"></param>
/// <param name="ClientRepo"></param>
/// <param name="mapper"></param>
public class RentalCarService(
    IRentalCarRepository RentalCarRepo,
    ICarRepository CarRepo,
    IClientRepository ClientRepo,
    IMapper mapper
) : IRentalCarsService
{
    /// <summary>
    /// Return all RentalCars asynchronously
    /// </summary>
    /// <returns>sequence of RentalCarsDto</returns>
    public async Task<IEnumerable<RentalCarsDto>> ReadAllAsync()
    {
        var rentalCars = await RentalCarRepo.ReadAllAsync();
        return rentalCars.Select(mapper.Map<RentalCarsDto>);
    }

    /// <summary>
    /// Return single RentalCar by id asynchronously
    /// </summary>
    /// <param name="id">RentalCar id</param>
    /// <returns>RentalCarsDto</returns>
    public async Task<RentalCarsDto?> ReadAsync(int id)
    {
        var rentalCar = await RentalCarRepo.ReadAsync(id);
        return rentalCar is null ? null : mapper.Map<RentalCarsDto>(rentalCar);
    }

    /// <summary>
    /// Create new RentalCar asynchronously
    /// </summary>
    /// <param name="modelDto">RentalCar data to create</param>
    /// <returns>Created dto</returns>
    public async Task<RentalCarsDto> CreateAsync(RentalCarsCreateDto modelDto)
    {
        var car = await CarRepo.ReadAsync(modelDto.RentedCarId)
            ?? throw new InvalidOperationException($"car with id: {modelDto.RentedCarId} not found");
        var client = await ClientRepo.ReadAsync(modelDto.ClientId)
            ?? throw new InvalidOperationException($"client with id: {modelDto.ClientId} not found");

        var newRentalStart = modelDto.IssueTime;
        var newRentalEnd = modelDto.IssueTime.AddHours(modelDto.RentalHours);

        var allRentals = await RentalCarRepo.ReadAllAsync();
        var hasOverlappingRentals = allRentals
            .Where(r => r.RentedCar.Id == modelDto.RentedCarId)
            .Any(r =>
            {
                var existingRentalEnd = r.IssueTime.AddHours(r.RentalHours);
                return newRentalStart < existingRentalEnd && newRentalEnd > r.IssueTime;
            });

        if (hasOverlappingRentals)
        {
            throw new InvalidOperationException($"car with id: {modelDto.RentedCarId} is not available for the requested period");
        }

        var newRentalCar = mapper.Map<RentalCar>(modelDto);
        newRentalCar.RentedCar = car;
        newRentalCar.Client = client;
        await RentalCarRepo.CreateAsync(newRentalCar);
        return mapper.Map<RentalCarsDto>(newRentalCar);
    }

    /// <summary>
    /// Update an existing RentalCar asynchronously
    /// </summary>
    /// <param name="id">RentalCar id</param>
    /// <param name="modelDto">updated RentalCar data</param>
    public async Task<bool> UpdateAsync(int id, RentalCarsUpdateDto modelDto)
    {
        var existingRentalCar = await RentalCarRepo.ReadAsync(id);
        if (existingRentalCar is null) return false;

        if (!CanUpdateRentalDuration(existingRentalCar))
        {
            throw new InvalidOperationException("Cannot update rental: rental period has already ended");
        }

        var originalRentalEnd = existingRentalCar.IssueTime.AddHours(existingRentalCar.RentalHours);
        var updatedRentalEnd = existingRentalCar.IssueTime.AddHours(modelDto.RentalHours);

        if (modelDto.RentalHours > existingRentalCar.RentalHours)
        {
            var allRentals = await RentalCarRepo.ReadAllAsync();
            var hasOverlappingRentals = allRentals
                .Where(r => r.RentedCar.Id == existingRentalCar.RentedCar.Id && r.Id != id)
                .Any(r =>
                {
                    var existingRentalEnd = r.IssueTime.AddHours(r.RentalHours);
                    return updatedRentalEnd > r.IssueTime && existingRentalCar.IssueTime < existingRentalEnd;
                });

            if (hasOverlappingRentals)
            {
                throw new InvalidOperationException($"Cannot extend rental: " +
                    $"car is booked by another customer after the original end time");
            }
        }

        existingRentalCar.RentalHours = modelDto.RentalHours;
        return await RentalCarRepo.UpdateAsync(existingRentalCar);
    }

    /// <summary>
    /// Check if rental duration can be updated
    /// </summary>
    /// <param name="rental">Rental car entity</param>
    /// <returns>True if rental can be updated</returns>
    private static bool CanUpdateRentalDuration(RentalCar rental) =>
        rental.IssueTime.AddHours(rental.RentalHours) > DateTime.Now;

    /// <summary>
    /// Delete RentalCar by its id asynchronously
    /// </summary>
    /// <param name="id">RentalCar id</param>
    public async Task<bool> DeleteAsync(int id)
    {
        var existingRentalCar = await RentalCarRepo.ReadAsync(id);
        if (existingRentalCar is null) return false;

        return await RentalCarRepo.DeleteAsync(id);
    }
}