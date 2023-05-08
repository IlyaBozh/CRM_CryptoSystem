

using CRM_CryptoSystem.DataLayer.Enums;
using System.Data;

namespace CRM_CryptoSystem.DataLayer.Models;

public class LeadDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public DateTime Birthday { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Login { get; set; }
    public Role Role { get; set; }
    public string Password { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool IsDeleted { get; set; }
    public List<AccountDto> Accounts { get; set; } = new List<AccountDto>();
}
