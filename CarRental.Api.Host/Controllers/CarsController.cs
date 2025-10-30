using CarRental.Application.Contracts.Cars;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Host.Controllers;

/// <summary>
/// Provides API methods for cars
/// </summary>
/// <param name="carsService">cars service</param>
/// <param name="logger">Logger for recording information</param>
[ApiController]
[Route("api/cars")]
public class CarsController(ICarsService carsService, ILogger<CarsController> logger) : ControllerBase
{
    /// <summary>
    /// Get all cars
    /// </summary>
    /// <returns>List of all cars</returns>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public ActionResult<IEnumerable<CarsDto>> ReadAll()
    {
        logger.LogInformation("{method} method of {controller} is called",
            nameof(ReadAll), GetType().Name);

        try
        {
            var result = carsService.ReadAll();

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(ReadAll), GetType().Name);

            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(ReadAll), GetType().Name, ex);

            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Return single Car by id
    /// </summary>
    /// <param name="id">Car id</param>
    /// <returns>Car</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public ActionResult<CarsDto> Read(int id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter",
            nameof(Read), GetType().Name, id);
        try
        {
            var result = carsService.Read(id);

            if (result == null)
            {
                logger.LogWarning("Car with id {id} not found", id);
                return NotFound();
            }

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(Read), GetType().Name);

            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(Read), GetType().Name, ex);

            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Create new Car
    /// </summary>
    /// <param name="modelDto">Car data to create</param>
    /// <returns>Created dto</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public ActionResult<CarsDto> Create(CarsCreateDto modelDto)
    {
        logger.LogInformation("{method} method of {controller} is called",
            nameof(Create), GetType().Name);
        if (!ModelState.IsValid)
        {
            logger.LogWarning("Validation failed: {Errors}",
                string.Join("; ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)));
            return BadRequest(ModelState);
        }
        try
        {
            var result = carsService.Create(modelDto);

            logger.LogInformation("{method} method of {controller} executed successfully with id {id}",
                nameof(Create), GetType().Name, result.Id);

            return CreatedAtAction(nameof(Read), new { id = result.Id }, result);
        }
        catch (InvalidOperationException ex)
        {
            logger.LogWarning("Invalid operation during car creation: {message}", ex.Message);
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
    /// Update an existing Car
    /// </summary>
    /// <param name="id">Car id</param>
    /// <param name="modelDto">Updated Car data</param>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public ActionResult Update(int id, CarsUpdateDto modelDto)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter",
            nameof(Update), GetType().Name, id);
        if (!ModelState.IsValid)
        {
            logger.LogWarning("Validation failed: {Errors}",
                string.Join("; ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)));
            return BadRequest(ModelState);
        }
        try
        {
            var result = carsService.Update(id, modelDto);

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
    /// Delete Car by its id 
    /// </summary>
    /// <param name="id">Car id</param>
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
            var result = carsService.Delete(id);
            
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