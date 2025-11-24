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
    /// return all Clients asynchronously
    /// </summary>
    /// <returns>sequence of ClientsDto</returns>
    public async Task<IEnumerable<ClientsDto>> ReadAllAsync()
    {
        var clients = await ClientRepo.ReadAllAsync();
        return clients.Select(mapper.Map<ClientsDto>);
    }

    /// <summary>
    /// return single Client by id asynchronously
    /// </summary>
    /// <param name="id">Client id</param>
    /// <returns>ClientsDto</returns>
    public async Task<ClientsDto?> ReadAsync(int id)
    {
        var client = await ClientRepo.ReadAsync(id);
        return client is null ? null : mapper.Map<ClientsDto>(client);
    }

    /// <summary>
    /// create new Client asynchronously
    /// </summary>
    /// <param name="modelDto">Client data to create</param>
    /// <returns>Created dto</returns>
    public async Task<ClientsDto> CreateAsync(ClientsCreateDto modelDto)
    {
        var newClient = mapper.Map<Client>(modelDto);
        await ClientRepo.CreateAsync(newClient);
        return mapper.Map<ClientsDto>(newClient);
    }

    /// <summary>
    /// update an existing Client asynchronously
    /// </summary>
    /// <param name="id">Client id</param>
    /// <param name="modelDto">updated Client data</param>
    public async Task<bool> UpdateAsync(int id, ClientsUpdateDto modelDto)
    {
        var existingClient = await ClientRepo.ReadAsync(id);
        if (existingClient is null) return false;

        mapper.Map(modelDto, existingClient);
        return await ClientRepo.UpdateAsync(existingClient);
    }

    /// <summary>
    /// delete Client by its id asynchronously
    /// </summary>
    /// <param name="id">Client id</param>
    public async Task<bool> DeleteAsync(int id)
    {
        var existingClient = await ClientRepo.ReadAsync(id);
        if (existingClient is null) return false;

        return await ClientRepo.DeleteAsync(id);
    }
}