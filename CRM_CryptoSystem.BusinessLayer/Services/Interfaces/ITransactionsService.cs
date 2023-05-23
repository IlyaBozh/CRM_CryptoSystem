

using CRM_CryptoSystem.BusinessLayer.Models;

namespace CRM_CryptoSystem.BusinessLayer.Services.Interfaces;

public interface ITransactionsService
{
    Task<long> AddDeposit(TransactionRequest request);
    Task<long> AddWithdraw(TransactionRequest request);
    Task<TransactionResponse> GetTransactionById(int transactionId);
    Task<List<TransactionResponse>> GetTransactionsByAccountId(int accountId);
    Task<decimal> GetBalanceByAccountsId(int accountId);
}
