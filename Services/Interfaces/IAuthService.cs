using car_rental_api.Models;
using Microsoft.AspNetCore.Identity;

namespace car_rental_api.Services.Interfaces;

public interface IAuthService
{
    Task<IdentityResult> RegisterUserAsync(User user, string password);
    Task<string?> LoginUserAsync(string email, string password);
}