
using CRM_CryptoSystem.DataLayer.Enums;

namespace CRM_CryptoSystem.BusinessLayer.Models;

public class ClaimModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
}
