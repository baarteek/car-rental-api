using System.ComponentModel.DataAnnotations;

namespace car_rental_api.Models;

public class Rental
{
    public Guid Id { get; set; }
    [Required]
    public required User User { get; set; }
    [Required]
    public required Vehicle Vehicle { get; set; }
    public Insurance? Insurance { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [StringLength(500, MinimumLength = 5, ErrorMessage = "Comment length must be between 5 and 500 characters.")]
    public string? Comment { get; set; }
}