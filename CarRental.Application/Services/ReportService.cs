using AutoMapper;
using CarRental.Application.Contracts;
using CarRental.Application.Contracts.Cars;
using CarRental.Application.Contracts.Clients;
using CarRental.Application.Contracts.RentalCars;
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
) : IReports
{
    /// <summary>
    /// Display information about all customers who have rented cars of the specified model, 
    /// arrange them by full name
    /// </summary>
    public IEnumerable<ClientsDto> GetClientsByCarModel(string modelName)
    {
        return RentalCarRepo.ReadAll()
            .Where(r => r.RentedCar.Generation.Model.Name == modelName)
            .Select(r => r.Client)
            .Distinct()
            .OrderBy(c => c.FullName)
            .Select(mapper.Map<ClientsDto>);
    }

    /// <summary>
    /// Display information about cars that are rented with rental details
    /// </summary>
    public IEnumerable<(CarsDto Car, RentalCarsDto Rental)> GetCarsCurrentlyRented()
    {
        var currentTime = DateTime.Now;

        return RentalCarRepo.ReadAll()
            .Where(r => r.IssueTime.AddHours(r.RentalHours) > currentTime)
            .Select(r => (
                Car: mapper.Map<CarsDto>(r.RentedCar),
                Rental: mapper.Map<RentalCarsDto>(r)
            ))
            .Distinct();
    }

    /// <summary>
    /// top 5 most frequently rented cars with rental counts
    /// </summary>
    public IEnumerable<(CarsDto Car, int RentalCount)> GetTop5MostFrequentlyRentedCars()
    {
        return RentalCarRepo.ReadAll()
            .GroupBy(r => r.RentedCar)
            .Select(g => (
                Car: mapper.Map<CarsDto>(g.Key),
                RentalCount: g.Count()
            ))
            .OrderByDescending(x => x.RentalCount)
            .Take(5);
    }

    /// <summary>
    /// For each car, number of rents
    /// </summary>
    public Dictionary<int, int> GetRentalCountPerCar()
    {
        return CarRepo.ReadAll()
            .Select(car => new
            {
                CarId = car.Id,
                RentalCount = RentalCarRepo.ReadAll().Count(r => r.RentedCar.Id == car.Id)
            })
            .ToDictionary(x => x.CarId, x => x.RentalCount);
    }

    /// <summary>
    /// top 5 clients by rental amount with spending info
    /// </summary>
    public IEnumerable<(ClientsDto Client, decimal TotalSpent)> GetTop5ClientsByRentalSum()
    {
        return RentalCarRepo.ReadAll()
            .GroupBy(r => r.Client)
            .Select(g => (
                Client: mapper.Map<ClientsDto>(g.Key),
                TotalSpent: g.Sum(r => r.RentalHours * r.RentedCar.Generation.RentalCostPerHour)
            ))
            .OrderByDescending(x => x.TotalSpent)
            .Take(5);
    }
}