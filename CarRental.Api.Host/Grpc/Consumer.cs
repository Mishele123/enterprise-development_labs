using CarRental.Application.Contracts.Cars;
using CarRental.Application.Contracts.Clients;
using CarRental.Application.Contracts.RentalCars;
using CarRental.Grpc.Protos;
using Grpc.Core;


namespace CarRental.Api.Host.Grpc;

public class Consumer(
    IRentalCarsService rentalCarsService,
    ICarsService carsService,
    IClientsService clientsService,
    ILogger<Consumer> logger
) : ContractGeneratorService.ContractGeneratorServiceBase
{
    public override async Task GenerateRental(
    IAsyncStreamReader<RequestRental> requestStream,
    IServerStreamWriter<ResponseMessage> responseStream,
    ServerCallContext context)
    {
        await foreach (var req in requestStream.ReadAllAsync(context.CancellationToken))
        {
            try
            {
                logger.LogInformation("Rental received: CarId={CarId}, ClientId={ClientId}",
                    req.CarId, req.ClientId);
                
                var rentalDto = new RentalCarsCreateDto
                (
                    DateTime.Parse(req.IssueTime),
                    req.RentalHours,
                    req.CarId,
                    req.ClientId
                );

                var result = await rentalCarsService.CreateAsync(rentalDto);

                await responseStream.WriteAsync(new ResponseMessage
                {
                    Success = true,
                    Message = $"Rental created with id: {result.Id}"
                });
                logger.LogInformation("Rental created with ID: {Id}", result.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error processing rental");
                await responseStream.WriteAsync(new ResponseMessage
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                });
            }
        }
    }
    public override async Task GenerateCar(
        IAsyncStreamReader<RequestCar> requestStream,
        IServerStreamWriter<ResponseMessage> responseStream,
        ServerCallContext context)
    {
        await foreach (var req in requestStream.ReadAllAsync(context.CancellationToken))
        {
            try
            {
                logger.LogInformation("Car received: {LicensePlate}", req.LicensePlate);

                var carDto = new CarsCreateDto(
                    req.Generation,
                    req.LicensePlate,
                    req.Colour
                );

                var result = await carsService.CreateAsync(carDto);

                await responseStream.WriteAsync(new ResponseMessage
                {
                    Success = true,
                    Message = $"Car created with id: {result.Id}"
                });

                logger.LogInformation("Car created with ID: {Id}", result.Id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error processing car");
                await responseStream.WriteAsync(new ResponseMessage
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                });
            }
        }
    }

    public override async Task GenerateClient(
        IAsyncStreamReader<RequestClient> requestStream,
        IServerStreamWriter<ResponseMessage> responseStream,
        ServerCallContext context)
    {
        await foreach (var req in requestStream.ReadAllAsync(context.CancellationToken))
        {
            try
            {
                logger.LogInformation("Client received: {FullName}", req.FullName);

                var clientDto = new ClientsCreateDto(
                    req.DriverLicenseNumber,
                    req.FullName,
                    DateTime.Parse(req.DateOfBirth)
                );

                var result = await clientsService.CreateAsync(clientDto);

                logger.LogInformation("Client created with ID: {Id}", result.Id);

                await responseStream.WriteAsync(new ResponseMessage
                {
                    Success = true,
                    Message = $"Client created with id: {result.Id}"
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error processing client");
                await responseStream.WriteAsync(new ResponseMessage
                {
                    Success = false,
                    Message = $"Error: {ex.Message}"
                });
            }
        }
    }
}
