
using CryptoSystem_NuGetPackage.Enums;

namespace CRM_CryptoSystem.API.Models.Responses;

public class TransactionResponse
{
    public long Id { get; set; }
    public long AccountId { get; set; }
    public DateTime Date { get; set; }
    public TransactionType TransactionType { get; set; }
    public decimal Amount { get; set; }
    public Currency CryptoCurrency { get; set; }
}
