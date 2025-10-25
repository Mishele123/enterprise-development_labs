namespace CarRental.Application.Contracts.Reports;

/// <summary>
/// Provides analytical operations
/// Returns aggregated and filtered data for reporting purposes
/// </summary>
public interface IAnalyticsService
{
    /// <summary>
    /// Display information about all customers who have rented cars of the specified model, 
    /// arrange them by full name
    /// </summary>
    public IEnumerable<ClientRentalInfoDto> GetClientsByCarModel(string modelName);

    /// <summary>
    /// Display information about cars that are rented
    /// </summary>
    public IEnumerable<CurrentlyRentedCarDto> GetCarsCurrentlyRented();

    /// <summary>
    /// top 5 most frequently rented cars
    /// </summary>
    public IEnumerable<CarRentalStatsDto> GetTop5MostFrequentlyRentedCars();

    /// <summary>
    /// For each car, number of rents
    /// </summary>
    public IEnumerable<CarRentalStatsDto> GetRentalCountPerCar();

    /// <summary>
    /// top 5 clients by rental amount
    /// </summary>
    public IEnumerable<ClientRentalStatsDto> GetTop5ClientsByRentalSum();
}