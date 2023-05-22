
using CRM_CryptoSystem.DataLayer.Enums;

namespace CRM_CryptoSystem.DataLayer.Models;

public class AccountDto
{
    public int Id { get; set; }
    public CryptoCurrencies CryptoCurrency { get; set; }
    public AccountStatus Status { get; set; }
    public int LeadId { get; set; }
    public bool IsDeleted { get; set; }
}
