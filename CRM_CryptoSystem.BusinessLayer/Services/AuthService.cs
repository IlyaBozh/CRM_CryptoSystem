
using CRM_CryptoSystem.BusinessLayer.Models;
using CRM_CryptoSystem.BusinessLayer.Services.Interfaces;

namespace CRM_CryptoSystem.BusinessLayer.Services;

public class AuthService : IAuthService
{
    public Task<string> GetToken(ClaimModel claim)
    {
        throw new NotImplementedException();
    }

    public Task<ClaimModel> Login(string login, string password)
    {
        throw new NotImplementedException();
    }
}
