using CarRental.Grpc.Protos;
using CarRental.Grpc.Server.Grpc;
using CarRental.Grpc.Server.Utils;
using Grpc.Net.Client;


var builder = Host.CreateApplicationBuilder(args);

builder.Logging.AddConsole();

builder.Services.AddSingleton<Generator>();

builder.Services.AddHostedService<Producer>();

builder.Services.AddSingleton(serviceProvider =>
{
    var grpcServiceUrl = "https://localhost:7133";
    var httpHandler = new HttpClientHandler();

    if (builder.Environment.IsDevelopment())
    {
        httpHandler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
    }

    var channel = GrpcChannel.ForAddress(grpcServiceUrl, new GrpcChannelOptions
    {
        HttpHandler = httpHandler,
        DisposeHttpClient = true
    });

    return new ContractGeneratorService.ContractGeneratorServiceClient(channel);
});

var host = builder.Build();

try
{
    var client = host.Services
        .GetRequiredService<ContractGeneratorService.ContractGeneratorServiceClient>();
    Console.WriteLine("gRPC клиент успешно создан");
}
catch (Exception ex)
{
    Console.WriteLine($"Ошибка создания gRPC клиента: {ex.Message}");
}

await host.RunAsync();