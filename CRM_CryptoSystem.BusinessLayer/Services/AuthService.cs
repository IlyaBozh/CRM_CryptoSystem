
using CRM_CryptoSystem.BusinessLayer.Models;
using CRM_CryptoSystem.BusinessLayer.Services.Interfaces;
using CRM_CryptoSystem.DataLayer.Interfaces;
using Microsoft.Extensions.Logging;

namespace CRM_CryptoSystem.BusinessLayer.Services;

public class AuthService : IAuthService
{
    private readonly ILeadsRepository _leadsRepository;
    private readonly IAdminsRepository _adminsRepository;
    private readonly ILogger<AuthService> _logger;

    public AuthService(ILeadsRepository leadsRepository, IAdminsRepository adminsRepository, ILogger<AuthService> logger)
    {
        _leadsRepository = leadsRepository;
        _adminsRepository = adminsRepository;
        _logger = logger;
    }

    public Task<string> GetToken(ClaimModel claim)
    {
        throw new NotImplementedException();
    }

    public Task<ClaimModel> Login(string login, string password)
    {
        throw new NotImplementedException();
    }
}
