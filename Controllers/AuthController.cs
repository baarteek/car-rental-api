using car_rental_api.Dtos;
using car_rental_api.Models;
using car_rental_api.Services.Implementations;
using car_rental_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace car_rental_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var user = new User { FirstName = registerDto.FirstName, LastName = registerDto.LastName, Email = registerDto.Email, PhoneNumber = registerDto.PhoneNumber, UserName = registerDto.FirstName + "_" + registerDto.LastName };
        var result = await _authService.RegisterUserAsync(user, registerDto.Password);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }
        return Ok("User registered Successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var token = await _authService.LoginUserAsync(loginDto.Email, loginDto.Password);
        if (token is null)
        {
            return Unauthorized("Invalid credentials");
        }
        return Ok(new { Token = token });
    }
}