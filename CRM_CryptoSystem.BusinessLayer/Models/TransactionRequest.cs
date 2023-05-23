
using IncredibleBackendContracts.Enums;

namespace CRM_CryptoSystem.BusinessLayer.Models;

public class TransactionRequest
{
    public long AccountId { get; set; }
    public Currency Currency { get; set; }
    public decimal Amount { get; set; }
}
