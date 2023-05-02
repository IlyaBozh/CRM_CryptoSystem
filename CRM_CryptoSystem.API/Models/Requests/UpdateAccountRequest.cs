using CRM_CryptoSystem.API.Enums;

namespace CRM_CryptoSystem.API.Models.Requests;

public class UpdateAccountRequest
{
    public AccountStatus AccountStatus { get; set; }
}
