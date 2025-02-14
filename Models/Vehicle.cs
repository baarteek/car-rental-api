using System.ComponentModel.DataAnnotations;
using car_rental_api.Models.Enums;

namespace car_rental_api.Models;

public class Vehicle
{
    public Guid Id { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Vehicle Name must be between 2 and 50 characters")]
    public required string Brand { get; set; }
    [Required]
    [StringLength(70, MinimumLength = 2, ErrorMessage = "Vehicle Name must be between 2 and 70 characters")]
    public required string Model { get; set; }
    [Range(1900, 2025, ErrorMessage = "Year must be between 1900 and the current year.")]
    public int YearOfManufacture { get; set; }
    [Required]
    [StringLength(15, MinimumLength = 5, ErrorMessage = "Registration number must be between 5 and 15 characters.")]
    [RegularExpression(@"^[A-Z0-9\s-]+$", ErrorMessage = "Registration number can contain only uppercase letters, numbers, spaces, and hyphens.")]
    public required string RegistrationNumber { get; set; }
    [Required]
    public VehicleStatus Status { get; set; }
    [Range(0.01, double.MaxValue, ErrorMessage = "Price per day must be greater than 0.")]
    public double PricePerDay { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "Mileage must be a positive number.")]
    public int Mileage { get; set; }
    [Range(1, 50, ErrorMessage = "Number of seats must be between 1 and 50.")]
    public int NumberOfSeats { get; set; }
    [Range(0.1, 15.0, ErrorMessage = "Engine capacity must be between 0.1 and 15.0 liters.")]
    public double EngineCapacity { get; set; }
    [Range(1, 2000, ErrorMessage = "Engine power must be between 1 and 2000 HP.")]
    public int EnginePower { get; set; }
    [StringLength(255, ErrorMessage = "Image path cannot exceed 255 characters.")]
    public string? ImagePath { get; set; }

}