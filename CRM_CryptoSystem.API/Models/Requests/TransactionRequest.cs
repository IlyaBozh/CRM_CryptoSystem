using CRM_CryptoSystem.API.Enums;

namespace CRM_CryptoSystem.API.Models.Requests;

public class TransactionRequest
{
    public long AccountId { get; set; }
    public CryptoCurrencies CryptoCurrency { get; set; }
    public decimal Amount { get; set; }
}
