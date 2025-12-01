﻿namespace CarRental.Application.Contracts.Cars;

/// <summary>
/// DTO for get requests to Cars
/// </summary>
/// <param name="Id">Car id</param>
/// <param name="GenerationId">Generation</param>
/// <param name="ModelId"></param>
/// <param name="LicensePlate">License plate</param>
/// <param name="Colour">Car colour</param>
public record CarsDto(
    int Id,
    int GenerationId,
    int ModelId,
    string LicensePlate,
    string Colour
);