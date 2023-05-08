using CRM_CryptoSystem.DataLayer.Interfaces;
using CRM_CryptoSystem.DataLayer.Models;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;

namespace CRM_CryptoSystem.DataLayer.Repositories;

public class LeadsRepository : BaseRepository, ILeadsRepository
{
    private readonly ILogger<LeadsRepository> _logger;

    public LeadsRepository(IDbConnection connection, ILogger<LeadsRepository> logger) : base(connection)
    {
        _logger = logger;
    }

    public async Task<int> Add(LeadDto leadDto)
    {
        _logger.LogInformation($"Data Layer: Add lead: {leadDto.FirstName}, {leadDto.LastName}, {leadDto.Patronymic}, {leadDto.Birthday}");
        var id = await _connectionString.QuerySingleAsync<int>(
            StoredProcedures.Lead_Add,
            param: new
            {
                leadDto.FirstName,
                leadDto.LastName,
                leadDto.Patronymic,
                leadDto.Birthday,
                leadDto.Email,
                leadDto.Phone,
                leadDto.Login,
                leadDto.Role,
                leadDto.Password
            },
            commandType: System.Data.CommandType.StoredProcedure);

        return id;
    }

    public async Task DeleteOrRestore(int id, bool isDeleting)
    {
        if (isDeleting)
        {
            _logger.LogInformation($"Data layer: delete lead by id {id}");
            await _connectionString.QueryFirstOrDefaultAsync<LeadDto>(
                StoredProcedures.Lead_Delete,
                param: new {id, isDeleting },
                commandType: System.Data.CommandType.StoredProcedure);
        }
        else
        {
            _logger.LogInformation($"Data layer: restore lead by id {id}");
            await _connectionString.QueryFirstOrDefaultAsync<LeadDto>(
                StoredProcedures.Lead_Delete,
                param: new { id, isDeleting },
                commandType: System.Data.CommandType.StoredProcedure);
        }
    }

    public async Task<List<LeadDto>> GetAll()
    {
        _logger.LogInformation($"Data Layer: Get all leads");
        var leads =  _connectionString.Query<LeadDto>(
            StoredProcedures.Lead_GetAll,
            commandType: System.Data.CommandType.StoredProcedure).ToList();

        return leads;
    }

    public async Task<LeadDto> GetAllInfoById(int id)
    {
        var lead = _connectionString.Query<LeadDto, AccountDto, LeadDto>(
            StoredProcedures.Lead_GetAllInfoById, 
            (lead, account) =>
            {
                lead.Accounts.Add( account );
                return lead;
            },
            splitOn: "Id",
            param: new {id},
            commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();

        _logger.LogInformation($"Data Layer: Get by id {id}, {lead.FirstName}, {lead.LastName}, {lead.Patronymic}");

        return lead;
    }

    public async Task<LeadDto> GetByEmail(string email)
    {
        _logger.LogInformation($"Data Layer: Get by email {email}");

        var lead = await _connectionString.QueryFirstOrDefaultAsync<LeadDto>(
            StoredProcedures.Lead_GetByEmail,
            param: new { email },
            commandType: System.Data.CommandType.StoredProcedure);

        return lead;
    }

    public Task<LeadDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(LeadDto leadDto)
    {
        throw new NotImplementedException();
    }
}
