using CarRental.Application.Contracts.ModelGenerations;
using Microsoft.AspNetCore.Mvc;
namespace CarRental.Api.Host.Controllers;

/// <summary>
/// Provides API methods for model generations
/// </summary>
/// <param name="cars">model generations service</param>
/// <param name="logger">Logger for recording information</param>
public class ModelGenerationsController(IModelGenerations modelGenerations, 
    ILogger<ModelGenerationsController> logger) : ControllerBase
{
    /// <summary>
    /// Return all ModelGenerations
    /// </summary>
    /// <returns>Sequence of model generations</returns>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public ActionResult<IEnumerable<ModelGenerationsDto>> ReadAll()
    {
        logger.LogInformation("{method} method of {controller} is called",
            nameof(ReadAll), GetType().Name);

        try
        {
            var result = modelGenerations.ReadAll();

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
    /// Return single ModelGeneration by id
    /// </summary>
    /// <param name="id">ModelGeneration id</param>
    /// <returns>ModelGeneration</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public ActionResult<ModelGenerationsDto> Read(int id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter",
            nameof(Read), GetType().Name, id);

        try
        {
            var result = modelGenerations.Read(id);

            if (result == null)
            {
                logger.LogWarning("Model generation with id {id} not found", id);
                return NotFound();
            }

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(Read), GetType().Name);

            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            logger.LogWarning("Model generation with id {id} not found: {message}", id, ex.Message);
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
    /// Create new ModelGeneration
    /// </summary>
    /// <param name="model">ModelGeneration data to create</param>
    /// <returns>Created dto</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public ActionResult<ModelGenerationsDto> Create(ModelGenerationsCreateDto model)
    {
        logger.LogInformation("{method} method of {controller} is called",
            nameof(Create), GetType().Name);

        try
        {
            var result = modelGenerations.Create(model);

            logger.LogInformation("{method} method of {controller} executed successfully with id {id}",
                nameof(Create), GetType().Name, result.Id);

            return CreatedAtAction(nameof(Read), new { id = result.Id }, result);
        }
        catch (InvalidOperationException ex)
        {
            logger.LogWarning("Invalid operation during model generation creation: {message}", ex.Message);
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
    /// Update an existing ModelGeneration
    /// </summary>
    /// <param name="id">ModelGeneration id</param>
    /// <param name="model">Updated ModelGeneration data</param>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public ActionResult Update(int id, ModelGenerationsUpdateDto model)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter",
            nameof(Update), GetType().Name, id);

        try
        {
            var result = modelGenerations.Update(id, model);

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
    /// Delete ModelGeneration by its id 
    /// </summary>
    /// <param name="id">ModelGeneration id</param>
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
            var result = modelGenerations.Delete(id);

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
