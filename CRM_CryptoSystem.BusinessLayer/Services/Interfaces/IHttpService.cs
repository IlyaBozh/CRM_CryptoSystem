
using IncredibleBackendContracts.Responses;

namespace CRM_CryptoSystem.BusinessLayer.Services.Interfaces;

public interface IHttpService
{
    Task<K> Post<T, K>(T payload, string path);
    Task<TransactionResponse> GetTransaction(int transactionId);
    Task<List<TransactionResponse>> GetTransactionsByAccountId(int accountId);

    Task<decimal> GetBalanceByAccountsId(int accountId);
}
