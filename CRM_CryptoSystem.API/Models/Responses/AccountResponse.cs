using CRM_CryptoSystem.API.Enums;

namespace CRM_CryptoSystem.API.Models.Responses;

public class AccountResponse
{
    public int Id { get; set; }
    public Currency CryptoCurrency { get; set; }
    public int LeadId { get; set; }
    public bool IsDeleted { get; set; }
}
