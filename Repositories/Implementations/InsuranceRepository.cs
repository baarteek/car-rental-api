using car_rental_api.Data;
using car_rental_api.Models;
using car_rental_api.Repositories.Interfaces;

namespace car_rental_api.Repositories.Implementations;

public class InsuranceRepository : Repository<Insurance>, IInsuranceRepository
{
    public InsuranceRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    
}