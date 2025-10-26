using System.ComponentModel.DataAnnotations;
namespace CarRental.Application.Contracts.Clients;

/// <summary>
/// DTO create client
/// </summary>
/// <param name="DriverLicenseNumber">Driver License number</param>
/// <param name="FullName">Full name</param>
/// <param name="DateOfBirth">Date of birth</param>
public record ClientsCreateDto(
    string DriverLicenseNumber,
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Full name must be between 2 and 50 characters")]
    string FullName,
    [Range(1960, 2007, ErrorMessage = "Birth Date must be between 1960 and 2007")]
    DateTime DateOfBirth
);