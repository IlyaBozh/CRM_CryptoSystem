
using CRM_CryptoSystem.DataLayer.Interfaces;
using CRM_CryptoSystem.DataLayer.Models;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Security.Principal;

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
                accountDto.Currency,
                accountDto.Status,
                accountDto.LeadId
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
        var accounts = (await _connectionString.QueryAsync<AccountDto>(
            StoredProcedures.Lead_GetAll,
            commandType: System.Data.CommandType.StoredProcedure))
            .ToList();

        return accounts;
    }

    public async Task<List<AccountDto>> GetAllByLeadId(int leadId)
    {
        _logger.LogInformation($"Data Layer: Get all accounts by lead id: {leadId}");

        var accounts = ( await _connectionString.QueryAsync<AccountDto>(
            StoredProcedures.Account_GetAllAccountsByLeadId,
            param: new { leadId },
            commandType: System.Data.CommandType.StoredProcedure)) .ToList();

        return accounts;
    }

    public async Task<AccountDto> GetById(int id)
    {
        var account = (await _connectionString.QueryAsync(
            StoredProcedures.Account_GetById,
            param: new { id },
            commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();

        _logger.LogInformation($"Data Layer: Get account by id: {account.LeadId}, {account.Currency}, {account.Status}");

        return account;
    }

    public async Task Update(AccountDto accountDto, int id)
    {
        _logger.LogInformation($"Data Layer: Get account by id {id}: {accountDto.Status}");

        await _connectionString.ExecuteAsync(
            StoredProcedures.Account_Update,
            param: new { id, accountDto.Status },
            commandType: System.Data.CommandType.StoredProcedure);
    }
}
