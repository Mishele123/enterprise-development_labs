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
    DateTime DateOfBirth
);