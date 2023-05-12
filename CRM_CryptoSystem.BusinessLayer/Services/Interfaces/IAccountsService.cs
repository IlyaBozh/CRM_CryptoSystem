
using CRM_CryptoSystem.BusinessLayer.Models;
using CRM_CryptoSystem.DataLayer.Models;

namespace CRM_CryptoSystem.BusinessLayer.Services.Interfaces;

public interface IAccountsService
{
    public Task<int> Add(AccountDto accountDTO, ClaimModel claim);
    public Task DeleteOrRestore(int id, ClaimModel claim);
    public Task<List<AccountDto>> GetAllByLeadId(int LeadId, ClaimModel claim);
    public Task<AccountDto> GetById(int id, ClaimModel claim);
    public Task Update(AccountDto accountDTO, int id, ClaimModel claim);
}
