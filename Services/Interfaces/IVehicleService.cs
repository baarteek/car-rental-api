using car_rental_api.Dtos;

namespace car_rental_api.Services.Interfaces;

public interface IVehicleService
{
    Task<VehicleDto> GetVehicleByIdAsync(Guid id);
    Task<List<VehicleDto>> GetVehiclesAsync();
    Task AddVehicleAsync(VehicleEditDto vehicleEditDto);
    Task UpdateVehicleAsync(VehicleEditDto vehicleEditDto);
    Task DeleteVehicleAsync(Guid id);
}