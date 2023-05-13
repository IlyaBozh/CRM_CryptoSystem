namespace CRM_CryptoSystem.API.Models.Responses;

public class LeadAllInfoResponse : LeadMainInfoResponse
{
    public string Email { get; set; }
    public string? Phone { get; set; }
    public string Login { get; set; }
}
