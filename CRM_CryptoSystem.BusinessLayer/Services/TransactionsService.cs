
using CRM_CryptoSystem.BusinessLayer.Models;
using CRM_CryptoSystem.BusinessLayer.Services.Interfaces;
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

    public async Task<long> AddDeposit(TransactionRequestModel request)
    {
        _logger.LogInformation($"Business layer: Database query for adding deposit: {request.AccountId}, {request.Amount}, {request.Currency}");
        return await _httpService.Post<TransactionRequestModel, long>(request, PathConst.DepositPath);
    }

    public async Task<long> AddWithdraw(TransactionTransferRequestModel request)
    {
        _logger.LogInformation($"Business layer: Database query for adding withdraw {request.AccountId}, {request.Amount}, {request.Currency}");
        return await _httpService.Post<TransactionTransferRequestModel, long>(request, PathConst.WithdrawPath);
    }

    public async Task<decimal> GetBalanceByAccountsId(int accountId)
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
