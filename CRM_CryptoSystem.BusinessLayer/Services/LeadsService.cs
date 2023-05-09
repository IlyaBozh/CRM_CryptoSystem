using CRM_CryptoSystem.BusinessLayer.Models;
using CRM_CryptoSystem.BusinessLayer.Services.Interfaces;
using CRM_CryptoSystem.DataLayer.Interfaces;
using CRM_CryptoSystem.DataLayer.Models;

namespace CRM_CryptoSystem.BusinessLayer.Services;

public class LeadsService : ILeadsService
{
    private readonly ILeadsRepository _leadsRepository;
    public Task<int> Add(LeadDto lead)
    {
        throw new NotImplementedException();
    }

    public Task<LeadDto> DeleteOrRestore(int id, bool isDeleted, ClaimModel claims)
    {
        throw new NotImplementedException();
    }

    public Task<List<LeadDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<LeadDto> GetAllInfoById(int id, ClaimModel claims)
    {
        throw new NotImplementedException();
    }

    public Task<LeadDto?> GetByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<LeadDto> GetById(int id, ClaimModel claims)
    {
        throw new NotImplementedException();
    }

    public Task Update(LeadDto lead, int id, ClaimModel claims)
    {
        throw new NotImplementedException();
    }
}
