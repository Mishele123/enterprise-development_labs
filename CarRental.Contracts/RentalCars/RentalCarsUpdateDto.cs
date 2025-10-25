namespace CarRental.Application.Contracts.RentalCars;

/// <summary>
/// DTO for update duration of the rental in hours
/// </summary>
/// <param name="RentalHours">The duration of the rental in hours</param>
public record RentalCarsUpdateDto(
    int RentalHours    
);