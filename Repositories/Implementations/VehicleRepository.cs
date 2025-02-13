using car_rental_api.Data;
using car_rental_api.Models;
using car_rental_api.Repositories.Interfaces;

namespace car_rental_api.Repositories.Implementations;

public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
{
    public VehicleRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    
}