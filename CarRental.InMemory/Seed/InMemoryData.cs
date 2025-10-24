using CarRental.Domain.Entities;
using CarRental.Domain.Enums;
namespace CarRental.InMemory.Seed;

/// <summary>
/// In Memory data
/// </summary>
public class InMemoryData
{
    public readonly List<CarModel> CarModels;
    public readonly List<ModelGeneration> Generations;
    public readonly List<Car> Cars;
    public readonly List<Client> Clients;
    public readonly List<RentalCar> Rentals;

    /// <summary>
    /// Initializing test data
    /// </summary>
    public InMemoryData()
    {
        // Initialize CarModels
        CarModels =
        [
            new() {
                Id = 1,
                Name = "Toyota Camry",
                DriveType = DriveTypes.Fwd,
                SeatCount = 5,
                BodyType = BodyTypes.Sedan,
                VehicleClass = VehicleClasses.Comfort
            },
            new() {
                Id = 2,
                Name = "BMW 3 Series",
                DriveType = DriveTypes.Rwd,
                SeatCount = 5,
                BodyType = BodyTypes.Sedan,
                VehicleClass = VehicleClasses.Business
            },
            new() {
                Id = 3,
                Name = "Honda Civic",
                DriveType = DriveTypes.Fwd,
                SeatCount = 5,
                BodyType = BodyTypes.Sedan,
                VehicleClass =
                VehicleClasses.Economy
            },
            new() {
                Id = 4,
                Name = "Audi Q7",
                DriveType = DriveTypes.Awd,
                SeatCount = 7,
                BodyType = BodyTypes.Suv,
                VehicleClass = VehicleClasses.Premium
            },
            new() {
                Id = 5,
                Name = "Mercedes S-Class",
                DriveType = DriveTypes.Rwd,
                SeatCount = 5,
                BodyType = BodyTypes.Sedan,
                VehicleClass = VehicleClasses.Luxury
            },
            new() {
                Id = 6,
                Name = "Volkswagen Golf",
                DriveType = DriveTypes.Fwd,
                SeatCount = 5,
                BodyType = BodyTypes.Hatchback,
                VehicleClass = VehicleClasses.Economy
            },
            new() {
                Id = 7,
                Name = "Ford Focus",
                DriveType = DriveTypes.Fwd,
                SeatCount = 5,
                BodyType = BodyTypes.Hatchback,
                VehicleClass = VehicleClasses.Economy
            },
            new() {
                Id = 8,
                Name = "Toyota RAV4",
                DriveType = DriveTypes.Awd,
                SeatCount = 5,
                BodyType = BodyTypes.Suv,
                VehicleClass = VehicleClasses.Comfort
            },
            new() {
                Id = 9,
                Name = "BMW X5",
                DriveType = DriveTypes.Awd,
                SeatCount = 5,
                BodyType = BodyTypes.Suv,
                VehicleClass = VehicleClasses.Premium
            },
            new() {
                Id = 10,
                Name = "Toyota Sienna",
                DriveType = DriveTypes.Fwd,
                SeatCount = 8,
                BodyType = BodyTypes.Minivan,
                VehicleClass = VehicleClasses.Comfort
            }
        ];

        // Initialize Generations
        Generations =
        [
            new() {
                Id = 1,
                Year = 2022,
                EngineVolume = 2.5,
                TransmissionType = TransmissionTypes.Automatic,
                Model = CarModels[0],
                RentalCostPerHour = 25.50m
            },
            new() {
                Id = 2,
                Year = 2023,
                EngineVolume = 2.0,
                TransmissionType = TransmissionTypes.Automatic,
                Model = CarModels[1],
                RentalCostPerHour = 45.00m
            },
            new() {
                Id = 3,
                Year = 2021,
                EngineVolume = 1.8,
                TransmissionType = TransmissionTypes.Manual,
                Model = CarModels[2],
                RentalCostPerHour = 18.75m
            },
            new() {
                Id = 4,
                Year = 2023,
                EngineVolume = 3.0,
                TransmissionType = TransmissionTypes.Automatic,
                Model = CarModels[3],
                RentalCostPerHour = 65.00m
            },
            new() {
                Id = 5,
                Year = 2022,
                EngineVolume = 3.5,
                TransmissionType = TransmissionTypes.Automatic,
                Model = CarModels[4],
                RentalCostPerHour = 95.00m
            },
            new() {
                Id = 6,
                Year = 2021,
                EngineVolume = 1.6,
                TransmissionType = TransmissionTypes.Manual,
                Model = CarModels[5],
                RentalCostPerHour = 16.50m
            },
            new() {
                Id = 7,
                Year = 2022,
                EngineVolume = 2.0,
                TransmissionType = TransmissionTypes.Automatic,
                Model = CarModels[6],
                RentalCostPerHour = 19.25m
            },
            new() {
                Id = 8,
                Year = 2023,
                EngineVolume = 2.5,
                TransmissionType = TransmissionTypes.Automatic,
                Model = CarModels[7],
                RentalCostPerHour = 28.00m
            },
            new() {
                Id = 9,
                Year = 2022,
                EngineVolume = 3.0,
                TransmissionType = TransmissionTypes.Automatic,
                Model = CarModels[8],
                RentalCostPerHour = 72.50m
            },
            new() {
                Id = 10,
                Year = 2021,
                EngineVolume = 3.5,
                TransmissionType = TransmissionTypes.Automatic,
                Model = CarModels[9],
                RentalCostPerHour = 32.00m
            }
        ];

        // Initialize Cars
        Cars =
        [
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
        ];

        // Initialize Clients
        Clients =
        [
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
        ];

        // Initialize Rentals
        var baseDate = new DateTime(2024, 1, 1);
        Rentals =
        [
            new() {
                Id = 1,
                IssueTime = baseDate.AddHours(2),
                RentalHours = 24,
                RentedCar = Cars[0],
                Client = Clients[0],
            },
            new() {
                Id = 2,
                IssueTime = baseDate.AddHours(5),
                RentalHours = 48,
                RentedCar = Cars[1],
                Client = Clients[1],
            },
            new() {
                Id = 3,
                IssueTime = baseDate.AddHours(8),
                RentalHours = 12,
                RentedCar = Cars[2],
                Client = Clients[2],
            },
            new() {
                Id = 4,
                IssueTime = baseDate.AddHours(12),
                RentalHours = 72,
                RentedCar = Cars[3],
                Client = Clients[3],
            },
            new() {
                Id = 5,
                IssueTime = baseDate.AddHours(18),
                RentalHours = 6,
                RentedCar = Cars[4],
                Client = Clients[4],
            },
            new() {
                Id = 6,
                IssueTime = baseDate.AddDays(1),
                RentalHours = 36,
                RentedCar = Cars[5],
                Client = Clients[5],
            },
            new() {
                Id = 7,
                IssueTime = baseDate.AddDays(1).AddHours(6),
                RentalHours = 24,
                RentedCar = Cars[6],
                Client = Clients[6],
            },
            new() {
                Id = 8,
                IssueTime = baseDate.AddDays(2),
                RentalHours = 96,
                RentedCar = Cars[7],
                Client = Clients[7],
            },
            new() {
                Id = 9,
                IssueTime = baseDate.AddDays(2).AddHours(4),
                RentalHours = 18,
                RentedCar = Cars[8],
                Client = Clients[8],
            },
            new() {
                Id = 10,
                IssueTime = baseDate.AddDays(3),
                RentalHours = 60,
                RentedCar = Cars[9],
                Client = Clients[9],
            },
            new() {
                Id = 11,
                IssueTime = new DateTime(2024, 1, 5),
                RentalHours = 24,
                RentedCar = Cars[0],
                Client = Clients[1],
            },
            new() {
                Id = 12,
                IssueTime = new DateTime(2024, 1, 6),
                RentalHours = 48,
                RentedCar = Cars[0],
                Client = Clients[2],
            },
            new() {
                Id = 13,
                IssueTime = new DateTime(2024, 1, 7),
                RentalHours = 12,
                RentedCar = Cars[1],
                Client = Clients[3],
            },
            new() {
                Id = 14,
                IssueTime = new DateTime(2024, 1, 5),
                RentalHours = 100,
                RentedCar = Cars[4],
                Client = Clients[0],
            }
        ];
    }
}