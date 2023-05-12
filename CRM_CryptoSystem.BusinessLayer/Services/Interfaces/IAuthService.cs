
using CRM_CryptoSystem.BusinessLayer.Models;

namespace CRM_CryptoSystem.BusinessLayer.Services.Interfaces;

public interface IAuthService
{
    public Task<ClaimModel> Login(string login, string password);
    public string GetToken(ClaimModel claim);
}
