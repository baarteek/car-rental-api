namespace car_rental_api.Dtos;

public class InsuranceDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double PricePerDay { get; set; }
}