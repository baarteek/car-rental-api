using car_rental_api.Dtos;
using car_rental_api.Models;
using car_rental_api.Repositories.Interfaces;
using car_rental_api.Services.Interfaces;

namespace car_rental_api.Services.Implementations;

public class InsuranceService : IInsuranceService
{
    private readonly IInsuranceRepository _insuranceRepository;

    public InsuranceService(IInsuranceRepository insuranceRepository)
    {
        _insuranceRepository = insuranceRepository;
    }
    
    public async Task<InsuranceDto?> GetInsuranceByIdAsync(Guid id)
    {
        Insurance? insurance = await _insuranceRepository.GetByIdAsync(id);
        if (insurance is null)  return null;

        return new InsuranceDto
        {
            Id = insurance.Id,
            Name = insurance.Name,
            Description = insurance.Description,
            PricePerDay = insurance.PricePerDay,
        };
    }

    public async Task<List<InsuranceDto>?> GetInsurancesAsync()
    {
        List<Insurance> insurances = await _insuranceRepository.GetAllAsync();
        List<InsuranceDto> insuranceDtos = new List<InsuranceDto>();
        foreach (Insurance insurance in insurances)
        {
            InsuranceDto insuranceDto = new InsuranceDto
            {
                Id = insurance.Id,
                Name = insurance.Name,
                Description = insurance.Description,
                PricePerDay = insurance.PricePerDay,
            };
            insuranceDtos.Add(insuranceDto);
        }
        return insuranceDtos;
    }

    public async Task<InsuranceDto> AddInsuranceAsync(InsuranceEditDto insuranceEditDto)
    {
        Insurance insurance = new Insurance
        {
            Id = Guid.NewGuid(),
            Name = insuranceEditDto.Name,
            Description = insuranceEditDto.Description,
            PricePerDay = insuranceEditDto.PricePerDay,
        };
        
        await _insuranceRepository.AddAsync(insurance);

        return new InsuranceDto
        {
            Id = insurance.Id,
            Name = insurance.Name,
            Description = insurance.Description,
            PricePerDay = insurance.PricePerDay,
        };
    }

    public async Task<InsuranceDto?> UpdateInsuranceAsync(Guid id, InsuranceEditDto insuranceEditDto)
    {
        Insurance? insurance = await _insuranceRepository.GetByIdAsync(id);
        if (insurance is null) return null;
        
        insurance.Name = insuranceEditDto.Name;
        insurance.Description = insuranceEditDto.Description;
        insurance.PricePerDay = insuranceEditDto.PricePerDay;
        
        await _insuranceRepository.UpdateAsync(insurance);
        
        return new InsuranceDto
        {
            Id = insurance.Id,
            Name = insurance.Name,
            Description = insurance.Description,
            PricePerDay = insurance.PricePerDay,
        };
    }

    public async Task DeleteInsuranceAsync(Guid id)
    {
        await _insuranceRepository.DeleteAsync(id);
    }
}