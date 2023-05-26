using CRM_CryptoSystem.API.Enums;

namespace CRM_CryptoSystem.API.Models.Requests;

public class TransactionTransferRequest : TransactionRequest
{
    public long RecpientAccountId { get; set; }
    public Currency RecipientCurrency { get; set; }
}
