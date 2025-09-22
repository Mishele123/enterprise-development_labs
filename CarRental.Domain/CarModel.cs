using CarRental.Domain.Enums;

namespace CarRental.Domain;
/// <summary>
/// Represents a car model with its general characteristics and classification
/// </summary>
public class CarModel
{
    /// <summary>
    /// Unique identifier for the car model
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The name of the car model
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// The drive type of the vehicle (FWD, RWD, AWD)
    /// </summary>
    public required DriveTypes DriveType { get; set; }
    /// <summary>
    /// The number of seats available in the vehicle
    /// </summary>
    public required int SeatCount { get; set; }
    /// <summary>
    /// The body type classification of the vehicle
    /// </summary>
    public required BodyType BodyType { get; set; }
    /// <summary>
    /// The vehicle class determining rental category and pricing tier
    /// </summary>
    public required VehicleClass VehicleClass { get; set; } 
}
