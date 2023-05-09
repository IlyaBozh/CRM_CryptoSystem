
using CRM_CryptoSystem.DataLayer.Interfaces;
using CRM_CryptoSystem.DataLayer.Models;
using Microsoft.Extensions.Logging;
using System.Data;

namespace CRM_CryptoSystem.DataLayer.Repositories;

public class AccountsRepository : BaseRepository, IAccountsRepository
{
    private readonly ILogger<AccountsRepository> _logger;

    public AccountsRepository(IDbConnection dbConnection, ILogger<AccountsRepository> logger) : base(dbConnection)
    {
        _logger = logger;
    }

    public Task<int> Add(AccountDto accountDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteOrRestore(int id, bool isDeleted)
    {
        throw new NotImplementedException();
    }

    public Task<List<AccountDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<List<AccountDto>> GetAllByLeadId(int leadId)
    {
        throw new NotImplementedException();
    }

    public Task<AccountDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(AccountDto accountDto, int id)
    {
        throw new NotImplementedException();
    }
}
