namespace CarRental.Domain;

/// <summary>
/// Represents a client/customer who can rent cars from the system
/// </summary>
public class Client
{
    /// <summary>
    /// Unique identifier for the client
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// The driver's license number of the client. Used for verification
    /// </summary>
    public required string DriverLicenseNumber { get; set; }
    /// <summary>
    /// Full name of the client
    /// </summary>
    public required string FullName { get; set; }
    /// <summary>
    /// Date of birth of the client
    /// </summary>
    public required DateTime DateOfBirth { get; set; }
}