using CRM_CryptoSystem.API.Enums;

namespace CRM_CryptoSystem.API.Models.Requests;

public class AddAccountRequest
{
    public CryptoCurrencies CryptoCurrencie { get; set; }
    public int LeadId { get; set; }
}
