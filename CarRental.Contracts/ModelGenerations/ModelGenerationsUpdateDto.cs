namespace CarRental.Application.Contracts.ModelGenerations;

/// <summary>
/// DTO for updating a model generation
/// </summary>
/// <param name="RentalCostPerHour">The rental cost per hour for this specific model generation</param>
public record ModelGeneratoinsUpdateDto(
    decimal RentalCostPerHour
);