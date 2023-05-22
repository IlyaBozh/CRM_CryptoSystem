
using CRM_CryptoSystem.BusinessLayer.Services.Interfaces;
using IncredibleBackendContracts.Responses;
using System.Text.Json;

namespace CRM_CryptoSystem.BusinessLayer.Services;

public class TransactionStoreClient : IHttpService
{
    private static readonly HttpClient _httpClient = new HttpClient();
    private readonly JsonSerializerOptions _options;
    public const string Accounts = "accounts";

    public TransactionStoreClient()
    {
        var baseAddress = Environment.GetEnvironmentVariable("TRANSACTION_STORE_BASE_URL");

        if (baseAddress == null)
        {
            throw new ArgumentNullException(nameof(baseAddress));
        }

        if (_httpClient.BaseAddress == null)
        {
            _httpClient.BaseAddress = new Uri(baseAddress);
        }

        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }


    public Task<decimal> GetBalanceByAccountsId(int accountId)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionResponse> GetTransaction(int transactionId)
    {
        throw new NotImplementedException();
    }

    public Task<List<TransactionResponse>> GetTransactionsByAccountId(int accountId)
    {
        throw new NotImplementedException();
    }

    public Task<K> Post<T, K>(T payload, string path)
    {
        throw new NotImplementedException();
    }
}
