using CarRental.Domain.Seed;

namespace CarRental.Tests;

public class CarRentalTests(Seeder fixture) : IClassFixture<Seeder>
{
    /// <summary>
    /// Display information about all customers who have rented cars of the specified model, 
    /// arrange them by full name
    /// </summary>
    [Fact]
    public void GetClientsByCarModel()
    {
        // Arrange
        var targetModel = "Toyota Camry";
        var expectedCount = 3;
        var expectedFirstClient = "David Johnson";
        var expectedSecondClient = "John Smith";

        // Act
        var result = fixture.Rentals
            .Where(r => r.RentedCar.Generation.Model.Name == targetModel)
            .Select(r => r.Client)
            .Distinct()
            .OrderBy(c => c.FullName)
            .ToList();

        // Assert
        Assert.Equal(expectedCount, result.Count);
        Assert.Equal(expectedFirstClient, result[0].FullName);
        Assert.Equal(expectedSecondClient, result[1].FullName);
    }

    /// <summary>
    /// Display information about cars that are rented
    /// </summary>
    [Fact]
    public void GetCarsCurrentlyRented()
    {
        // Arrange
        var currentTime = new DateTime(2025, 10, 27, 20, 0, 0);
        var expectedRentedCarsCount = 9;

        // Act
        var result = fixture.Rentals
            .Where(r => r.IssueTime.AddHours(r.RentalHours) > currentTime)
            .Select(r => r.RentedCar)
            .Distinct()
            .ToList();

        // Assert
        Assert.Equal(expectedRentedCarsCount, result.Count);
    }

    /// <summary>
    /// top 5 most frequently rented cars
    /// </summary>
    [Fact]
    public void GetTop5MostFrequentlyRentedCars()
    {
        // Arrange
        var expectedCount = 5;
        var expectedTopCarLicensePlate = "ABC123";
        var expectedTopCarRentalCount = 3;
        var expectedSecondCarLicensePlate = "DEF456";
        var expectedSecondCarRentalCount = 2;

        // Act
        var result = fixture.Rentals
            .GroupBy(r => r.RentedCar)
            .Select(g => new { Car = g.Key, RentalCount = g.Count() })
            .OrderByDescending(x => x.RentalCount)
            .Take(5)
            .ToList();

        // Assert
        Assert.Equal(expectedCount, result.Count);
        Assert.Equal(expectedTopCarLicensePlate, result[0].Car.LicensePlate);
        Assert.Equal(expectedTopCarRentalCount, result[0].RentalCount);
        Assert.Equal(expectedSecondCarLicensePlate, result[1].Car.LicensePlate);
        Assert.Equal(expectedSecondCarRentalCount, result[1].RentalCount);
    }

    /// <summary>
    /// For each car, number of rents
    /// </summary>
    [Fact]
    public void GetRentalCountPerCar()
    {
        // Arrange
        var toyotaCamryLicensePlate = "ABC123";
        var expectedToyotaRentalCount = 3;
        var bmw3SeriesLicensePlate = "DEF456";
        var expectedBmwRentalCount = 2;

        // Act
        var result = fixture.Cars
            .Select(car => new
            {
                Car = car,
                RentalCount = fixture.Rentals.Count(r => r.RentedCar.Id == car.Id)
            })
            .ToList();

        // Assert
        var toyotaCamry = result.First(x => x.Car.LicensePlate == toyotaCamryLicensePlate);
        Assert.Equal(expectedToyotaRentalCount, toyotaCamry.RentalCount);

        var bmw3Series = result.First(x => x.Car.LicensePlate == bmw3SeriesLicensePlate);
        Assert.Equal(expectedBmwRentalCount, bmw3Series.RentalCount);
    }

    /// <summary>
    /// top 5 clients by rental amount
    /// </summary>
    [Fact]
    public void GetTop5ClientsByRentalSum()
    {
        // Arrange
        var johnSmithName = "John Smith";
        var expectedJohnSum = 10112m;
        var expectedTopClientsCount = 5;

        // Act
        var result = fixture.Rentals
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
        Assert.Equal(expectedTopClientsCount, result.Count);
        var johnSmith = result.First(x => x.Client.FullName == johnSmithName);
        Assert.Equal(expectedJohnSum, johnSmith.TotalRentalCost);
    }
}