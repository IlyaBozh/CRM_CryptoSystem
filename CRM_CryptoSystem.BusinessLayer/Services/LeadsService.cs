using CRM_CryptoSystem.BusinessLayer.Models;
using CRM_CryptoSystem.BusinessLayer.Services.Interfaces;
using CRM_CryptoSystem.DataLayer.Interfaces;
using CRM_CryptoSystem.DataLayer.Models;
using Microsoft.Extensions.Logging;

namespace CRM_CryptoSystem.BusinessLayer.Services;

public class LeadsService : ILeadsService
{
    private readonly ILeadsRepository _leadsRepository;
    private readonly IAccountsRepository _accountsRepository;
    private readonly ILogger<LeadsService> _logger;
    /*private readonly IMessageProducer _producer*/

    public LeadsService(ILeadsRepository leadsRepository, IAccountsRepository accountsRepository, ILogger<LeadsService> logger)
    {
        _leadsRepository = leadsRepository;
        _accountsRepository = accountsRepository;
        _logger = logger;
    }

    public Task<int> Add(LeadDto lead)
    {
        throw new NotImplementedException();
    }

    public Task<LeadDto> DeleteOrRestore(int id, bool isDeleted, ClaimModel claims)
    {
        throw new NotImplementedException();
    }

    public Task<List<LeadDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<LeadDto> GetAllInfoById(int id, ClaimModel claims)
    {
        throw new NotImplementedException();
    }

    public Task<LeadDto?> GetByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<LeadDto> GetById(int id, ClaimModel claims)
    {
        throw new NotImplementedException();
    }

    public Task Update(LeadDto lead, int id, ClaimModel claims)
    {
        throw new NotImplementedException();
    }

    private async Task<bool> CheckEmailForUniqueness(string email) => await _leadsRepository.GetByEmail(email) == default;
}
