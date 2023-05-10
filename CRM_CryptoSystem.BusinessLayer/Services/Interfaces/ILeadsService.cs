
using CRM_CryptoSystem.BusinessLayer.Models;
using CRM_CryptoSystem.DataLayer.Models;

namespace CRM_CryptoSystem.BusinessLayer.Services.Interfaces;

public interface ILeadsService
{
    Task<int> Add(LeadDto lead);
    Task DeleteOrRestore(int id, bool isDeleted, ClaimModel claims);
    Task<List<LeadDto>> GetAll();
    Task<LeadDto> GetAllInfoById(int id, ClaimModel claims);
    Task<LeadDto?> GetByEmail(string email);
    Task<LeadDto> GetById(int id, ClaimModel claims);
    Task Update(LeadDto lead, int id, ClaimModel claims);
}
