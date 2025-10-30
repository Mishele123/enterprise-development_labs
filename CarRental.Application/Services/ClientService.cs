using AutoMapper;
using CarRental.Application.Contracts.Clients;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;

namespace CarRental.Application.Services;

/// <summary>
/// Crud Client operations
/// </summary>
/// <param name="ClientRepo"></param>
/// <param name="mapper"></param>
public class ClientService(
    IClientRepository ClientRepo,
    IMapper mapper
) : IClientsService
{
    /// <summary>
    /// return all Clients
    /// </summary>
    /// <returns>sequence of</returns>
    public IEnumerable<ClientsDto> ReadAll() => ClientRepo.ReadAll().Select(mapper.Map<ClientsDto>);

    /// <summary>
    /// return single Client by id
    /// </summary>
    /// <param name="id">Client id</param>
    /// <returns>Client</returns>
    public ClientsDto? Read(int id)
    {
        var client = ClientRepo.Read(id);
        return client is null ? null : mapper.Map<ClientsDto>(client);
    }

    /// <summary>
    /// create new Client
    /// </summary>
    /// <param name="modelDto">Client data to create</param>
    /// <returns>Created dto</returns>
    public ClientsDto Create(ClientsCreateDto modelDto)
    {
        var newClient = mapper.Map<Client>(modelDto);
        ClientRepo.Create(newClient);
        return mapper.Map<ClientsDto>(newClient);
    }

    /// <summary>
    /// update an existing Client
    /// </summary>
    /// <param name="id">Client id</param>
    /// <param name="modelDto">updated Client data</param>
    public bool Update(int id, ClientsUpdateDto modelDto)
    {
        var existingClient = ClientRepo.Read(id);
        if (existingClient is null) return false;
        mapper.Map(modelDto, existingClient);

        return ClientRepo.Update(existingClient);
    }

    /// <summary>
    /// delete Client by its id 
    /// </summary>
    /// <param name="id">Client id</param>
    public bool Delete(int id)
    {
        var existingClient = ClientRepo.Read(id);
        if (existingClient is null) return false;
        return ClientRepo.Delete(id);
    }
}