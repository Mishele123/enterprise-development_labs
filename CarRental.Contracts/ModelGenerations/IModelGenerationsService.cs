namespace CarRental.Application.Contracts.ModelGenerations;

/// <summary>
/// Apolication service that provide CRUD operations for ModelGenerations
/// </summary>
public interface IModelGenerationsService
{
    /// <summary>
    /// return all ModelGenerations
    /// </summary>
    /// <returns>sequence of</returns>
    public Task<IEnumerable<ModelGenerationsDto>> ReadAllAsync();

    /// <summary>
    /// return single ModelGeneration by id
    /// </summary>
    /// <param name="id">ModelGeneration id</param>
    /// <returns>ModelGeneration</returns>
    public Task<ModelGenerationsDto?> ReadAsync(int id);

    /// <summary>
    /// create new ModelGeneration
    /// </summary>
    /// <param name="model">ModelGeneration data to create</param>
    /// <returns>Created dto</returns>
    public Task<ModelGenerationsDto> CreateAsync(ModelGenerationsCreateDto model);

    /// <summary>
    /// update an existing ModelGeneration
    /// </summary>
    /// <param name="id">ModelGeneration id</param>
    /// <param name="model">updated ModelGeneration data</param>
    public Task<bool> UpdateAsync(int id, ModelGenerationsUpdateDto model);

    /// <summary>
    /// delete ModelGeneration by its id 
    /// </summary>
    /// <param name="id">ModelGeneration id</param>
    public Task<bool> DeleteAsync(int id);
}