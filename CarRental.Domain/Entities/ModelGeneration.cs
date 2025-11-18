using CarRental.Domain.Enums;

namespace CarRental.Domain.Entities;

/// <summary>
/// The class describes the model Generation 👍
/// </summary>
public class ModelGeneration
{
    /// <summary>
    /// Unique identifier for the model generation
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// The manufacturing year of this generation
    /// </summary>
    public required int Year { get; set; }
    /// <summary>
    /// Engine displacement volume in liters
    /// </summary>
    public required double EngineVolume { get; set; }
    /// <summary>
    /// The type of transmission (Manual or Automatic)
    /// </summary>  
    public required TransmissionTypes TransmissionType { get; set; }
    /// <summary>
    /// Reference to the car model that this generation belongs to
    /// </summary>
    public required CarModel Model { get; set; }
    /// <summary>
    /// The rental cost per hour for this specific model generation
    /// </summary>
    public required decimal RentalCostPerHour { get; set; }
}