
using CRM_CryptoSystem.DataLayer.Interfaces;
using CRM_CryptoSystem.DataLayer.Models;
using Dapper;
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

    public async Task<int> Add(AccountDto accountDto)
    {
        _logger.LogInformation($"Data Layer: Add account: {accountDto.LeadId}, {accountDto.Currency}, {accountDto.Status}");

        var id = await _connectionString.QuerySingleAsync<int>(
            StoredProcedures.Account_Add,
            param: new
            {
                accountDto.LeadId,
                accountDto.Currency,
                accountDto.Status
            },
            commandType: System.Data.CommandType.StoredProcedure);

        return id;
    }

    public async Task DeleteOrRestore(int id, bool isDeleted)
    {
        if (isDeleted)
            _logger.LogInformation($"Data Layer: Delete account {id}");
        else
            _logger.LogInformation($"Data Layer: Restore account {id}");
        
        await _connectionString.ExecuteAsync(
                StoredProcedures.Account_Delete,
                param: new { id, isDeleted },
                commandType: System.Data.CommandType.StoredProcedure);
    }

    public async Task<List<AccountDto>> GetAll()
    {
        _logger.LogInformation($"Data Layer: Get all accounts");
        var accounts = _connectionString.Query<AccountDto>(
            StoredProcedures.Lead_GetAll,
            commandType: System.Data.CommandType.StoredProcedure)
            .ToList();

        return accounts;
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
