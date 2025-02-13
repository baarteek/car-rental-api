using car_rental_api.Data;
using car_rental_api.Models;
using car_rental_api.Repositories.Interfaces;

namespace car_rental_api.Repositories.Implementations;

public class RentalRepository : Repository<Rental>, IRentalRepository
{
    public RentalRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    
}