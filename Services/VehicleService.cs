using car_rental_api.Dtos;
using car_rental_api.Models;
using car_rental_api.Repositories.Implementations;
using car_rental_api.Repositories.Interfaces;
using car_rental_api.Services.Interfaces;

namespace car_rental_api.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleService(VehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }
    
    public async Task<VehicleDto> GetVehicleByIdAsync(Guid id)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(id);
        if (vehicle is null)
        {
            throw new Exception($"Vehicle with id {id} not found");
        }

        return new VehicleDto
        {
            Id = vehicle.Id,
            Brand = vehicle.Brand,
            Model = vehicle.Model,
            YearOfManufacture = vehicle.YearOfManufacture,
            RegistrationNumber = vehicle.RegistrationNumber,
            PricePerDay = vehicle.PricePerDay,
            Mileage = vehicle.Mileage,
            NumberOfSeats = vehicle.NumberOfSeats,
            EngineCapacity = vehicle.EngineCapacity,
            EnginePower = vehicle.EnginePower,
        };
    }

    public async Task<List<VehicleDto>> GetVehiclesAsync()
    {
        List<Vehicle> vehicles = await _vehicleRepository.GetAllAsync();
        List <VehicleDto> vehicleDtos = new List<VehicleDto>();
        foreach (Vehicle vehicle in vehicles)
        {
            VehicleDto vehicleDto = new VehicleDto
            {

                Brand = vehicle.Brand,
                Model = vehicle.Model,
                YearOfManufacture = vehicle.YearOfManufacture,
                RegistrationNumber = vehicle.RegistrationNumber,
                PricePerDay = vehicle.PricePerDay,
                Mileage = vehicle.Mileage,
                NumberOfSeats = vehicle.NumberOfSeats,
                EngineCapacity = vehicle.EngineCapacity,
                EnginePower = vehicle.EnginePower,
            };
            vehicleDtos.Add(vehicleDto);
        }
        return vehicleDtos;
    }

    public Task AddVehicleAsync(VehicleEditDto vehicleEditDto)
    {
        Vehicle vehicle = new Vehicle
        {
            Id = vehicleEditDto.Id,
            Brand = vehicleEditDto.Brand,
            Model = vehicleEditDto.Model,
            YearOfManufacture = vehicleEditDto.YearOfManufacture,
            RegistrationNumber = vehicleEditDto.RegistrationNumber,
            PricePerDay = vehicleEditDto.PricePerDay,
            Mileage = vehicleEditDto.Mileage,
            NumberOfSeats = vehicleEditDto.NumberOfSeats,
            EngineCapacity = vehicleEditDto.EngineCapacity,
            EnginePower = vehicleEditDto.EnginePower,
        };
        return _vehicleRepository.AddAsync(vehicle);
    }

    public Task UpdateVehicleAsync(VehicleEditDto vehicleEditDto)
    {
        Vehicle vehicle = new Vehicle
        {
            Id = vehicleEditDto.Id,
            Brand = vehicleEditDto.Brand,
            Model = vehicleEditDto.Model,
            YearOfManufacture = vehicleEditDto.YearOfManufacture,
            RegistrationNumber = vehicleEditDto.RegistrationNumber,
            PricePerDay = vehicleEditDto.PricePerDay,
            Mileage = vehicleEditDto.Mileage,
            NumberOfSeats = vehicleEditDto.NumberOfSeats,
            EngineCapacity = vehicleEditDto.EngineCapacity,
            EnginePower = vehicleEditDto.EnginePower,
        };
        return _vehicleRepository.UpdateAsync(vehicle);
    }

    public async Task DeleteVehicleAsync(Guid id)
    {
        await _vehicleRepository.DeleteAsync(id);
    }
}