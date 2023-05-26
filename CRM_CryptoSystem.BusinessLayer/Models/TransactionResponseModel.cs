

using CRM_CryptoSystem.DataLayer.Enums;

namespace CRM_CryptoSystem.BusinessLayer.Models;

public class TransactionResponseModel
{
    public long Id { get; set; }
    public long AccountId { get; set; }
    public DateTime Date { get; set; }
    public TransactionType TransactionType { get; set; }
    public decimal Amount { get; set; }
    public Currency CryptoCurrency { get; set; }
}
