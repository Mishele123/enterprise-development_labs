using CarRental.Domain;
using CarRental.Domain.Enums;

namespace CarRental.Tests;

public class CarRentalFixture
{
    public List<CarModel> CarModels;
    public List<ModelGeneration> Generations;
    public List<Car> Cars;
    public List<Client> Clients;
    public List<Rental> Rentals;

    public CarRentalFixture()
    {
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
                Name = "BMW X5", 
                DriveType = DriveTypes.AWD, 
                SeatCount = 5,
                BodyType = BodyType.SUV, 
                VehicleClass = VehicleClass.Premium 
            },
            new() { 
                Id = 3, 
                Name = "Honda Civic", 
                DriveType = DriveTypes.FWD, 
                SeatCount = 5, 
                BodyType = BodyType.Sedan, 
                VehicleClass = VehicleClass.Economy
            },
            new() { 
                Id = 4, 
                Name = "Mercedes E-Class", 
                DriveType = DriveTypes.RWD, 
                SeatCount = 5, 
                BodyType = BodyType.Sedan, 
                VehicleClass = VehicleClass.Business 
            },
            new() { 
                Id = 5, 
                Name = "Audi A4", 
                DriveType = DriveTypes.AWD, 
                SeatCount = 5, 
                BodyType = BodyType.Sedan, 
                VehicleClass = VehicleClass.Business 
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
                Name = "Toyota RAV4", 
                DriveType = DriveTypes.AWD, 
                SeatCount = 5, 
                BodyType = BodyType.SUV, 
                VehicleClass = VehicleClass.Comfort 
            },
            new() { 
                Id = 8, 
                Name = "Ford Focus", 
                DriveType = DriveTypes.FWD, 
                SeatCount = 5, 
                BodyType = BodyType.Hatchback, 
                VehicleClass = VehicleClass.Economy 
            },
            new() { 
                Id = 9, 
                Name = "BMW 3 Series", 
                DriveType = DriveTypes.RWD, 
                SeatCount = 5,
                BodyType = BodyType.Sedan, 
                VehicleClass = VehicleClass.Business 
            },
            new() { 
                Id = 10,
                Name = "Mercedes S-Class", 
                DriveType = DriveTypes.RWD, 
                SeatCount = 5, 
                BodyType = BodyType.Sedan, 
                VehicleClass = VehicleClass.Luxury
            }
        };

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
                EngineVolume = 3.0, 
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
                RentalCostPerHour = 18.00m 
            },
            new() { 
                Id = 4, 
                Year = 2023, 
                EngineVolume = 2.0, 
                TransmissionType = TransmissionType.Automatic, 
                Model = CarModels[3], 
                RentalCostPerHour = 35.00m 
            },
            new() { 
                Id = 5, 
                Year = 2022, 
                EngineVolume = 2.0, 
                TransmissionType = TransmissionType.Automatic, 
                Model = CarModels[4], 
                RentalCostPerHour = 32.00m 
            },
            new() { 
                Id = 6, 
                Year = 2021, 
                EngineVolume = 1.4, 
                TransmissionType = TransmissionType.Manual, 
                Model = CarModels[5], 
                RentalCostPerHour = 15.00m 
            },
            new() { 
                Id = 7, 
                Year = 2023, 
                EngineVolume = 2.5, 
                TransmissionType = TransmissionType.Automatic, 
                Model = CarModels[6], 
                RentalCostPerHour = 28.00m 
            },
            new() { 
                Id = 8, 
                Year = 2022, 
                EngineVolume = 2.0, 
                TransmissionType = TransmissionType.Automatic, 
                Model = CarModels[7], 
                RentalCostPerHour = 20.00m 
            },
            new() { 
                Id = 9, 
                Year = 2023, 
                EngineVolume = 2.0, 
                TransmissionType = TransmissionType.Automatic, 
                Model = CarModels[8], 
                RentalCostPerHour = 38.00m 
            },
            new() { 
                Id = 10,
                Year = 2023, 
                EngineVolume = 4.0, 
                TransmissionType = TransmissionType.Automatic, 
                Model = CarModels[9], 
                RentalCostPerHour = 75.00m 
            }
        };

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
                Colour = "Red" 
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
                Colour = "Blue" 
            },
            new() { 
                Id = 6, 
                Generation = Generations[5], 
                LicensePlate = "PQR678", 
                Colour = "Gray" 
            },
            new() { 
                Id = 7, 
                Generation = Generations[6], 
                LicensePlate = "STU901", 
                Colour = "White" 
            },
            new() { 
                Id = 8, 
                Generation = Generations[7], 
                LicensePlate = "VWX234", 
                Colour = "Black" 
            },
            new() { 
                Id = 9, 
                Generation = Generations[8], 
                LicensePlate = "YZA567", 
                Colour = "Red" 
            },
            new() { 
                Id = 10, Generation = Generations[9], 
                LicensePlate = "BCD890", 
                Colour = "Silver" 
            }
        };

        Clients = new List<Client>
        {
            new() { 
                Id = 1, 
                DriverLicenseNumber = "DL001", 
                FullName = "John Smith", 
                DateOfBirth = new DateTime(1985, 5, 15) 
            },
            new() { 
                Id = 2, 
                DriverLicenseNumber = "DL002", 
                FullName = "Emma Johnson", 
                DateOfBirth = new DateTime(1990, 8, 22) 
            },
            new() { 
                Id = 3, 
                DriverLicenseNumber = "DL003", 
                FullName = "Michael Brown", 
                DateOfBirth = new DateTime(1988, 3, 10) 
            },
            new() { 
                Id = 4, 
                DriverLicenseNumber = "DL004", 
                FullName = "Sarah Davis", 
                DateOfBirth = new DateTime(1992, 11, 5) 
            },
            new() { 
                Id = 5, 
                DriverLicenseNumber = "DL005", 
                FullName = "David Wilson", 
                DateOfBirth = new DateTime(1987, 7, 18) 
            },
            new() { 
                Id = 6, 
                DriverLicenseNumber = "DL006", 
                FullName = "Lisa Miller", 
                DateOfBirth = new DateTime(1991, 2, 28) 
            },
            new() { 
                Id = 7, 
                DriverLicenseNumber = "DL007", 
                FullName = "Robert Taylor", 
                DateOfBirth = new DateTime(1986, 9, 12) 
            },
            new() { 
                Id = 8, 
                DriverLicenseNumber = "DL008", 
                FullName = "Jennifer Anderson", 
                DateOfBirth = new DateTime(1993, 6, 25) 
            },
            new() { 
                Id = 9, 
                DriverLicenseNumber = "DL009", 
                FullName = "Daniel Thomas", 
                DateOfBirth = new DateTime(1989, 4, 8) 
            },
            new() { 
                Id = 10,
                DriverLicenseNumber = "DL010", 
                FullName = "Karen White", 
                DateOfBirth = new DateTime(1994, 12, 15) 
            }
        };

        Rentals = new List<Rental>
        {
            new() { 
                Id = 1, CarId = 1, 
                ClientId = 1, 
                IssueTime = DateTime.Now.AddDays(-10), 
                RentalHours = 24 
            },
            new() { 
                Id = 2, 
                CarId = 2, 
                ClientId = 2, 
                IssueTime = DateTime.Now.AddDays(-5), 
                RentalHours = 48 
            },
            new() { 
                Id = 3, 
                CarId = 3, 
                ClientId = 3, 
                IssueTime = DateTime.Now.AddDays(-3),
                RentalHours = 12 
            },
            new() { 
                Id = 4, 
                CarId = 4, 
                ClientId = 4, 
                IssueTime = DateTime.Now.AddDays(-1),
                RentalHours = 6 
            },
            new() { 
                Id = 5, 
                CarId = 5, 
                ClientId = 5, 
                IssueTime = DateTime.Now.AddHours(-2), 
                RentalHours = 8 
            },
            new() { 
                Id = 6, 
                CarId = 6, 
                ClientId = 6, 
                IssueTime = DateTime.Now.AddDays(-7),
                RentalHours = 72 
            },
            new() { 
                Id = 7, 
                CarId = 7, 
                ClientId = 7, 
                IssueTime = DateTime.Now.AddDays(-15), 
                RentalHours = 24 
            },
            new() { 
                Id = 8, 
                CarId = 8, 
                ClientId = 8, 
                IssueTime = DateTime.Now.AddDays(-20), 
                RentalHours = 36 
            },
            new() { 
                Id = 9, 
                CarId = 9, 
                ClientId = 9, 
                IssueTime = DateTime.Now.AddDays(-2), 
                RentalHours = 18 
            },
            new() { 
                Id = 10,
                CarId = 10,
                ClientId = 10,
                IssueTime = DateTime.Now.AddHours(-1), 
                RentalHours = 4 
            },
            new() { 
                Id = 11,
                CarId = 1, 
                ClientId = 2, 
                IssueTime = DateTime.Now.AddDays(-25), 
                RentalHours = 24 
            },
            new() { 
                Id = 12,
                CarId = 2, 
                ClientId = 3, 
                IssueTime = DateTime.Now.AddDays(-30), 
                RentalHours = 48 
            },
            new() { 
                Id = 13,
                CarId = 3, 
                ClientId = 4, 
                IssueTime = DateTime.Now.AddDays(-35), 
                RentalHours = 12 
            },
            new() { 
                Id = 14,
                CarId = 1, 
                ClientId = 5, 
                IssueTime = DateTime.Now.AddDays(-40), 
                RentalHours = 24 
            },
            new() { 
                Id = 15,
                CarId = 2, 
                ClientId = 6, 
                IssueTime = DateTime.Now.AddDays(-45), 
                RentalHours = 36 
            }
        };
    }
}