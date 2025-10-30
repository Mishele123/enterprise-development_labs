using CarRental.Application.Contracts.Clients;

namespace CarRental.Application.Contracts.Reports;

/// <summary>
/// Provides analytical operations
/// Returns aggregated and filtered data for reporting purposes
/// </summary>
public interface IReportsService
{
    /// <summary>
    /// Display information about all customers who have rented cars of the specified model, 
    /// arrange them by full name
    /// </summary>
    public IEnumerable<ClientsDto> GetClientsByCarModel(string modelName);

    /// <summary>
    /// Display information about cars that are rented with rental details
    /// </summary>
    public IEnumerable<CurrentlyRentedCarDto> GetCarsCurrentlyRented();

    /// <summary>
    /// top 5 most frequently rented cars with rental counts
    /// </summary>
    public IEnumerable<CarWithRentalCountDto> GetTop5MostFrequentlyRentedCars();

    /// <summary>
    /// For each car, number of rents
    /// </summary>
    public Dictionary<int, int> GetRentalCountPerCar();

    /// <summary>
    /// top 5 clients by rental amount with spending info
    /// </summary>
    public IEnumerable<ClientWithSpendingDto> GetTop5ClientsByRentalSum();
}