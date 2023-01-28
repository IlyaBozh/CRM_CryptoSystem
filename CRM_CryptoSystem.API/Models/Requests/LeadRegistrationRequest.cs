namespace CRM_CryptoSystem.API.Models.Requests;

public class LeadRegistrationRequest
{
    public string Email { get; set; }
    public string Passport { get; set; }
    public string Password { get; set; }
}
