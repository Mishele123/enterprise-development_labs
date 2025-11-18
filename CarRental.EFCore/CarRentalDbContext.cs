using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.EFCore;
public class CarRentalDBContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<CarModel> CarModels { get; set; }
    public DbSet<ModelGeneration> Generations { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<RentalCar> Rentals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(builder =>
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.LicensePlate).HasMaxLength(20);
            builder.Property(c => c.Colour).HasMaxLength(50);

            builder.HasOne(c => c.Generation)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();
        });

        modelBuilder.Entity<CarModel>(builder =>
        {
            builder.HasKey(cm => cm.Id);
            builder.Property(cm => cm.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<ModelGeneration>(builder =>
        {
            builder.HasKey(mg => mg.Id);
            builder.Property(mg => mg.EngineVolume).HasPrecision(3, 1);
            builder.Property(mg => mg.RentalCostPerHour).HasPrecision(10, 2);

            builder.HasOne(mg => mg.Model)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();
        });

        modelBuilder.Entity<Client>(builder =>
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.DriverLicenseNumber).HasMaxLength(50);
            builder.Property(c => c.FullName).HasMaxLength(200);
        });

        modelBuilder.Entity<RentalCar>(builder =>
        {
            builder.HasKey(rc => rc.Id);

            builder.HasOne(rc => rc.RentedCar)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();

            builder.HasOne(rc => rc.Client)
                   .WithMany()
                   .OnDelete(DeleteBehavior.Restrict)
                   .IsRequired();
        });
    }

    private static void Seed(ModelBuilder b)
    {
        // CarModels
        b.Entity<CarModel>().HasData(
            new()
            {
                Id = 1,
                Name = "Toyota Camry",
                DriveType = DriveTypes.Fwd,
                SeatCount = 5,
                BodyType = BodyTypes.Sedan,
                VehicleClass = VehicleClasses.Comfort
            },
            new()
            {
                Id = 2,
                Name = "BMW 3 Series",
                DriveType = DriveTypes.Rwd,
                SeatCount = 5,
                BodyType = BodyTypes.Sedan,
                VehicleClass = VehicleClasses.Business
            },
            new()
            {
                Id = 3,
                Name = "Honda Civic",
                DriveType = DriveTypes.Fwd,
                SeatCount = 5,
                BodyType = BodyTypes.Sedan,
                VehicleClass = VehicleClasses.Economy
            },
            new()
            {
                Id = 4,
                Name = "Audi Q7",
                DriveType = DriveTypes.Awd,
                SeatCount = 7,
                BodyType = BodyTypes.Suv,
                VehicleClass = VehicleClasses.Premium
            },
            new()
            {
                Id = 5,
                Name = "Mercedes S-Class",
                DriveType = DriveTypes.Rwd,
                SeatCount = 5,
                BodyType = BodyTypes.Sedan,
                VehicleClass = VehicleClasses.Luxury
            },
            new()
            {
                Id = 6,
                Name = "Volkswagen Golf",
                DriveType = DriveTypes.Fwd,
                SeatCount = 5,
                BodyType = BodyTypes.Hatchback,
                VehicleClass = VehicleClasses.Economy
            },
            new()
            {
                Id = 7,
                Name = "Ford Focus",
                DriveType = DriveTypes.Fwd,
                SeatCount = 5,
                BodyType = BodyTypes.Hatchback,
                VehicleClass = VehicleClasses.Economy
            },
            new()
            {
                Id = 8,
                Name = "Toyota RAV4",
                DriveType = DriveTypes.Awd,
                SeatCount = 5,
                BodyType = BodyTypes.Suv,
                VehicleClass = VehicleClasses.Comfort
            },
            new()
            {
                Id = 9,
                Name = "BMW X5",
                DriveType = DriveTypes.Awd,
                SeatCount = 5,
                BodyType = BodyTypes.Suv,
                VehicleClass = VehicleClasses.Premium
            },
            new()
            {
                Id = 10,
                Name = "Toyota Sienna",
                DriveType = DriveTypes.Fwd,
                SeatCount = 8,
                BodyType = BodyTypes.Minivan,
                VehicleClass = VehicleClasses.Comfort
            }
        );

        // Generations
        b.Entity<ModelGeneration>().HasData(
            new()
            {
                Id = 1,
                Year = 2022,
                EngineVolume = 2.5,
                TransmissionType = TransmissionTypes.Automatic,
                ModelId = 1,
                RentalCostPerHour = 25.50m
            },
            new()
            {
                Id = 2,
                Year = 2023,
                EngineVolume = 2.0,
                TransmissionType = TransmissionTypes.Automatic,
                ModelId = 2,
                RentalCostPerHour = 45.00m
            },
            new()
            {
                Id = 3,
                Year = 2021,
                EngineVolume = 1.8,
                TransmissionType = TransmissionTypes.Manual,
                ModelId = 3,
                RentalCostPerHour = 18.75m
            },
            new()
            {
                Id = 4,
                Year = 2023,
                EngineVolume = 3.0,
                TransmissionType = TransmissionTypes.Automatic,
                ModelId = 4,
                RentalCostPerHour = 65.00m
            },
            new()
            {
                Id = 5,
                Year = 2022,
                EngineVolume = 3.5,
                TransmissionType = TransmissionTypes.Automatic,
                ModelId = 5,
                RentalCostPerHour = 95.00m
            },
            new()
            {
                Id = 6,
                Year = 2021,
                EngineVolume = 1.6,
                TransmissionType = TransmissionTypes.Manual,
                ModelId = 6,
                RentalCostPerHour = 16.50m
            },
            new()
            {
                Id = 7,
                Year = 2022,
                EngineVolume = 2.0,
                TransmissionType = TransmissionTypes.Automatic,
                ModelId = 7,
                RentalCostPerHour = 19.25m
            },
            new()
            {
                Id = 8,
                Year = 2023,
                EngineVolume = 2.5,
                TransmissionType = TransmissionTypes.Automatic,
                ModelId = 8,
                RentalCostPerHour = 28.00m
            },
            new()
            {
                Id = 9,
                Year = 2022,
                EngineVolume = 3.0,
                TransmissionType = TransmissionTypes.Automatic,
                ModelId = 9,
                RentalCostPerHour = 72.50m
            },
            new()
            {
                Id = 10,
                Year = 2021,
                EngineVolume = 3.5,
                TransmissionType = TransmissionTypes.Automatic,
                ModelId = 10,
                RentalCostPerHour = 32.00m
            }
        );

        // Cars
        b.Entity<Car>().HasData(
            new()
            {
                Id = 1,
                GenerationId = 1,
                LicensePlate = "ABC123",
                Colour = "White"
            },
            new()
            {
                Id = 2,
                GenerationId = 2,
                LicensePlate = "DEF456",
                Colour = "Black"
            },
            new()
            {
                Id = 3,
                GenerationId = 3,
                LicensePlate = "GHI789",
                Colour = "Blue"
            },
            new()
            {
                Id = 4,
                GenerationId = 4,
                LicensePlate = "JKL012",
                Colour = "Silver"
            },
            new()
            {
                Id = 5,
                GenerationId = 5,
                LicensePlate = "MNO345",
                Colour = "Black"
            },
            new()
            {
                Id = 6,
                GenerationId = 6,
                LicensePlate = "PQR678",
                Colour = "Red"
            },
            new()
            {
                Id = 7,
                GenerationId = 7,
                LicensePlate = "STU901",
                Colour = "Gray"
            },
            new()
            {
                Id = 8,
                GenerationId = 8,
                LicensePlate = "VWX234",
                Colour = "White"
            },
            new()
            {
                Id = 9,
                GenerationId = 9,
                LicensePlate = "YZA567",
                Colour = "Blue"
            },
            new()
            {
                Id = 10,
                GenerationId = 10,
                LicensePlate = "BCD890",
                Colour = "Silver"
            }
        );

        // Clients
        b.Entity<Client>().HasData(
            new()
            {
                Id = 1,
                DriverLicenseNumber = "DL12345678",
                FullName = "John Smith",
                DateOfBirth = new DateTime(1985, 5, 15)
            },
            new()
            {
                Id = 2,
                DriverLicenseNumber = "DL23456789",
                FullName = "Maria Garcia",
                DateOfBirth = new DateTime(1990, 8, 22)
            },
            new()
            {
                Id = 3,
                DriverLicenseNumber = "DL34567890",
                FullName = "David Johnson",
                DateOfBirth = new DateTime(1988, 3, 10)
            },
            new()
            {
                Id = 4,
                DriverLicenseNumber = "DL45678901",
                FullName = "Sarah Wilson",
                DateOfBirth = new DateTime(1992, 11, 5)
            },
            new()
            {
                Id = 5,
                DriverLicenseNumber = "DL56789012",
                FullName = "Michael Brown",
                DateOfBirth = new DateTime(1987, 7, 30)
            },
            new()
            {
                Id = 6,
                DriverLicenseNumber = "DL67890123",
                FullName = "Emily Davis",
                DateOfBirth = new DateTime(1995, 2, 14)
            },
            new()
            {
                Id = 7,
                DriverLicenseNumber = "DL78901234",
                FullName = "Robert Miller",
                DateOfBirth = new DateTime(1983, 9, 18)
            },
            new()
            {
                Id = 8,
                DriverLicenseNumber = "DL89012345",
                FullName = "Lisa Anderson",
                DateOfBirth = new DateTime(1991, 6, 25)
            },
            new()
            {
                Id = 9,
                DriverLicenseNumber = "DL90123456",
                FullName = "James Taylor",
                DateOfBirth = new DateTime(1989, 12, 8)
            },
            new()
            {
                Id = 10,
                DriverLicenseNumber = "DL01234567",
                FullName = "Jennifer Martinez",
                DateOfBirth = new DateTime(1993, 4, 20)
            }
        );

        // Rentals
        var baseDate = new DateTime(2025, 11, 18);
        b.Entity<RentalCar>().HasData(
            new()
            {
                Id = 1,
                IssueTime = baseDate.AddHours(2),
                RentalHours = 24,
                RentedCarId = 1,
                ClientId = 1
            },
            new()
            {
                Id = 2,
                IssueTime = baseDate.AddHours(5),
                RentalHours = 48,
                RentedCarId = 2,
                ClientId = 2
            },
            new()
            {
                Id = 3,
                IssueTime = baseDate.AddHours(8),
                RentalHours = 12,
                RentedCarId = 3,
                ClientId = 3
            },
            new()
            {
                Id = 4,
                IssueTime = baseDate.AddHours(12),
                RentalHours = 72,
                RentedCarId = 4,
                ClientId = 4
            },
            new()
            {
                Id = 5,
                IssueTime = baseDate.AddHours(18),
                RentalHours = 6,
                RentedCarId = 5,
                ClientId = 5
            },
            new()
            {
                Id = 6,
                IssueTime = baseDate.AddDays(1),
                RentalHours = 36,
                RentedCarId = 6,
                ClientId = 6
            },
            new()
            {
                Id = 7,
                IssueTime = baseDate.AddDays(1).AddHours(6),
                RentalHours = 24,
                RentedCarId = 7,
                ClientId = 7
            },
            new()
            {
                Id = 8,
                IssueTime = baseDate.AddDays(2),
                RentalHours = 96,
                RentedCarId = 8,
                ClientId = 8
            },
            new()
            {
                Id = 9,
                IssueTime = baseDate.AddDays(2).AddHours(4),
                RentalHours = 18,
                RentedCarId = 9,
                ClientId = 9
            },
            new()
            {
                Id = 10,
                IssueTime = baseDate.AddDays(3),
                RentalHours = 60,
                RentedCarId = 10,
                ClientId = 10
            },
            new()
            {
                Id = 11,
                IssueTime = new DateTime(2025, 10, 29),
                RentalHours = 24,
                RentedCarId = 1,
                ClientId = 2
            },
            new()
            {
                Id = 12,
                IssueTime = new DateTime(2025, 10, 30),
                RentalHours = 48,
                RentedCarId = 1,
                ClientId = 3
            },
            new()
            {
                Id = 13,
                IssueTime = new DateTime(2025, 10, 31),
                RentalHours = 12,
                RentedCarId = 2,
                ClientId = 4
            },
            new()
            {
                Id = 14,
                IssueTime = new DateTime(2025, 10, 29),
                RentalHours = 100,
                RentedCarId = 5,
                ClientId = 1
            }
        );
    }
}