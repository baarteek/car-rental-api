using System.ComponentModel.DataAnnotations;

namespace car_rental_api.Dtos;

public class LoginDto
{
    [Required]
    [EmailAddress]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
    public required string Email { get; set; }
    [Required]
    //[MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
    [MaxLength(100, ErrorMessage = "Password cannot exceed 100 characters.")]
    public required string Password { get; set; }
}