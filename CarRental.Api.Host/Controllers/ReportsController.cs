using CarRental.Application.Contracts.Clients;
using CarRental.Application.Contracts.Reports;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Host.Controllers;

/// <summary>
/// Provides API methods for analytical queries
/// </summary>
/// <param name="reportsService">Reports service</param>
/// <param name="logger">Logger for recording information</param>
[ApiController]
[Route("api/reports")]
public class ReportsController(IReportsService reportsService, ILogger<ReportsController> logger) : ControllerBase
{
    /// <summary>
    /// Display information about all customers who have rented cars of the specified model, 
    /// arrange them by full name
    /// </summary>
    /// <param name="modelName">Name of model</param>
    /// <returns>all customers who have rented cars of the specified model</returns>
    [HttpGet("clients-by-model/{modelName}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<ClientsDto>>> GetClientsByCarModelAsync(string modelName)
    {
        logger.LogInformation("{method} method of {controller} is called with {modelName} parameter",
        nameof(GetClientsByCarModelAsync), GetType().Name, modelName);
        try
        {
            var clients = await reportsService.GetClientsByCarModelAsync(modelName);
            logger.LogInformation("{method} method of {controller} executed successfully",
            nameof(GetClientsByCarModelAsync), GetType().Name);
            return Ok(clients);
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
            nameof(GetClientsByCarModelAsync), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Get information about cars that are currently rented
    /// </summary>
    /// <returns>List of currently rented cars with rental details</returns>
    [HttpGet("currently-rented")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<CurrentlyRentedCarDto>>> GetCarsCurrentlyRentedAsync()
    {
        logger.LogInformation("{method} method of {controller} is called",
            nameof(GetCarsCurrentlyRentedAsync), GetType().Name);

        try
        {
            var rentedCars = await reportsService.GetCarsCurrentlyRentedAsync();

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(GetCarsCurrentlyRentedAsync), GetType().Name);

            return Ok(rentedCars);
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(GetCarsCurrentlyRentedAsync), GetType().Name, ex);

            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Get top 5 most frequently rented cars
    /// </summary>
    /// <returns>Top 5 cars with rental counts</returns>
    [HttpGet("top-5-rented-cars")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<CarWithRentalCountDto>>> GetTop5MostFrequentlyRentedCarsAsync()
    {
        logger.LogInformation("{method} method of {controller} is called",
            nameof(GetTop5MostFrequentlyRentedCarsAsync), GetType().Name);

        try
        {
            var topCars = await reportsService.GetTop5MostFrequentlyRentedCarsAsync();

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(GetTop5MostFrequentlyRentedCarsAsync), GetType().Name);

            return Ok(topCars);
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(GetTop5MostFrequentlyRentedCarsAsync), GetType().Name, ex);

            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Get rental count for each car
    /// </summary>
    /// <returns>Dictionary with car ID and rental count</returns>
    [HttpGet("rental-count-per-car")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<Dictionary<int, int>>> GetRentalCountPerCarAsync()
    {
        logger.LogInformation("{method} method of {controller} is called",
            nameof(GetRentalCountPerCarAsync), GetType().Name);

        try
        {
            var rentalCounts = await reportsService.GetRentalCountPerCarAsync();

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(GetRentalCountPerCarAsync), GetType().Name);

            return Ok(rentalCounts);
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(GetRentalCountPerCarAsync), GetType().Name, ex);

            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Get top 5 clients by total rental spending
    /// </summary>
    /// <returns>Top 5 clients with total spent amount</returns>
    [HttpGet("top-5-clients-by-spending")]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<ClientWithSpendingDto>>> GetTop5ClientsByRentalSumAsync()
    {
        logger.LogInformation("{method} method of {controller} is called",
        nameof(GetTop5ClientsByRentalSumAsync), GetType().Name);

        try
        {
            var topClients = await reportsService.GetTop5ClientsByRentalSumAsync();

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(GetTop5ClientsByRentalSumAsync), GetType().Name);

            return Ok(topClients);
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(GetTop5ClientsByRentalSumAsync), GetType().Name, ex);

            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}