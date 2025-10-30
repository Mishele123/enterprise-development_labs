using CarRental.Application.Contracts.Clients;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Api.Host.Controllers;

/// <summary>
/// Provides API methods for clients
/// </summary>
/// <param name="clientsService">clients service</param>
/// <param name="logger">Logger for recording information</param>
[ApiController]
[Route("api/clients")]
public class ClientsController(IClientsService clientsService, ILogger<ClientsController> logger) : ControllerBase
{
    /// <summary>
    /// Return all Clients
    /// </summary>
    /// <returns>Sequence of clients</returns>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public ActionResult<IEnumerable<ClientsDto>> ReadAll()
    {
        logger.LogInformation("{method} method of {controller} is called",
            nameof(ReadAll), GetType().Name);

        try
        {
            var result = clientsService.ReadAll();

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
    /// Return single Client by id
    /// </summary>
    /// <param name="id">Client id</param>
    /// <returns>Client</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public ActionResult<ClientsDto> Read(int id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter",
            nameof(Read), GetType().Name, id);

        try
        {
            var result = clientsService.Read(id);

            if (result == null)
            {
                logger.LogWarning("Client with id {id} not found", id);
                return NotFound();
            }

            logger.LogInformation("{method} method of {controller} executed successfully",
                nameof(Read), GetType().Name);

            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            logger.LogWarning("Client with id {id} not found: {message}", id, ex.Message);
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
    /// Create new Client
    /// </summary>
    /// <param name="model">Client data to create</param>
    /// <returns>Created dto</returns>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public ActionResult<ClientsDto> Create(ClientsCreateDto model)
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
            var result = clientsService.Create(model);

            logger.LogInformation("{method} method of {controller} executed successfully with id {id}",
                nameof(Create), GetType().Name, result.Id);

            return CreatedAtAction(nameof(Read), new { id = result.Id }, result);
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}",
                nameof(Create), GetType().Name, ex);

            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Update an existing Client
    /// </summary>
    /// <param name="id">Client id</param>
    /// <param name="model">Updated Client data</param>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public ActionResult Update(int id, ClientsUpdateDto model)
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
            var result = clientsService.Update(id, model);

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
    /// Delete Client by its id 
    /// </summary>
    /// <param name="id">Client id</param>
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
            var result = clientsService.Delete(id);

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