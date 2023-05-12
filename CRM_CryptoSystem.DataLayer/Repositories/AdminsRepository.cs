
using CRM_CryptoSystem.DataLayer.Interfaces;
using CRM_CryptoSystem.DataLayer.Models;
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

    public Task<int> AddAdmin(AdminDto admin)
    {
        throw new NotImplementedException();
    }

    public Task<AdminDto> GetAdminByEmail(string email)
    {
        throw new NotImplementedException();
    }
}
