using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace car_rental_api.Models;

public class User : IdentityUser
{
    [Required]
    [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
    public string LastName { get; set; } = string.Empty;
}