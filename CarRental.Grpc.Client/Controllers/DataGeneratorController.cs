using Grpc.Core;
using CarRental.Grpc.Protos;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Grpc.Client.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class DataGeneratorController(
    ContractGeneratorService.ContractGeneratorServiceClient client,
    ILogger<DataGeneratorController> logger
) : ControllerBase
{

}
