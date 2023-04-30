namespace CRM_CryptoSystem.API.Models.Requests;

public class LeadUpdateRequest 
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Patronymic { get; set; }
    public string Phone { get; set; }
    public DateTime Birthday { get; set; }
}
