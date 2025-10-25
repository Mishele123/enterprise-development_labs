namespace CarRental.Application.Contracts.RentalCars;

/// <summary>
/// DTO for Rental cars responses
/// </summary>
/// <param name="Id">Unique identifier for the rental transaction</param>
/// <param name="IssueTime">The date and time when the rental was issued/started</param>
/// <param name="RentalHours">The duration of the rental in hours</param>
/// <param name="RentedCarId">Renter car id</param>
/// <param name="ClientId">Client id who rentering car</param>
public record RentalCarsDto(
    int Id,
    DateTime IssueTime,
    int RentalHours,
    int RentedCarId,
    int ClientId
);