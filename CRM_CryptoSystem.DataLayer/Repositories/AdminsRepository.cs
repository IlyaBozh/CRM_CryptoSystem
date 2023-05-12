
using CRM_CryptoSystem.DataLayer.Interfaces;
using CRM_CryptoSystem.DataLayer.Models;
using Dapper;
using Microsoft.Extensions.Logging;
using System.Data;

namespace CRM_CryptoSystem.DataLayer.Repositories;

public class AdminsRepository : BaseRepository, IAdminsRepository
{
    private readonly ILogger<AdminsRepository> _logger;
    public AdminsRepository(IDbConnection dbConnection, ILogger<AdminsRepository> logger) : base(dbConnection)
    {
        _logger = logger;
    }

    public async Task<int> AddAdmin(AdminDto admin)
    {
        _logger.LogInformation($"Data Layer: add admin {admin.Email}");
        var id = await _connectionString.QuerySingleAsync<int>(
            StoredProcedures.Admin_Add,
            param: new
            {
                admin.Password,
                admin.Email
            },
            commandType: CommandType.StoredProcedure);

        return id;
    }

    public Task<AdminDto> GetAdminByEmail(string email)
    {
        throw new NotImplementedException();
    }
}
