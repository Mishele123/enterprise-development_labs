using CarRental.Domain.Enums;
using System.ComponentModel.DataAnnotations;
namespace CarRental.Application.Contracts.ModelGenerations;

/// <summary>
/// DTO for creating a new model generation
/// </summary>
/// <param name="Year">The manufacturing year of this generation</param>
/// <param name="EngineVolume">Engine displacement volume in liters</param>
/// <param name="TransmissionType">The type of transmission (Manual or Automatic)</param>
/// <param name="ModelId">Reference to the car model that this generation belongs to</param>
/// <param name="RentalCostPerHour">The rental cost per hour for this specific model generation</param>
public record ModelGenerationsCreateDto(
      [Range(1990, 2025, ErrorMessage = "Year must be between 1990 and 2025")]
      int Year,
      double EngineVolume,
      TransmissionTypes TransmissionType,
      int ModelId,
      decimal RentalCostPerHour
);