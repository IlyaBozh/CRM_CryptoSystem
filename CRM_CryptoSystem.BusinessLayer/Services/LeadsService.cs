using CRM_CryptoSystem.BusinessLayer.Exceptions;
using CRM_CryptoSystem.BusinessLayer.Infrastructure;
using CRM_CryptoSystem.BusinessLayer.Models;
using CRM_CryptoSystem.BusinessLayer.Services.Interfaces;
using CRM_CryptoSystem.DataLayer.Enums;
using CRM_CryptoSystem.DataLayer.Interfaces;
using CRM_CryptoSystem.DataLayer.Models;
using Microsoft.Extensions.Logging;

namespace CRM_CryptoSystem.BusinessLayer.Services;

public class LeadsService : ILeadsService
{
    private readonly ILeadsRepository _leadsRepository;
    private readonly IAccountsRepository _accountsRepository;
    private readonly IHttpService _httpService;
    private readonly ILogger<LeadsService> _logger;

    public LeadsService(ILeadsRepository leadsRepository, IAccountsRepository accountsRepository, IHttpService httpService, ILogger<LeadsService> logger)
    {
        _leadsRepository = leadsRepository;
        _accountsRepository = accountsRepository;
        _httpService = httpService;
        _logger = logger;
    }

    public async Task<int> Add(LeadDto lead)
    {
        _logger.LogInformation($"Business layer: Database query for adding lead {lead.FirstName}, {lead.LastName}, {lead.Patronymic}, {lead.Birthday}, {lead.Phone.MaskNumber()}, " +
            $"{lead.Email.MaskEmail()}, {lead.Login}");

        bool isUniqueEmail = await CheckEmailForUniqueness(lead.Email);

        if (!isUniqueEmail)
        {
            throw new NotUniqueEmailException($"This email is registered already");
        }

        lead.Password = PasswordHash.HashPassword(lead.Password);
        lead.Role = Role.Lead;

        var leadId = await _leadsRepository.Add(lead);

        AccountDto account= new AccountDto()
        {
            LeadId = leadId,
            CryptoCurrency = Currency.USD,
            Status = AccountStatus.Active
        };

        var accountId = await _accountsRepository.Add(account);

        TransactionRequestModel transactionRequest = new TransactionRequestModel()
        {
            AccountId = accountId,
            Currency = Currency.USD,
            Amount = 100000
        };

        _logger.LogInformation($"Business layer: Database query for adding deposit: {transactionRequest.AccountId}, {transactionRequest.Amount}, {transactionRequest.Currency}");

        var transactionId = await _httpService.Post<TransactionRequestModel, long>(transactionRequest, PathConst.DepositPath);

        _logger.LogInformation($"Business layer: Database query for adding account Id: {accountId} by LeadId {lead.Id}");

        return leadId;
    }

    public async Task DeleteOrRestore(int id, bool isDeleted, ClaimModel claims)
    {
        var lead = await _leadsRepository.GetById(id);

        if(isDeleted)
        {
            _logger.LogInformation($"Business layer: Database query for deleting lead {id}, {lead.FirstName}, {lead.LastName}, {lead.Patronymic}, {lead.Birthday}, {lead.Phone.MaskNumber()}, " +
            $"{lead.Email.MaskEmail()}, {lead.Login}");
        }
        else
        {
            _logger.LogInformation($"Business layer: Database query for restoring lead {id}, {lead.FirstName}, {lead.LastName}, {lead.Patronymic}, {lead.Birthday}, {lead.Phone.MaskNumber()}, " +
            $"{lead.Email.MaskEmail()}, {lead.Login}");
        }

        if (lead is null)
            throw new NotFoundException($"Lead with id '{id}' was not found");

        AccessService.CheckAccessForLeadAndManager(lead.Id, claims);

        var accounts = await _accountsRepository.GetAllByLeadId(id);

        foreach(var account in accounts)
        {
            await _accountsRepository.DeleteOrRestore(account.Id, isDeleted);
        }

        await _leadsRepository.DeleteOrRestore(id, isDeleted);
    }

    public async Task<List<LeadDto>> GetAll()
    {
        _logger.LogInformation($"Business layer: Database query for getting all leads");
        return await _leadsRepository.GetAll();
    }

    public async Task<LeadDto> GetAllInfoById(int id, ClaimModel claims)
    {
        var lead = await _leadsRepository.GetAllInfoById(id);

        if (lead is null || lead.IsDeleted)
            throw new NotFoundException("Lead with this id was not found");

        _logger.LogInformation($"Business layer: Database query for getting lead by id {id}, {lead.FirstName}, {lead.LastName}, {lead.Patronymic}, {lead.Birthday}, {lead.Phone.MaskNumber()}, " +
            $"{lead.Email.MaskEmail()}, {lead.Login}");

        AccessService.CheckAccessForLeadAndManager(lead.Id, claims);

        return lead;
    }

    public async Task<LeadDto?> GetByEmail(string email)
    {
        _logger.LogInformation($"Business layer: Database query for getting lead by email {email}");

        var lead = await _leadsRepository.GetByEmail(email);

        if(lead is null)
            throw new NotFoundException($"Lead with email '{email}' was not found");

        return lead;
    }

    public async Task<LeadDto> GetById(int id, ClaimModel claims)
    {
        var lead = await _leadsRepository.GetById(id);

        if (lead is null)
            throw new NotFoundException("Lead with this id was not found");

        _logger.LogInformation($"Business layer: Database query for getting lead by id {id}, {lead.FirstName}, {lead.LastName}, {lead.Patronymic}, {lead.Birthday}, {lead.Phone.MaskNumber()}, " +
            $"{lead.Email.MaskEmail()}, {lead.Login}");

        AccessService.CheckAccessForLeadAndManager(lead.Id, claims);

        return lead;
    }

    public async Task Update(LeadDto newLead, int id, ClaimModel claims)
    {
        _logger.LogInformation($"Business layer: Database query for updating lead {id}, new data: {newLead.FirstName}, {newLead.LastName}, {newLead.Patronymic}, {newLead.Birthday}, {newLead.Phone.MaskNumber()}");

        var lead = await _leadsRepository.GetById(id);

        if (lead is null || newLead is null)
            throw new NotFoundException($"Lead with id '{lead.Id}' was not found");

        lead.Id = id;
        lead.FirstName = newLead.FirstName;
        lead.LastName = newLead.LastName;
        lead.Patronymic = newLead.Patronymic;
        lead.Birthday = newLead.Birthday;
        lead.Phone = newLead.Phone;

        await _leadsRepository.Update(lead);
    }

    private async Task<bool> CheckEmailForUniqueness(string email) => await _leadsRepository.GetByEmail(email) == default;
}
