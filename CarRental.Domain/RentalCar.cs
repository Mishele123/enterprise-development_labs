﻿namespace CarRental.Domain;

/// <summary>
/// Represents a car rental transaction between a client and a car
/// Tracks the rental period and associated entities
/// </summary>
public class Rental
{
    /// <summary>
    /// Unique identifier for the rental transaction
    /// </summary>
    public required int Id { get; set; }
    /// <summary>
    /// The date and time when the rental was issued/started
    /// </summary>
    public required DateTime IssueTime { get; set; }
    /// <summary>
    /// The duration of the rental in hours
    /// </summary>
    public required int RentalHours { get; set; }
    /// <summary>
    /// Renter car
    /// </summary>
    public required Car RentedCar { get; set; }
    /// <summary>
    /// Client who rentering car
    /// </summary>
    public required Client Client { get; set; }
}