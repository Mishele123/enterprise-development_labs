using CarRental.Domain;
using CarRental.Domain.Enums;

namespace CarRental.Tests;

/// <summary>
/// A fixture for providing test data to all tests
/// </summary>
public class CarRentalFixture
{
    public List<CarModel> CarModels;
    public List<ModelGeneration> Generations;
    public List<Car> Cars;
    public List<Client> Clients;
    public List<Rental> Rentals;

    /// <summary>
    /// Initializing test data
    /// </summary>
    public CarRentalFixture()
    {
        // Initialize CarModels
        CarModels = new List<CarModel>
        {
            new() { 
                Id = 1, 
                Name = "Toyota Camry", 
                DriveType = DriveTypes.FWD, 
                SeatCount = 5, 
                BodyType = BodyType.Sedan, 
                VehicleClass = VehicleClass.Comfort 
            },
            new() { 
                Id = 2, 
                Name = "BMW 3 Series", 
                DriveType = DriveTypes.RWD, 
                SeatCount = 5, 
                BodyType = BodyType.Sedan, 
                VehicleClass = VehicleClass.Business 
            },
            new() { 
                Id = 3, 
                Name = "Honda Civic", 
                DriveType = DriveTypes.FWD, 
                SeatCount = 5, 
                BodyType = BodyType.Sedan, 
                VehicleClass = 
                VehicleClass.Economy 
            },
            new() { 
                Id = 4, 
                Name = "Audi Q7", 
                DriveType = DriveTypes.AWD, 
                SeatCount = 7, 
                BodyType = BodyType.SUV, 
                VehicleClass = VehicleClass.Premium 
            },
            new() { 
                Id = 5, 
                Name = "Mercedes S-Class",
                DriveType = DriveTypes.RWD, 
                SeatCount = 5, 
                BodyType = BodyType.Sedan, 
                VehicleClass = VehicleClass.Luxury 
            },
            new() { 
                Id = 6, 
                Name = "Volkswagen Golf", 
                DriveType = DriveTypes.FWD, 
                SeatCount = 5, 
                BodyType = BodyType.Hatchback, 
                VehicleClass = VehicleClass.Economy 
            },
            new() { 
                Id = 7, 
                Name = "Ford Focus", 
                DriveType = DriveTypes.FWD, 
                SeatCount = 5, 
                BodyType = BodyType.Hatchback, 
                VehicleClass = VehicleClass.Economy 
            },
            new() { 
                Id = 8, 
                Name = "Toyota RAV4", 
                DriveType = DriveTypes.AWD, 
                SeatCount = 5, 
                BodyType = BodyType.SUV, 
                VehicleClass = VehicleClass.Comfort 
            },
            new() { 
                Id = 9, 
                Name = "BMW X5", 
                DriveType = DriveTypes.AWD, 
                SeatCount = 5, 
                BodyType = BodyType.SUV, 
                VehicleClass = VehicleClass.Premium 
            },
            new() { 
                Id = 10,
                Name = "Toyota Sienna", 
                DriveType = DriveTypes.FWD, 
                SeatCount = 8, 
                BodyType = BodyType.Minivan, 
                VehicleClass = VehicleClass.Comfort 
            }
        };

        // Initialize Generations
        Generations = new List<ModelGeneration>
        {
            new() { 
                Id = 1, 
                Year = 2022, 
                EngineVolume = 2.5, 
                TransmissionType = TransmissionType.Automatic, 
                Model = CarModels[0], 
                RentalCostPerHour = 25.50m 
            },
            new() { 
                Id = 2, 
                Year = 2023, 
                EngineVolume = 2.0, 
                TransmissionType = TransmissionType.Automatic, 
                Model = CarModels[1], 
                RentalCostPerHour = 45.00m 
            },
            new() { 
                Id = 3, 
                Year = 2021, 
                EngineVolume = 1.8, 
                TransmissionType = TransmissionType.Manual, 
                Model = CarModels[2], 
                RentalCostPerHour = 18.75m 
            },
            new() { 
                Id = 4, 
                Year = 2023, 
                EngineVolume = 3.0, 
                TransmissionType = TransmissionType.Automatic, 
                Model = CarModels[3], 
                RentalCostPerHour = 65.00m 
            },
            new() { 
                Id = 5, 
                Year = 2022, 
                EngineVolume = 3.5, 
                TransmissionType = TransmissionType.Automatic, 
                Model = CarModels[4], 
                RentalCostPerHour = 95.00m 
            },
            new() { 
                Id = 6, 
                Year = 2021, 
                EngineVolume = 1.6, 
                TransmissionType = TransmissionType.Manual, 
                Model = CarModels[5], 
                RentalCostPerHour = 16.50m 
            },
            new() { 
                Id = 7, 
                Year = 2022, 
                EngineVolume = 2.0, 
                TransmissionType = TransmissionType.Automatic, 
                Model = CarModels[6], 
                RentalCostPerHour = 19.25m 
            },
            new() { 
                Id = 8, 
                Year = 2023, 
                EngineVolume = 2.5, 
                TransmissionType = TransmissionType.Automatic, 
                Model = CarModels[7], 
                RentalCostPerHour = 28.00m 
            },
            new() { 
                Id = 9, 
                Year = 2022, 
                EngineVolume = 3.0, 
                TransmissionType = TransmissionType.Automatic, 
                Model = CarModels[8], 
                RentalCostPerHour = 72.50m 
            },
            new() { 
                Id = 10,
                Year = 2021, 
                EngineVolume = 3.5, 
                TransmissionType = TransmissionType.Automatic, 
                Model = CarModels[9], 
                RentalCostPerHour = 32.00m 
            }
        };

        // Initialize Cars
        Cars = new List<Car>
        {
            new() { 
                Id = 1, 
                Generation = Generations[0], 
                LicensePlate = "ABC123", 
                Colour = "White" 
            },
            new() { 
                Id = 2, 
                Generation = Generations[1], 
                LicensePlate = "DEF456", 
                Colour = "Black" 
            },
            new() { 
                Id = 3, 
                Generation = Generations[2], 
                LicensePlate = "GHI789", 
                Colour = "Blue" 
            },
            new() { 
                Id = 4, 
                Generation = Generations[3], 
                LicensePlate = "JKL012", 
                Colour = "Silver" 
            },
            new() { 
                Id = 5, 
                Generation = Generations[4], 
                LicensePlate = "MNO345", 
                Colour = "Black" 
            },
            new() { 
                Id = 6, 
                Generation = Generations[5], 
                LicensePlate = "PQR678", 
                Colour = "Red" 
            },
            new() { 
                Id = 7, 
                Generation = Generations[6], 
                LicensePlate = "STU901", 
                Colour = "Gray" 
            },
            new() { 
                Id = 8, 
                Generation = Generations[7], 
                LicensePlate = "VWX234", 
                Colour = "White" 
            },
            new() { 
                Id = 9, 
                Generation = Generations[8], 
                LicensePlate = "YZA567", 
                Colour = "Blue" 
            },
            new() { 
                Id = 10, 
                Generation = Generations[9], 
                LicensePlate = "BCD890", 
                Colour = "Silver" 
            }
        };

        // Initialize Clients
        Clients = new List<Client>
        {
            new() { 
                Id = 1,
                DriverLicenseNumber = "DL12345678", 
                FullName = "John Smith", 
                DateOfBirth = new DateTime(1985, 5, 15) 
            },
            new() { 
                Id = 2,
                DriverLicenseNumber = "DL23456789", 
                FullName = "Maria Garcia", 
                DateOfBirth = new DateTime(1990, 8, 22) 
            },
            new() { 
                Id = 3,
                DriverLicenseNumber = "DL34567890", 
                FullName = "David Johnson", 
                DateOfBirth = new DateTime(1988, 3, 10) 
            },
            new() { 
                Id = 4,
                DriverLicenseNumber = "DL45678901", 
                FullName = "Sarah Wilson", 
                DateOfBirth = new DateTime(1992, 11, 5) 
            },
            new() { 
                Id = 5,
                DriverLicenseNumber = "DL56789012", 
                FullName = "Michael Brown", 
                DateOfBirth = new DateTime(1987, 7, 30) 
            },
            new() { 
                Id = 6,
                DriverLicenseNumber = "DL67890123", 
                FullName = "Emily Davis", 
                DateOfBirth = new DateTime(1995, 2, 14) 
            },
            new() { 
                Id = 7,
                DriverLicenseNumber = "DL78901234", 
                FullName = "Robert Miller", 
                DateOfBirth = new DateTime(1983, 9, 18) 
            },
            new() { 
                Id = 8,
                DriverLicenseNumber = "DL89012345", 
                FullName = "Lisa Anderson", 
                DateOfBirth = new DateTime(1991, 6, 25) 
            },
            new() { 
                Id = 9,
                DriverLicenseNumber = "DL90123456", 
                FullName = "James Taylor", 
                DateOfBirth = new DateTime(1989, 12, 8) 
            },
            new() { 
                Id = 10, 
                DriverLicenseNumber = "DL01234567", 
                FullName = "Jennifer Martinez", 
                DateOfBirth = new DateTime(1993, 4, 20) 
            }
        };

        // Initialize Rentals
        var baseDate = new DateTime(2024, 1, 1);
        Rentals = new List<Rental>
        {
            new() { 
                Id = 1, 
                IssueTime = baseDate.AddHours(2), 
                RentalHours = 24, 
                RentedCar = Cars[0], 
                CarId = 1, 
                Client = Clients[0], 
                ClientId = 1 
            },
            new() { 
                Id = 2, 
                IssueTime = baseDate.AddHours(5),
                RentalHours = 48, 
                RentedCar = Cars[1], 
                CarId = 2, 
                Client = Clients[1], 
                ClientId = 2 
            },
            new() { 
                Id = 3, 
                IssueTime = baseDate.AddHours(8),
                RentalHours = 12,
                RentedCar = Cars[2], 
                CarId = 3, 
                Client = Clients[2], 
                ClientId = 3 
            },
            new() { 
                Id = 4, 
                IssueTime = baseDate.AddHours(12), 
                RentalHours = 72, 
                RentedCar = Cars[3], 
                CarId = 4, 
                Client = Clients[3], 
                ClientId = 4 
            },
            new() { 
                Id = 5, 
                IssueTime = baseDate.AddHours(18), 
                RentalHours = 6, 
                RentedCar = Cars[4], 
                CarId = 5, 
                Client = Clients[4], 
                ClientId = 5 
            },
            new() { 
                Id = 6, 
                IssueTime = baseDate.AddDays(1), 
                RentalHours = 36, 
                RentedCar = Cars[5], 
                CarId = 6, 
                Client = Clients[5], 
                ClientId = 6 
            },
            new() { 
                Id = 7, 
                IssueTime = baseDate.AddDays(1).AddHours(6), 
                RentalHours = 24, 
                RentedCar = Cars[6], 
                CarId = 7, 
                Client = Clients[6], 
                ClientId = 7 
            },
            new() { 
                Id = 8, 
                IssueTime = baseDate.AddDays(2), 
                RentalHours = 96, 
                RentedCar = Cars[7], 
                CarId = 8, 
                Client = Clients[7], 
                ClientId = 8 
            },
            new() { 
                Id = 9, 
                IssueTime = baseDate.AddDays(2).AddHours(4), 
                RentalHours = 18, 
                RentedCar = Cars[8], 
                CarId = 9, 
                Client = Clients[8], 
                ClientId = 9 
            },
            new() { 
                Id = 10,
                IssueTime = baseDate.AddDays(3),
                RentalHours = 60, 
                RentedCar = Cars[9], 
                CarId = 10, 
                Client = Clients[9], 
                ClientId = 10 
            }
        };
    }
}