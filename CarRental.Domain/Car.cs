namespace CarRental.Domain;

/// <summary>
/// The class describes the characteristics of the car
/// </summary>
public class Car
{
    /// <summary>
    /// Unique identifier for the car
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The model generation details including year, engine, and specifications
    /// </summary>
    public required ModelGeneration Generation { get; set; }
    /// <summary>
    /// The license plate number of the car
    /// </summary>
    public required string LicensePlate { get; set; }
    /// <summary>
    /// The colour of the car
    /// </summary>
    public required string Colour { get; set; }
}
