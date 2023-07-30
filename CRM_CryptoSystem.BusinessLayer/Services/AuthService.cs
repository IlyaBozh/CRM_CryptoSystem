
using CRM_CryptoSystem.BusinessLayer.Exceptions;
using CRM_CryptoSystem.BusinessLayer.Infrastructure;
using CRM_CryptoSystem.BusinessLayer.Models;
using CRM_CryptoSystem.BusinessLayer.Services.Interfaces;
using CRM_CryptoSystem.DataLayer.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CRM_CryptoSystem.BusinessLayer.Services;

public class AuthService : IAuthService
{
    private readonly ILeadsRepository _leadsRepository;
    private readonly IAdminsRepository _adminsRepository;
    private readonly ILogger<AuthService> _logger;

    public AuthService(ILeadsRepository leadsRepository, IAdminsRepository adminsRepository, ILogger<AuthService> logger)
    {
        _leadsRepository = leadsRepository;
        _adminsRepository = adminsRepository;
        _logger = logger;
    }

    public string GetToken(ClaimModel claim)
    {
        _logger.LogInformation($"Business layer: Database query for getting token");
        if (claim is null)
            throw new DataException("There are empty properties");

        var claims = new List<Claim>
        {
            { new Claim (ClaimTypes.Email, claim.Email.ToString()) },
            { new Claim (ClaimTypes.Role, claim.Role.ToString()) },
            { new Claim (ClaimTypes.NameIdentifier, claim.Id.ToString()) }
        };

        var jwt = new JwtSecurityToken(
            issuer: TokenOptions.Issuer,
            audience: TokenOptions.Audience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
            signingCredentials: new SigningCredentials(TokenOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public async Task<ClaimModel> Login(string login, string password)
    {
        _logger.LogInformation($"Business layer: Database query for login {login}");
        ClaimModel claimModel = new ClaimModel();

        var lead = await _leadsRepository.GetByEmail(login);

        if (lead == null)
        {
            throw new NotFoundException("No user with such mail");
        }

        ClaimModelReturnerService.ReturnLead(lead, login, password, claimModel);

        return claimModel;
    }
}
