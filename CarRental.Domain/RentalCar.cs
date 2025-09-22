namespace CarRental.Domain;

/// <summary>
/// Represents a car rental transaction between a client and a car
/// Tracks the rental period and associated entities
/// </summary>
public class Rental
{
    /// <summary>
    /// Unique identifier for the rental transaction
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The date and time when the rental was issued/started
    /// </summary>
    public required DateTime IssueTime { get; set; }
    /// <summary>
    /// The duration of the rental in hours
    /// </summary>
    public required int RentalHours { get; set; }
    /// <summary>
    /// Foreign key referencing the rented car
    /// </summary>
    public required int CarId { get; set; }
    /// <summary>
    /// Foreign key referencing the client who rented the car
    /// </summary>
    public required int ClientId { get; set; }
}