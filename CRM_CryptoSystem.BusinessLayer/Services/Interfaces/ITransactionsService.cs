

using CRM_CryptoSystem.BusinessLayer.Models;
using CryptoSystem_NuGetPackage.Requests;

namespace CRM_CryptoSystem.BusinessLayer.Services.Interfaces;

public interface ITransactionsService
{
    Task<long> AddDeposit(TransactionRequest request);
    Task<List<long>> AddWithdraw(TransactionTransferRequest request);
    Task<TransactionResponseModel> GetTransactionById(int transactionId);
    Task<List<TransactionResponseModel>> GetTransactionsByAccountId(int accountId);
    Task<decimal> GetBalanceByAccountsId(long accountId);
}
