using car_rental_api.Data;
using car_rental_api.Models;
using car_rental_api.Repositories.Interfaces;

namespace car_rental_api.Repositories.Implementations;

public class PaymentRepository : Repository<Payment>, IPaymentRepository
{
    public PaymentRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    
}