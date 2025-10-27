using CarRental.Application.Contracts.RentalCars;
using CarRental.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
namespace CarRental.Api.Host.Controllers;

/// <summary>
/// Provides API methods for rental cars
/// </summary>
/// <param name="rentalCars">rental cars service</param>
/// <param name="logger">Logger for recording information</param>
public class RentalCarsController(IRentalCars rentalCars, 
    ILogger<RentalCarsController> logger) : ControllerBase
{
    /// <summary>
    /// Return all RentalCars
    /// </summary>
    /// <returns>Sequence of rental cars</returns>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<IEnumerable<RentalCarsDto>> ReadAll()
    {
        logger.LogInformation("{method} method of {controller} is called",
            nameof(ReadAll), GetType().Name);

        try
        {
            var result = rentalCars.ReadAll();

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(ReadAll), GetType().Name);

            return result.Any() ? Ok(result) : NoContent();
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(ReadAll), GetType().Name, ex);

            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Return single RentalCar by id
    /// </summary>
    /// <param name="id">RentalCar id</param>
    /// <returns>RentalCar</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public ActionResult<RentalCarsDto> Read(int id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter",
            nameof(Read), GetType().Name, id);

        try
        {
            var result = rentalCars.Read(id);

            if (result == null)
            {
                logger.LogWarning("Rental car with id {id} not found", id);
                return NotFound();
            }

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(Read), GetType().Name);

            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            logger.LogWarning("Rental car with id {id} not found: {message}", id, ex.Message);
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(Read), GetType().Name, ex);

            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Create new RentalCar
    /// </summary>
    /// <param name="model">RentalCar data to create</param>
    /// <returns>Created dto</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public ActionResult<RentalCarsDto> Create(RentalCarsCreateDto model)
    {
        logger.LogInformation("{method} method of {controller} is called",
            nameof(Create), GetType().Name);

        try
        {
            var result = rentalCars.Create(model);

            logger.LogInformation("{method} method of {controller} executed successfully with id {id}",
                nameof(Create), GetType().Name, result.Id);

            return CreatedAtAction(nameof(Read), new { id = result.Id }, result);
        }
        catch (InvalidOperationException ex)
        {
            logger.LogWarning("Invalid operation during rental car creation: {message}", ex.Message);
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(Create), GetType().Name, ex);

            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Update an existing RentalCar
    /// </summary>
    /// <param name="id">RentalCar id</param>
    /// <param name="model">Updated RentalCar data</param>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public ActionResult Update(int id, RentalCarsUpdateDto model)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter",
            nameof(Update), GetType().Name, id);

        try
        {
            var result = rentalCars.Update(id, model);

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(Update), GetType().Name);

            return result ? Ok() : NotFound();
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(Update), GetType().Name, ex);

            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Delete RentalCar by its id 
    /// </summary>
    /// <param name="id">RentalCar id</param>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public ActionResult Delete(int id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter",
            nameof(Delete), GetType().Name, id);

        try
        {
            var result = rentalCars.Delete(id);

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(Delete), GetType().Name);

            return result ? Ok() : NotFound();
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(Delete), GetType().Name, ex);

            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}