namespace CarRental.Application.Contracts.Cars;

/// <summary>
/// DTO for creating Car
/// </summary>
/// <param name="GenerationId">Generation</param>
/// <param name="LicensePlate">License plate</param>
/// <param name="Colour">Car colour</param>
public record CarsCreateDto(
    int GenerationId,
    string LicensePlate,
    string Colour
);