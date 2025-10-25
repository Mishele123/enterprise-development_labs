namespace CarRental.Application.Contracts.Cars;

/// <summary>
/// DTO for updating car information
/// </summary>
/// <param name="LicensePlate">Updated license plate</param>
/// <param name="Colour">Updated colour</param>
public record CarsUpdateDto(
    string LicensePlate, 
    string Colour
);