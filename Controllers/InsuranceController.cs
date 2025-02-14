using car_rental_api.Dtos;
using car_rental_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace car_rental_api.Controllers;

[ApiController]
[Route("[controller]")]
public class InsuranceController : ControllerBase
{
    private readonly  IInsuranceService _insuranceService;

    public InsuranceController(IInsuranceService insuranceService)
    {
        _insuranceService = insuranceService;
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<ActionResult<InsuranceDto>> GetInsuranceById(Guid id)
    {
        try
        {
            InsuranceDto? insuranceDto = await _insuranceService.GetInsuranceByIdAsync(id);
            if (insuranceDto is null) return NotFound(new { message = $"Insurance with ID {id} not found." });
            return Ok(insuranceDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
        }
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<InsuranceDto>>> GetInsurances()
    {
        try
        {
            List<InsuranceDto>? insurances = await _insuranceService.GetInsurancesAsync();
            if(insurances is null)
                return NotFound(new { message = "Insurances not found." });
            return Ok(insurances);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> AddInsurance(InsuranceEditDto insuranceEditDto)
    {
        try
        {
            InsuranceDto insuranceDto = await _insuranceService.AddInsuranceAsync(insuranceEditDto);
            return Ok(insuranceDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
        }
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> UpdateInsurance(Guid id, InsuranceEditDto insuranceEditDto)
    {
        try
        {
            InsuranceDto? insuranceDto = await _insuranceService.UpdateInsuranceAsync(id, insuranceEditDto);
            if(insuranceDto is null)
                return NotFound(new { message = $"Insurance with ID {id} not found." });
            return Ok(insuranceDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteInsurance(Guid id)
    {
        try
        {
            await _insuranceService.DeleteInsuranceAsync(id);
            return Ok(new { message = $"Insurance with ID {id} deleted." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
        }
    }
}