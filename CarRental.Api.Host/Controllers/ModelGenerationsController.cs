using CarRental.Application.Contracts.ModelGenerations;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Host.Controllers;

/// <summary>
/// Provides API methods for model generations
/// </summary>
/// <param name="modelGenerationsService">model generations service</param>
/// <param name="logger">Logger for recording information</param>
[ApiController]
[Route("api/model-generations")]
public class ModelGenerationsController(IModelGenerationsService modelGenerationsService,
    ILogger<ModelGenerationsController> logger) : ControllerBase
{
    /// <summary>
    /// Return all ModelGenerations
    /// </summary>
    /// <returns>Sequence of model generations</returns>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IEnumerable<ModelGenerationsDto>>> ReadAllAsync()
    {
        logger.LogInformation("{method} method of {controller} is called",
            nameof(ReadAllAsync), GetType().Name);

        try
        {
            var result = await modelGenerationsService.ReadAllAsync();

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(ReadAllAsync), GetType().Name);

            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(ReadAllAsync), GetType().Name, ex);

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
    public async Task<ActionResult<ModelGenerationsDto>> ReadAsync(int id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter",
            nameof(ReadAsync), GetType().Name, id);

        try
        {
            var result = await modelGenerationsService.ReadAsync(id);

            if (result == null)
            {
                logger.LogWarning("Model generation with id {id} not found", id);
                return NotFound();
            }

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(ReadAsync), GetType().Name);

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
                nameof(ReadAsync), GetType().Name, ex);

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
    public async Task<ActionResult<ModelGenerationsDto>> CreateAsync(ModelGenerationsCreateDto model)
    {
        logger.LogInformation("{method} method of {controller} is called",
            nameof(CreateAsync), GetType().Name);
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
            var result = await modelGenerationsService.CreateAsync(model);

            logger.LogInformation("{method} method of {controller} executed successfully with id {id}",
                nameof(CreateAsync), GetType().Name, result.Id);

            return CreatedAtAction(nameof(ReadAsync), new { id = result.Id }, result);
        }
        catch (InvalidOperationException ex)
        {
            logger.LogWarning("Invalid operation during model generation creation: {message}", ex.Message);
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(CreateAsync), GetType().Name, ex);

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
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult> UpdateAsync(int id, ModelGenerationsUpdateDto model)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter",
            nameof(UpdateAsync), GetType().Name, id);
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
            var result = await modelGenerationsService.UpdateAsync(id, model);

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(UpdateAsync), GetType().Name);

            return result ? Ok() : NotFound();
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(UpdateAsync), GetType().Name, ex);

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
    public async Task<ActionResult> DeleteAsync(int id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter",
            nameof(DeleteAsync), GetType().Name, id);

        try
        {
            var result = await modelGenerationsService.DeleteAsync(id);

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(DeleteAsync), GetType().Name);

            return result ? Ok() : NotFound();
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(DeleteAsync), GetType().Name, ex);

            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}