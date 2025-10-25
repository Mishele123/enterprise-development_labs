namespace CarRental.Application.Contracts.Reports;

/// <summary>
/// DTO for clients who rented specific car model
/// </summary>
/// <param name="ClientId">Client identifier</param>
/// <param name="FullName">Client full name</param>
/// <param name="DriverLicenseNumber">Driver license number</param>
/// <param name="RentalCount">Number of rentals for this model</param>
/// <param name="LastRentalDate">Last rental date for this model</param>
public record ClientRentalInfoDto(
    int ClientId,
    string FullName,
    string DriverLicenseNumber,
    int RentalCount,
    DateTime LastRentalDate
);