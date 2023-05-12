
using CRM_CryptoSystem.BusinessLayer.Models;
using CRM_CryptoSystem.BusinessLayer.Services.Interfaces;
using CRM_CryptoSystem.DataLayer.Interfaces;
using CRM_CryptoSystem.DataLayer.Models;
using Microsoft.Extensions.Logging;

namespace CRM_CryptoSystem.BusinessLayer.Services;

public class AccountsService : IAccountsService
{
    private readonly IAccountsRepository _accountsRepository;
    private readonly ILeadsRepository _leadsRepository;
    private ILogger<AccountsService> _logger;

    public AccountsService(IAccountsRepository accountsRepository, ILeadsRepository leadsRepository, ILogger<AccountsService> logger)
    {
        _accountsRepository = accountsRepository;
        _leadsRepository = leadsRepository;
        _logger = logger;
    }

    public Task<int> Add(AccountDto accountDTO, ClaimModel claim)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrRestore(int id, ClaimModel claim)
    {
        throw new NotImplementedException();
    }

    public Task<List<AccountDto>> GetAllByLeadId(int id, ClaimModel claim)
    {
        throw new NotImplementedException();
    }

    public Task<AccountDto> GetById(int id, ClaimModel calim)
    {
        throw new NotImplementedException();
    }

    public Task Update(AccountDto accountDTO, int id, ClaimModel claim)
    {
        throw new NotImplementedException();
    }
}
