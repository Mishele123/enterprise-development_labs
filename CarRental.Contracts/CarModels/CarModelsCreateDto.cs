using CarRental.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Application.Contracts.CarModels;

/// <summary>
/// DTO for creating a new car model
/// </summary>
/// <param name="Name">The name of the car model</param>
/// <param name="DriveType">The drive type of the vehicle (FWD, RWD, AWD)</param>
/// <param name="SeatCount">The number of seats available in the vehicle</param>
/// <param name="BodyType">The body type classification of the vehicle</param>
/// <param name="VehicleClass">The vehicle class determining rental category and pricing tier</param>
public record CarModelsCreateDto(
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Model name must be between 2 and 50 characters")]
    string Name,
    DriveTypes DriveType,
    [Range(1, 20, ErrorMessage = "Seats count must be between 1 and 20")]
    int SeatCount,
    BodyTypes BodyType,
    VehicleClasses VehicleClass
);