using CRM_CryptoSystem.API.Enums;
using CryptoSystem_NuGetPackage.Enums;

namespace CRM_CryptoSystem.API.Models.Requests;

public class AddAccountRequest
{
    public Currency CryptoCurrency { get; set; }
    public int LeadId { get; set; }
    public AccountStatus Status { get; set; }
}
