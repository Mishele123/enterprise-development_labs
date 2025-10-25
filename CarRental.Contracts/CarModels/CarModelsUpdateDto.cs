using System.ComponentModel.DataAnnotations;
namespace CarRental.Application.Contracts.CarModels;

/// <summary>
/// DTO for updating an existing car model
/// </summary>
/// <param name="Name">The updated name of the car model</param>
/// <param name="SeatCount">The updated number of seats</param>
public record CarModelsUpdateDto(
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Model name must be between 2 and 50 characters")]
    string Name,
    [Range(1, 20, ErrorMessage = "Seat count must be between 1 and 20")]
    int SeatsCount
);