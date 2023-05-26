

using CRM_CryptoSystem.BusinessLayer.Models;

namespace CRM_CryptoSystem.BusinessLayer.Services.Interfaces;

public interface IHttpService
{
    Task<K> Post<T, K>(T payload, string path);
    Task<TransactionResponseModel> GetTransaction(int transactionId);
    Task<List<TransactionResponseModel>> GetTransactionsByAccountId(int accountId);

    Task<decimal> GetBalanceByAccountsId(int accountId);
}
