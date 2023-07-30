
using CRM_CryptoSystem.BusinessLayer.Exceptions;
using CRM_CryptoSystem.BusinessLayer.Models;
using CRM_CryptoSystem.BusinessLayer.Services.Interfaces;
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


    public async Task<decimal> GetBalanceByAccountsId(long accountId)
    {
        var response = await _httpClient.GetAsync($"/accounts/{accountId}/balance");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<decimal>(content, _options);
        return result;
    }

    public async Task<TransactionResponseModel> GetTransaction(int transactionId)
    {
        var response = await _httpClient.GetAsync($"/transactions/{transactionId}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<TransactionResponseModel>(content, _options);
        return result;
    }

    public async Task<List<TransactionResponseModel>> GetTransactionsByAccountId(int accountId)
    {
        var response = await _httpClient.GetAsync($"/accounts/{accountId}/transactions");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<List<TransactionResponseModel>>(content, _options);
        return result;
    }

    public async Task<K> Post<T, K>(T payload, string path)
    {
        var serializedPayload = JsonSerializer.Serialize(payload);
        var requestPayload = new StringContent(serializedPayload, Encoding.UTF8, "application/json");
        HttpResponseMessage response;

        response = await _httpClient.PostAsync(path, requestPayload);

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<K>(content, _options);
        return result;
    }
}
