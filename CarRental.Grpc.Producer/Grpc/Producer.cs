using CarRental.Grpc.Producer.Utils;
using CarRental.Grpc.Protos;
using Grpc.Core;


namespace CarRental.Grpc.Producer.Grpc;

public class Producer(
    ContractGeneratorService.ContractGeneratorServiceClient client,
    ILogger<Producer> logger,
    Generator generator,
    IConfiguration config
) : BackgroundService
{
    private readonly TimeSpan _delay = TimeSpan.FromSeconds(
        config.GetValue<int?>("ProducerDelaySeconds") ?? 1);
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var rentalStream = client.GenerateRental(cancellationToken: stoppingToken);
        using var carStream = client.GenerateCar(cancellationToken: stoppingToken);
        using var clientStream = client.GenerateClient(cancellationToken: stoppingToken);

        var sendTask = Task.Run(async () =>
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var rental = generator.GenerateRandomRental();
                logger.LogInformation("Sending rental request: CarId={CarId}, ClientId={ClientId}, Hours={RentalHours}",
                    rental.CarId, rental.ClientId, rental.RentalHours);
                await rentalStream.RequestStream.WriteAsync(rental);
                await Task.Delay(_delay, stoppingToken);

                if (stoppingToken.IsCancellationRequested) break;

                var car = generator.GenerateRandomCar();
                logger.LogInformation("Sending car request: LicensePlate={LicensePlate}, Colour={Colour}, Generation={Generation}",
                    car.LicensePlate, car.Colour, car.Generation);
                await carStream.RequestStream.WriteAsync(car);
                await Task.Delay(_delay, stoppingToken);

                if (stoppingToken.IsCancellationRequested) break;
                
                var clientRequest = generator.GenerateRandomClient();
                logger.LogInformation("Sending client request: Name={FullName}, License={DriverLicenseNumber}",
                    clientRequest.FullName, clientRequest.DriverLicenseNumber);
                await clientStream.RequestStream.WriteAsync(clientRequest);
                await Task.Delay(_delay, stoppingToken);
            }
            
            await rentalStream.RequestStream.CompleteAsync();
            await carStream.RequestStream.CompleteAsync();
            await clientStream.RequestStream.CompleteAsync();

        }, stoppingToken);

        var receiveTask = Task.WhenAll(
            Task.Run(async () =>
            {
                await foreach (var response in rentalStream.ResponseStream.ReadAllAsync(stoppingToken))
                    logger.LogInformation("Received rental response: Success={Success}, Message={Message}",
                        response.Success, response.Message);
            }, stoppingToken),

            Task.Run(async () =>
            {
                await foreach (var response in carStream.ResponseStream.ReadAllAsync(stoppingToken))
                    logger.LogInformation("Received car response: Success={Success}, Message={Message}",
                        response.Success, response.Message);
            }, stoppingToken),

            Task.Run(async () =>
            {
                await foreach (var response in clientStream.ResponseStream.ReadAllAsync(stoppingToken))
                    logger.LogInformation("Received client response: Success={Success}, Message={Message}",
                        response.Success, response.Message);
            }, stoppingToken)
        );

        await sendTask;
        await receiveTask;
    }
}