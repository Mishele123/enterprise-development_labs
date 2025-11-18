using CarRental.EFCore.Seed;

namespace CarRental.EFCore;

public class DbSeederService(CarRentalDbContext context)
{

    public void Seed(bool forceReset = false)
    {
        if (forceReset)
        {
            context.Rentals.RemoveRange(context.Rentals);
            context.Cars.RemoveRange(context.Cars);
            context.Clients.RemoveRange(context.Clients);
            context.Generations.RemoveRange(context.Generations);
            context.CarModels.RemoveRange(context.CarModels);
            context.SaveChanges();
        }

        if (!forceReset && context.CarModels.Any())
            return;

        var seed = new DbSeeder();

        context.CarModels.AddRange(seed.CarModels);
        context.SaveChanges();

        context.Generations.AddRange(seed.Generations);
        context.SaveChanges();

        context.Clients.AddRange(seed.Clients);
        context.SaveChanges();

        context.Cars.AddRange(seed.Cars);
        context.SaveChanges();

        context.Rentals.AddRange(seed.Rentals);
        context.SaveChanges();
    }
}