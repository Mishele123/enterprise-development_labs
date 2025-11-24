using CarRental.Domain.Seed;
using Microsoft.EntityFrameworkCore;

namespace CarRental.EFCore;

public class DbSeederService(CarRentalDbContext context)
{
    public async Task SeedAsync(bool forceReset = false)
    {
        if (forceReset)
        {
            context.Rentals.RemoveRange(context.Rentals);
            context.Cars.RemoveRange(context.Cars);
            context.Clients.RemoveRange(context.Clients);
            context.Generations.RemoveRange(context.Generations);
            context.CarModels.RemoveRange(context.CarModels);
            await context.SaveChangesAsync();
        }

        if (!forceReset && await context.CarModels.AnyAsync())
            return;

        var seed = new Seeder();

        context.CarModels.AddRange(seed.CarModels);
        await context.SaveChangesAsync();

        context.Generations.AddRange(seed.Generations);
        await context.SaveChangesAsync();

        context.Clients.AddRange(seed.Clients);
        await context.SaveChangesAsync();

        context.Cars.AddRange(seed.Cars);
        await context.SaveChangesAsync();

        context.Rentals.AddRange(seed.Rentals);
        await context.SaveChangesAsync();
    }
}