namespace CarRental.Application.Contracts.ModelGenerations;

/// <summary>
/// Apolication service that provide CRUD operations for ModelGenerations
/// </summary>
public interface IModelGenerations
{
    /// <summary>
    /// return all ModelGenerations
    /// </summary>
    /// <returns>sequence of</returns>
    public IEnumerable<ModelGenerationsDto> ReadAll();

    /// <summary>
    /// return single ModelGeneration by id
    /// </summary>
    /// <param name="id">ModelGeneration id</param>
    /// <returns>ModelGeneration</returns>
    public ModelGenerationsDto? Read(int id);

    /// <summary>
    /// create new ModelGeneration
    /// </summary>
    /// <param name="model">ModelGeneration data to create</param>
    /// <returns>Created dto</returns>
    public ModelGenerationsDto Create(ModelGenerationsDto model);

    /// <summary>
    /// update an existing ModelGeneration
    /// </summary>
    /// <param name="id">ModelGeneration id</param>
    /// <param name="model">updated ModelGeneration data</param>
    public bool Update(int id, ModelGenerationsDto model);

    /// <summary>
    /// delete ModelGeneration by its id 
    /// </summary>
    /// <param name="id">ModelGeneration id</param>
    public bool Delete(int id);
}