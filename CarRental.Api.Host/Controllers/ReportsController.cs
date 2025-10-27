using CarRental.Application.Contracts;
using CarRental.Application.Contracts.Cars;
using CarRental.Application.Contracts.Clients;
using CarRental.Application.Contracts.RentalCars;
using Microsoft.AspNetCore.Mvc;
namespace CarRental.Api.Host.Controllers;

/// <summary>
/// Provides API methods for analytical queries
/// </summary>
/// <param name="reports">Reports service</param>
/// <param name="logger">Logger for recording information</param>
[ApiController]
[Route("api/[controller]")]
public class ReportsController(IReports reports, ILogger<ReportsController> logger) : ControllerBase
{
    /// <summary>
    /// Display information about all customers who have rented cars of the specified model, 
    /// arrange them by full name
    /// </summary>
    /// <param name="modelName">Name of model</param>
    /// <returns>all customers who have rented cars of the specified model</returns>
    [HttpGet("clients-by-model/{modelName}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<IEnumerable<ClientsDto>> GetClientsByCarModel(string modelName)
    {
        logger.LogInformation("{method} method of {controller} is called with {modelName} parameter",
        nameof(GetClientsByCarModel), GetType().Name, modelName);
        try
        {
            var clients = reports.GetClientsByCarModel(modelName);
            logger.LogInformation("{method} method of {controller} executed successfully",
            nameof(GetClientsByCarModel), GetType().Name);
            return clients.Any() ? Ok(clients) : NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
            nameof(GetClientsByCarModel), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Get information about cars that are currently rented
    /// </summary>
    /// <returns>List of currently rented cars with rental details</returns>
    [HttpGet("currently-rented")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<IEnumerable<(CarsDto Car, RentalCarsDto Rental)>> GetCarsCurrentlyRented()
    {
        logger.LogInformation("{method} method of {controller} is called",
            nameof(GetCarsCurrentlyRented), GetType().Name);

        try
        {
            var rentedCars = reports.GetCarsCurrentlyRented();

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(GetCarsCurrentlyRented), GetType().Name);

            return rentedCars.Any() ? Ok(rentedCars) : NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(GetCarsCurrentlyRented), GetType().Name, ex);

            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Get top 5 most frequently rented cars
    /// </summary>
    /// <returns>Top 5 cars with rental counts</returns>
    [HttpGet("top-5-rented-cars")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<IEnumerable<(CarsDto Car, int RentalCount)>> GetTop5MostFrequentlyRentedCars()
    {
        logger.LogInformation("{method} method of {controller} is called",
            nameof(GetTop5MostFrequentlyRentedCars), GetType().Name);

        try
        {
            var topCars = reports.GetTop5MostFrequentlyRentedCars();

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(GetTop5MostFrequentlyRentedCars), GetType().Name);

            return topCars.Any() ? Ok(topCars) : NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(GetTop5MostFrequentlyRentedCars), GetType().Name, ex);

            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Get rental count for each car
    /// </summary>
    /// <returns>Dictionary with car ID and rental count</returns>
    [HttpGet("rental-count-per-car")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<Dictionary<int, int>> GetRentalCountPerCar()
    {
        logger.LogInformation("{method} method of {controller} is called",
            nameof(GetRentalCountPerCar), GetType().Name);

        try
        {
            var rentalCounts = reports.GetRentalCountPerCar();

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(GetRentalCountPerCar), GetType().Name);

            return rentalCounts.Any() ? Ok(rentalCounts) : NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(GetRentalCountPerCar), GetType().Name, ex);

            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Get top 5 clients by total rental spending
    /// </summary>
    /// <returns>Top 5 clients with total spent amount</returns>
    [HttpGet("top-5-clients-by-spending")]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<IEnumerable<(ClientsDto Client, decimal TotalSpent)>> GetTop5ClientsByRentalSum()
    {
            logger.LogInformation("{method} method of {controller} is called",
            nameof(GetTop5ClientsByRentalSum), GetType().Name);

        try
        {
            var topClients = reports.GetTop5ClientsByRentalSum();

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(GetTop5ClientsByRentalSum), GetType().Name);

            return topClients.Any() ? Ok(topClients) : NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(GetTop5ClientsByRentalSum), GetType().Name, ex);

            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}