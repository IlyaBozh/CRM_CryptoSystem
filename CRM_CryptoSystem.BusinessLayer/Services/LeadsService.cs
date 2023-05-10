﻿using CRM_CryptoSystem.BusinessLayer.Exeptions;
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
    private readonly ILogger<LeadsService> _logger;

    public LeadsService(ILeadsRepository leadsRepository, IAccountsRepository accountsRepository, ILogger<LeadsService> logger)
    {
        _leadsRepository = leadsRepository;
        _accountsRepository = accountsRepository;
        _logger = logger;
    }

    public async Task<int> Add(LeadDto lead)
    {
        _logger.LogInformation($"Business layer: Database query for adding lead {lead.FirstName}, {lead.LastName}, {lead.Patronymic}, {lead.Birthday}, {lead.Phone}, " +
            $"{lead.Email}, {lead.Login}");

        bool isUniqueEmail = await CheckEmailForUniqueness(lead.Email);

        if (!isUniqueEmail)
        {
            throw new NotUniqueEmailExeption($"This email is registered already");
        }

        lead.Password = PasswordHash.HashPassword(lead.Password);
        lead.Role = Role.Lead;

        var leadId = await _leadsRepository.Add(lead);

        AccountDto account= new AccountDto()
        {
            LeadId = leadId,
            Currency = CryptoCurrencies.USD,
            Status = AccountStatus.Active
        };

        var accountId = await _accountsRepository.Add(account);

        _logger.LogInformation($"Business layer: Database query for adding account Id: {accountId} by LeadId {lead.Id}");

        return leadId;
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
