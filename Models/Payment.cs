using System.ComponentModel.DataAnnotations;
using car_rental_api.Models.Enums;

namespace car_rental_api.Models;

public class Payment
{
    public Guid Id { get; set; }
    [Required]
    public required Rental Rental { get; set; }
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
    public double Amount { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime PaymentDate { get; set; }
    [Required]
    public PaymentMethod PaymentMethod { get; set; }
    [Required]
    public bool IsPaid { get; set; }
}