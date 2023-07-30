
using CRM_CryptoSystem.BusinessLayer.Models;
using CRM_CryptoSystem.BusinessLayer.Services.Interfaces;
using CryptoSystem_NuGetPackage.Requests;
using Microsoft.Extensions.Logging;

namespace CRM_CryptoSystem.BusinessLayer.Services;

public class TransactionsService : ITransactionsService
{
    private readonly IHttpService _httpService;
    private readonly ILogger<TransactionsService> _logger;
    public TransactionsService(IHttpService httpService, ILogger<TransactionsService> logger)
    {
        _httpService = httpService;
        _logger = logger;
    }

    public async Task<long> AddDeposit(TransactionRequest request)
    {
        if (await GetBalanceByAccountsId(request.AccountId) >= 1000.0m)
        {
            throw new InvalidOperationException("The balance has not reached a critical minimum");
        }
        _logger.LogInformation($"Business layer: Database query for adding deposit: {request.AccountId}, {request.Amount}, {request.Currency}");
        return await _httpService.Post<TransactionRequest, long>(request, PathConst.DepositPath);
    }

    public async Task<List<long>> AddWithdraw(TransactionTransferRequest request)
    {
        _logger.LogInformation($"Business layer: Database query for adding withdraw {request.AccountId}, {request.Amount}, {request.Currency}");
        return await _httpService.Post<TransactionTransferRequest, List<long>>(request, PathConst.WithdrawPath);
    }

    public async Task<decimal> GetBalanceByAccountsId(long accountId)
    {
        _logger.LogInformation($"Business layer: Database query for getting balance by accounts id {accountId}");
        return await _httpService.GetBalanceByAccountsId(accountId);
    }

    public async Task<TransactionResponseModel> GetTransactionById(int transactionId)
    {
        _logger.LogInformation($"Business layer: Database query for getting transaction by id {transactionId}");
        var content = await _httpService.GetTransaction(transactionId);
        return content;
    }

    public async Task<List<TransactionResponseModel>> GetTransactionsByAccountId(int accountId)
    {
        _logger.LogInformation($"Business layer: Database query for getting transactions by account id {accountId}");
        var content = await _httpService.GetTransactionsByAccountId(accountId);
        return content;
    }
}
