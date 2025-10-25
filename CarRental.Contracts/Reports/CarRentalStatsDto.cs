namespace CarRental.Application.Contracts.Reports;

/// <summary>
/// DTO for car rental statistics
/// </summary>
/// <param name="CarId">Car identifier</param>
/// <param name="LicensePlate">License plate</param>
/// <param name="ModelName">Car model name</param>
/// <param name="RentalCount">Number of rentals</param>
/// <param name="TotalRevenue">Total revenue from rentals</param>
public record CarRentalStatsDto(
    int CarId,
    string LicensePlate,
    string ModelName,
    int RentalCount,
    decimal TotalRevenue
);