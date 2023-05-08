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

    public Task DeleteOrRestore(int id, bool isDeleting)
    {
        throw new NotImplementedException();
    }

    public Task<List<LeadDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<LeadDto> GetAllInfoById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<LeadDto> GetByEmail(string email)
    {
        throw new NotImplementedException();
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
