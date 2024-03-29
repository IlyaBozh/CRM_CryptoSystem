﻿
using CRM_CryptoSystem.BusinessLayer.Exceptions;
using CRM_CryptoSystem.BusinessLayer.Models;
using CRM_CryptoSystem.BusinessLayer.Services.Interfaces;
using CRM_CryptoSystem.DataLayer.Interfaces;
using CRM_CryptoSystem.DataLayer.Models;
using Microsoft.Extensions.Logging;

namespace CRM_CryptoSystem.BusinessLayer.Services;

public class AccountsService : IAccountsService
{
    private readonly IAccountsRepository _accountsRepository;
    private readonly ILeadsRepository _leadsRepository;
    private ILogger<AccountsService> _logger;

    public AccountsService(IAccountsRepository accountsRepository, ILeadsRepository leadsRepository, ILogger<AccountsService> logger)
    {
        _accountsRepository = accountsRepository;
        _leadsRepository = leadsRepository;
        _logger = logger;
    }

    public async Task<int> Add(AccountDto accountDTO, ClaimModel claim)
    {
        _logger.LogInformation($"Business layer: Database query for adding account {accountDTO.LeadId}, {accountDTO.CryptoCurrency}, {accountDTO.Status}");
        AccessService.CheckAccessForLeadAndManager(accountDTO.Id, claim);

        var lead = await _leadsRepository.GetById(accountDTO.LeadId);


        List<AccountDto> accountsOfLead = await _accountsRepository.GetAllByLeadId(accountDTO.LeadId);
        var isRepeated = accountsOfLead.Any(a => a.CryptoCurrency == accountDTO.CryptoCurrency);

        if (isRepeated)
        {
            throw new RepeatCurrencyException($"Already have an account with this currency");
        }

        var accountId = await _accountsRepository.Add(accountDTO);
        
        return accountId;
    }

    public async Task DeleteOrRestore(int id, ClaimModel claim)
    {
        var account = await _accountsRepository.GetById(id);

        if (account is null)
        {
            throw new NotFoundException("Account not found");
        }

        _logger.LogInformation($"Business layer: Database query for deleting account: {id} {account.LeadId}, {account.CryptoCurrency}, {account.Status}");
        AccessService.CheckAccessForLeadAndManager(id, claim);

        await _accountsRepository.DeleteOrRestore(id, true);
    }

    public async Task<List<AccountDto>> GetAllByLeadId(int LeadId, ClaimModel claim)
    {
        _logger.LogInformation($"Business layer: Database query for getting accounts by lead id : {LeadId}");
        AccessService.CheckAccessForLeadAndManager(LeadId, claim);
        return await _accountsRepository.GetAllByLeadId(LeadId);
    }

    public async Task<AccountDto> GetById(int id, ClaimModel claim)
    {
        var account = await _accountsRepository.GetById(id);

        if (account == null)
        {
            throw new NotFoundException("Account not found");
        }

        _logger.LogInformation($"Business layer: Database query for getting account: {id} {account.LeadId}, {account.CryptoCurrency}, {account.Status}");
        AccessService.CheckAccessForLeadAndManager(claim.Id, claim);

        return account;
    }

    public async Task Update(AccountDto accountDto, int id, ClaimModel claim)
    {
        _logger.LogInformation($"Business layer: Database query for updating account by id {id}, {accountDto.Status}");
        AccessService.CheckAccessForLeadAndManager(id, claim);

        await _accountsRepository.Update(accountDto, id);
    }
}
