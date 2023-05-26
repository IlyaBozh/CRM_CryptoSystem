


using CRM_CryptoSystem.DataLayer.Enums;

namespace CRM_CryptoSystem.BusinessLayer.Models;

public class TransactionRequestModel
{
    public long AccountId { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }
}
