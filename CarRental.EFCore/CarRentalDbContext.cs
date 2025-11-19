using CarRental.Domain.Entities;
using CarRental.Domain.Enums;
using CarRental.EFCore.Seed;
using Microsoft.EntityFrameworkCore;

namespace CarRental.EFCore;
public class CarRentalDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<CarModel> CarModels { get; set; }
    public DbSet<ModelGeneration> Generations { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<RentalCar> Rentals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarModel>().ToTable("car_models");
        modelBuilder.Entity<ModelGeneration>().ToTable("model_generations");
        modelBuilder.Entity<Car>().ToTable("cars");
        modelBuilder.Entity<Client>().ToTable("clients");
        modelBuilder.Entity<RentalCar>().ToTable("rentals");

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
}