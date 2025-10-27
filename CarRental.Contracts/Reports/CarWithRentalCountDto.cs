using CarRental.Application.Contracts.Cars;
namespace CarRental.Application.Contracts.Reports;

/// <summary>
/// DTO for cars with rental count
/// </summary>
/// <param name="Car">Car information</param>
/// <param name="RentalCount">Number of times the car was rented</param>
public record CarWithRentalCountDto(
    CarsDto Car,
    int RentalCount
);