using CRM_CryptoSystem.DataLayer.Models;

namespace CRM_CryptoSystem.DataLayer.Interfaces;

public interface ILeadsRepository
{
    Task<int> Add(LeadDto leadDto);
    Task DeleteOrRestore(int id, bool isDeleting);
    Task<List<LeadDto>> GetAll();
    Task<LeadDto> GetAllInfoById(int id);
    Task<LeadDto> GetByEmail(string email);
    Task<LeadDto> GetById(int id);
    Task Update(LeadDto leadDto);
}
