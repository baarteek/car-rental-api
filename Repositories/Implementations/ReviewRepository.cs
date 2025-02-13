using car_rental_api.Data;
using car_rental_api.Models;
using car_rental_api.Repositories.Interfaces;

namespace car_rental_api.Repositories.Implementations;

public class ReviewRepository : Repository<Review>, IReviewRepository
{
    public ReviewRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    
}