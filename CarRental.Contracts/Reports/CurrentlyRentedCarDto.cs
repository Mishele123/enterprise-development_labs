using CarRental.Application.Contracts.Cars;
using CarRental.Application.Contracts.RentalCars;
namespace CarRental.Application.Contracts.Reports;

/// <summary>
/// DTO for currently rented cars with rental details
/// </summary>
/// <param name="Car">Car information</param>
/// <param name="Rental">Rental details</param>
public record CurrentlyRentedCarDto(
    CarsDto Car,
    RentalCarsDto Rental
);