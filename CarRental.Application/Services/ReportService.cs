using AutoMapper;
using CarRental.Application.Contracts.Cars;
using CarRental.Application.Contracts.Clients;
using CarRental.Application.Contracts.RentalCars;
using CarRental.Application.Contracts.Reports;
using CarRental.Domain.Interfaces;

namespace CarRental.Application.Services;

/// <summary>
/// Provides analytical operations
/// Returns aggregated and filtered data for reporting purposes
/// </summary>
/// <param name="CarRepo"></param>
/// <param name="RentalCarRepo"></param>
/// <param name="mapper"></param>
public class ReportService(
    ICarRepository CarRepo,
    IRentalCarRepository RentalCarRepo,
    IMapper mapper
) : IReportsService
{
    /// <summary>
    /// Display information about all customers who have rented cars of the specified model, 
    /// arrange them by full name
    /// </summary>
    public async Task<IEnumerable<ClientsDto>> GetClientsByCarModelAsync(string modelName)
    {
        var rentalCars = await RentalCarRepo.ReadAllAsync();
        return rentalCars
            .Where(r => r.RentedCar.Generation.Model.Name == modelName)
            .Select(r => r.Client)
            .OrderBy(c => c.FullName)
            .Select(mapper.Map<ClientsDto>);
    }

    /// <summary>
    /// Display information about cars that are rented with rental details
    /// </summary>
    public async Task<IEnumerable<CurrentlyRentedCarDto>> GetCarsCurrentlyRentedAsync()
    {
        var currentTime = DateTime.Now;
        var rentalCars = await RentalCarRepo.ReadAllAsync();

        return rentalCars
            .Where(r => r.IssueTime.AddHours(r.RentalHours) > currentTime)
            .Select(r => new CurrentlyRentedCarDto(
                mapper.Map<CarsDto>(r.RentedCar),
                mapper.Map<RentalCarsDto>(r)
            ));
    }

    /// <summary>
    /// top 5 most frequently rented cars with rental counts
    /// </summary>
    public async Task<IEnumerable<CarWithRentalCountDto>> GetTop5MostFrequentlyRentedCarsAsync()
    {
        var rentalCars = await RentalCarRepo.ReadAllAsync();
        return rentalCars
            .GroupBy(r => r.RentedCar)
            .Select(g => new CarWithRentalCountDto(
                mapper.Map<CarsDto>(g.Key),
                g.Count()
            ))
            .OrderByDescending(x => x.RentalCount)
            .Take(5);
    }

    /// <summary>
    /// For each car, number of rents
    /// </summary>
    public async Task<Dictionary<int, int>> GetRentalCountPerCarAsync()
    {
        var cars = await CarRepo.ReadAllAsync();
        var rentalCars = await RentalCarRepo.ReadAllAsync();

        return cars
            .Select(car => new
            {
                CarId = car.Id,
                RentalCount = rentalCars.Count(r => r.RentedCar.Id == car.Id)
            })
            .ToDictionary(x => x.CarId, x => x.RentalCount);
    }

    /// <summary>
    /// top 5 clients by rental amount with spending info
    /// </summary>
    public async Task<IEnumerable<ClientWithSpendingDto>> GetTop5ClientsByRentalSumAsync()
    {
        var rentalCars = await RentalCarRepo.ReadAllAsync();
        return rentalCars
            .GroupBy(r => r.Client)
            .Select(g => new ClientWithSpendingDto(
                mapper.Map<ClientsDto>(g.Key),
                g.Sum(r => r.RentalHours * r.RentedCar.Generation.RentalCostPerHour)
            ))
            .OrderByDescending(x => x.TotalSpent)
            .Take(5);
    }
}