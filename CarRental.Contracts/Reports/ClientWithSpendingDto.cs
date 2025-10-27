using CarRental.Application.Contracts.Clients;
namespace CarRental.Application.Contracts.Reports;

/// <summary>
/// DTO for clients with their total spending
/// </summary>
/// <param name="Client">Client information</param>
/// <param name="TotalSpent">Total amount spent on rentals</param>
public record ClientWithSpendingDto(
    ClientsDto Client,
    decimal TotalSpent
);