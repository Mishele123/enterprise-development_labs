using CarRental.Grpc.Producer.Grpc;
using CarRental.Grpc.Producer.Utils;
using CarRental.Grpc.Protos;
using Grpc.Net.Client;


var builder = Host.CreateApplicationBuilder(args);

builder.Logging.AddConsole();

builder.Services.AddSingleton<Generator>();

builder.Services.AddHostedService<Producer>();

builder.Services.AddSingleton(serviceProvider =>
{
    var grpcServiceUrl = builder.Configuration.GetValue<string>("services:api:https:0")
        ?? "https://localhost:7133";
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

await host.RunAsync();