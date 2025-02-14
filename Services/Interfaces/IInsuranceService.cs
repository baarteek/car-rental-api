using car_rental_api.Dtos;

namespace car_rental_api.Services.Interfaces;

public interface IInsuranceService
{
    Task<InsuranceDto?> GetInsuranceByIdAsync(Guid id);
    Task<List<InsuranceDto>?> GetInsurancesAsync();
    Task<InsuranceDto> AddInsuranceAsync(InsuranceEditDto insuranceEditDto);
    Task<InsuranceDto?> UpdateInsuranceAsync(Guid id, InsuranceEditDto insuranceEditDto);
    Task DeleteInsuranceAsync(Guid id);
}