
using CRM_CryptoSystem.BusinessLayer.Exceptions;
using CRM_CryptoSystem.BusinessLayer.Services.Interfaces;
using IncredibleBackendContracts.Responses;
using System.Net;
using System.Text;
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

    public async Task<K> Post<T, K>(T payload, string path)
    {
        var serializedPayload = JsonSerializer.Serialize(payload);
        var requestPayload = new StringContent(serializedPayload, Encoding.UTF8, "application/json");
        HttpResponseMessage response;

        response = await _httpClient.PostAsync(path, requestPayload);

        //CheckStatusCode(response.StatusCode);

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<K>(content, _options);
        return result;
    }

/*    private void CheckStatusCode (HttpStatusCode statusCode)
    {
        if (statusCode == HttpStatusCode.InternalServerError)
        {
            throw new BadGatewayException("");
        }

        if (statusCode == HttpStatusCode.GatewayTimeout)
        {
            throw new GatewayTimeoutException("");
        }

        if (statusCode == HttpStatusCode.BadGateway)
        {
            throw new BadGatewayException("");
        }
    }*/
}
