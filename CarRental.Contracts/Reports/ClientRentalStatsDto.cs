namespace CarRental.Application.Contracts.Reports;

/// <summary>
/// DTO for client rental statistics
/// </summary>
/// <param name="ClientId">Client identifier</param>
/// <param name="FullName">Client full name</param>
/// <param name="DriverLicenseNumber">Driver license number</param>
/// <param name="TotalRentalAmount">Total rental amount spent</param>
/// <param name="RentalCount">Number of rentals</param>
public record ClientRentalStatsDto(
    int ClientId,
    string FullName,
    string DriverLicenseNumber,
    decimal TotalRentalAmount,
    int RentalCount
);