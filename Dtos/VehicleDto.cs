namespace car_rental_api.Dtos;

public class VehicleDto
{
    public Guid Id { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public int YearOfManufacture { get; set; }
    public string? RegistrationNumber { get; set; }
    public string? Status { get; set; }
    public double PricePerDay { get; set; }
    public int Mileage { get; set; }
    public int NumberOfSeats { get; set; }
    public double EngineCapacity { get; set; }
    public int EnginePower { get; set; }
}