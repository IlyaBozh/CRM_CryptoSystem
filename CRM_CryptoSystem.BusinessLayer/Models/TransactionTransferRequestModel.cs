
using CRM_CryptoSystem.DataLayer.Enums;

namespace CRM_CryptoSystem.BusinessLayer.Models;

public class TransactionTransferRequestModel : TransactionRequestModel
{
    public long RecpientAccountId { get; set; }
    public Currency RecipientCurrency { get; set; }
}
