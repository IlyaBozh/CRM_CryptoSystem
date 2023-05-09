
using CRM_CryptoSystem.DataLayer.Models;

namespace CRM_CryptoSystem.DataLayer.Interfaces;

public interface IAccountsRepository
{
    public Task<int> Add(AccountDto accountDto);
    public Task DeleteOrRestore(int id, bool isDeleted);
    public Task<List<AccountDto>> GetAll();
    public Task<List<AccountDto>> GetAllByLeadId(int leadId);
    public Task<AccountDto> GetById(int id);
    public Task Update (AccountDto accountDto, int id);
}
