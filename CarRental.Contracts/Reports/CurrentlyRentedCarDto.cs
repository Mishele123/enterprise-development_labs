namespace CarRental.Application.Contracts.Reports;

/// <summary>
/// DTO for currently rented cars
/// </summary>
/// <param name="CarId">Car identifier</param>
/// <param name="LicensePlate">License plate</param>
/// <param name="ModelName">Car model name</param>
/// <param name="ClientName">Client who rented the car</param>
/// <param name="RentalStartTime">Rental start time</param>
/// <param name="RentalEndTime">Expected rental end time</param>
/// <param name="RemainingHours">Remaining rental hours</param>
public record CurrentlyRentedCarDto(
    int CarId,
    string LicensePlate,
    string ModelName,
    string ClientName,
    DateTime RentalStartTime,
    DateTime RentalEndTime,
    int RemainingHours
);