using System.ComponentModel.DataAnnotations;

namespace car_rental_api.Models;

public class Review
{
    public Guid Id { get; set; }
    [Required]
    public required Rental Rental { get; set; }
    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    public int Rating { get; set; }
    [StringLength(500, MinimumLength = 5, ErrorMessage = "Comment must be between 5 and 500 characters")]
    public string? Comment { get; set; }
}