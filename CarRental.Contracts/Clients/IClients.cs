namespace CarRental.Application.Contracts.Clients;

/// <summary>
/// Application service that provide CRUD operations for Clients
/// </summary>
public interface IClients
{
    /// <summary>
    /// return all Clients
    /// </summary>
    /// <returns>sequence of</returns>
    public IEnumerable<ClientsDto> ReadAll();

    /// <summary>
    /// return single Client by id
    /// </summary>
    /// <param name="id">Client id</param>
    /// <returns>Client</returns>
    public ClientsDto? Read(int id);

    /// <summary>
    /// create new Client
    /// </summary>
    /// <param name="model">Client data to create</param>
    /// <returns>Created dto</returns>
    public ClientsDto Create(ClientsDto model);

    /// <summary>
    /// update an existing Client
    /// </summary>
    /// <param name="id">Client id</param>
    /// <param name="model">updated Client data</param>
    public bool Update(int id, ClientsDto model);

    /// <summary>
    /// delete Client by its id 
    /// </summary>
    /// <param name="id">Client id</param>
    public bool Delete(int id);
}