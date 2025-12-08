using Bogus;
using CarRental.Grpc.Protos;


namespace CarRental.Grpc.Server.Utils;

public class Generator
{
    public RequestRental GenerateRandomRental(int maxClientId = 10, int maxCarId = 10) =>
        new Faker<RequestRental>()
            .RuleFor(r => r.ClientId, f => f.Random.Int(1, maxClientId))
            .RuleFor(r => r.CarId, f => f.Random.Int(1, maxCarId))
            .RuleFor(r => r.IssueTime, f => f.Date.Recent().ToString("O"))
            .RuleFor(r => r.RentalHours, f => f.Random.Int(1, 72))
            .Generate();

    public RequestCar GenerateRandomCar(int maxGeneration = 10) =>
        new Faker<RequestCar>()
            .RuleFor(c => c.Generation, f => f.Random.Int(1, maxGeneration))
            .RuleFor(c => c.LicensePlate, f => f.Vehicle.Vin()[..8].ToUpper())
            .RuleFor(c => c.Colour, f => f.Commerce.Color())
            .Generate();

    public RequestClient GenerateRandomClient() =>
        new Faker<RequestClient>()
            .RuleFor(c => c.DriverLicenseNumber, f => f.Random.Replace("?###??"))
            .RuleFor(c => c.FullName, f => f.Name.FullName())
            .RuleFor(c => c.DateOfBirth, f => 
                f.Date.Past(50, DateTime.Today.AddYears(-18)).ToString("yyyy-MM-dd"))
            .Generate();
}
