using System.ComponentModel.DataAnnotations;

namespace car_rental_api.Models;

public class Insurance
{
    public Guid Id { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Insurance Name must be between 3 and 50 characters")]
    public required string Name { get; set; }
    [StringLength(1000, MinimumLength = 10, ErrorMessage = "Insurance Description must be between 10 and 1000 characters")]
    public string? Description { get; set; }
    [Required]
    [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public double PricePerDay { get; set; }
}