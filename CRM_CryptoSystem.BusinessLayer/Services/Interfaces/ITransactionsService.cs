

using CRM_CryptoSystem.BusinessLayer.Models;

namespace CRM_CryptoSystem.BusinessLayer.Services.Interfaces;

public interface ITransactionsService
{
    Task<long> AddDeposit(TransactionRequestModel request);
    Task<long> AddWithdraw(TransactionTransferRequestModel request);
    Task<TransactionResponseModel> GetTransactionById(int transactionId);
    Task<List<TransactionResponseModel>> GetTransactionsByAccountId(int accountId);
    Task<decimal> GetBalanceByAccountsId(int accountId);
}
