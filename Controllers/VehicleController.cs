using car_rental_api.Dtos;
using car_rental_api.Models;
using car_rental_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace car_rental_api.Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<VehicleDto>> GetVehicleById(Guid id)
    {
        try
        {
            VehicleDto? vehicleDto = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicleDto is null)
            {
                return NotFound(new { message = $"Vehicle with {id} not found." });
            }
            return Ok(vehicleDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<VehicleDto>>> GetVehicles()
    {
        try
        {
            List<VehicleDto>? vehicleDtos = await _vehicleService.GetVehiclesAsync();
            if (vehicleDtos is null)
            {
                return NotFound(new { message = "Vehicles not found." });
            }
            return Ok(vehicleDtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> AddVehicle(VehicleEditDto vehicleEditDto)
    {
        try
        {
            VehicleDto createdVehicle = await _vehicleService.AddVehicleAsync(vehicleEditDto);
            return Ok(createdVehicle);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
        }
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> UpdateVehicle(Guid id, VehicleEditDto vehicleEditDto)
    {
        try
        {
            VehicleDto updatedVehicle = await _vehicleService.UpdateVehicleAsync(vehicleEditDto);
            return Ok(updatedVehicle);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteVehicle(Guid id)
    {
        try
        {
            await _vehicleService.DeleteVehicleAsync(id);
            return Ok(new { message = "Data was deleted successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
        }
    }
}