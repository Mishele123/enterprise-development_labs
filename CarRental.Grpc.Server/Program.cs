using CarRental.Grpc.Protos;
using CarRental.Grpc.Server.Grpc;
using CarRental.Grpc.Server.Utils;
using Grpc.Net.Client;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSingleton<Generator>();

builder.Services.AddHostedService<Producer>();

builder.Services.AddSingleton(serviceProvider =>
{
    var apiGrpcUrl = builder.Configuration["GrpcServer:Address"]
        ?? throw new InvalidOperationException("GrpcServer:Address not found");

    var channel = GrpcChannel.ForAddress(apiGrpcUrl);
    return new ContractGeneratorService.ContractGeneratorServiceClient(channel);
});

var host = builder.Build();

host.Services.GetRequiredService<ContractGeneratorService.ContractGeneratorServiceClient>();

host.Run();