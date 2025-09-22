using CarRental.Domain;

namespace CarRental.Tests;

public class CarRentalTests(CarRentalFixture fixture): IClassFixture<CarRentalFixture>
{
    private readonly CarRentalFixture _fixture = fixture;


    /// <summary>
    /// Display information about all customers who have rented cars of the specified model, 
    /// arrange them by full name
    /// </summary>
    [Fact]
    public void GetClientsByCarModel()
    {
        // Arrange
        var targetModel = "Toyota Camry";

        // Act
        var result = _fixture.Rentals
            .Where(r => r.RentedCar.Generation.Model.Name == targetModel)
            .Select(r => r.Client)
            .Distinct()
            .OrderBy(c => c.FullName)
            .ToList();

        // Assert
        Assert.Single(result);
        Assert.Equal("John Smith", result[0].FullName);
    }

    /// <summary>
    /// Display information about cars that are rented
    /// </summary>
    [Fact]
    public void GetClientsByCarModelMultiply()
    {
        // Arrange - adding additional rentals for the test
        var extraRental = new Rental
        {
            Id = 11,
            IssueTime = new DateTime(2024, 1, 5),
            RentalHours = 24,
            RentedCar = _fixture.Cars[0], // Toyota Camry
            CarId = 1,
            Client = _fixture.Clients[1], // Maria Garcia
            ClientId = 2
        };
        
        var testRentals = _fixture.Rentals.Concat(new[] { extraRental }).ToList();

        // Act
        var result = testRentals
            .Where(r => r.RentedCar.Generation.Model.Name == "Toyota Camry")
            .Select(r => r.Client)
            .Distinct()
            .OrderBy(c => c.FullName)
            .ToList();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("John Smith", result[0].FullName);
        Assert.Equal("Maria Garcia", result[1].FullName);
    }

    /// <summary>
    /// Display information about cars that are rented
    /// </summary>
    [Fact]
    public void GetCarsCurrentlyRented()
    {
        // Arrange
        var currentTime = new DateTime(2024, 1, 1, 20, 0, 0);

        // Act
        var result = _fixture.Rentals
            .Where(r => r.IssueTime.AddHours(r.RentalHours) > currentTime)
            .Select(r => r.RentedCar)
            .Distinct()
            .ToList();

        // Assert
        Assert.Equal(9, result.Count);
    }

    /// <summary>
    /// top 5 most frequently rented cars
    /// </summary>
    [Fact]
    public void GetTop5MostFrequentlyRentedCars()
    {
        // Arrange
        var extraRentals = new List<Rental>
            {
                new() { 
                    Id = 11, IssueTime = new DateTime(2024, 1, 5), 
                    RentalHours = 24, 
                    RentedCar = _fixture.Cars[0], 
                    CarId = 1, 
                    Client = _fixture.Clients[1],
                    ClientId = 2 
                },
                new() { 
                    Id = 12,
                    IssueTime = new DateTime(2024, 1, 6),
                    RentalHours = 48, 
                    RentedCar = _fixture.Cars[0],
                    CarId = 1, 
                    Client = _fixture.Clients[2], 
                    ClientId = 3 
                },
                new() { 
                    Id = 13, 
                    IssueTime = new DateTime(2024, 1, 7), 
                    RentalHours = 12, 
                    RentedCar = _fixture.Cars[1], 
                    CarId = 2, 
                    Client = _fixture.Clients[3], 
                    ClientId = 4 
                }
            };

        var testRentals = _fixture.Rentals.Concat(extraRentals).ToList();

        // Act
        var result = testRentals
            .GroupBy(r => r.RentedCar)
            .Select(g => new { Car = g.Key, RentalCount = g.Count() })
            .OrderByDescending(x => x.RentalCount)
            .Take(5)
            .ToList();

        // Assert
        Assert.Equal(5, result.Count);
        Assert.Equal("ABC123", result[0].Car.LicensePlate); // Toyota Camry - 3
        Assert.Equal(3, result[0].RentalCount);
        Assert.Equal("DEF456", result[1].Car.LicensePlate); // BMW 3 Series - 2
        Assert.Equal(2, result[1].RentalCount);
    }

    /// <summary>
    /// For each car, number of rents
    /// </summary>
    [Fact]
    public void GetRentalCountPerCar()
    {
        // Act
        var result = _fixture.Cars
            .Select(car => new
            {
                Car = car,
                RentalCount = _fixture.Rentals.Count(r => r.RentedCar.Id == car.Id)
            })
            .ToList();

        // Assert
        var toyotaCamry = result.First(x => x.Car.LicensePlate == "ABC123");
        Assert.Equal(1, toyotaCamry.RentalCount);

        var bmw3Series = result.First(x => x.Car.LicensePlate == "DEF456");
        Assert.Equal(1, bmw3Series.RentalCount);
    }


    /// <summary>
    /// top 5 clients by rental amount
    /// </summary>
    [Fact]
    public void GetTop5ClientsByRentalSum()
    {
        // Arrange
        var extraRentals = new List<Rental>
            {
                new() {
                    Id = 11,
                    IssueTime = new DateTime(2024, 1, 5),
                    RentalHours = 100,
                    RentedCar = _fixture.Cars[4], // Mercedes S-Class (95.00/hour)
                    CarId = 5,
                    Client = _fixture.Clients[0], // John Smith
                    ClientId = 1
                }
            };

        var testRentals = _fixture.Rentals.Concat(extraRentals).ToList();

        // Act
        var result = testRentals
            .GroupBy(r => r.Client)
            .Select(g => new
            {
                Client = g.Key,
                TotalRentalCost = g.Sum(r => r.RentalHours * r.RentedCar.Generation.RentalCostPerHour)
            })
            .OrderByDescending(x => x.TotalRentalCost)
            .Take(5)
            .ToList();

        // Assert
        var johnSmith = result.First(x => x.Client.FullName == "John Smith");
        var expectedJohnSum = (24 * 25.50m) + (100 * 95.00m); // Toyota Camry + Mercedes S-Class
        Assert.Equal(expectedJohnSum, johnSmith.TotalRentalCost);
        Assert.True(johnSmith.TotalRentalCost > result[1].TotalRentalCost); // John should be first
    }
}