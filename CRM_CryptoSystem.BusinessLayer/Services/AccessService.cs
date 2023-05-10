
using CRM_CryptoSystem.BusinessLayer.Exceptions;
using CRM_CryptoSystem.DataLayer.Enums;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace CRM_CryptoSystem.BusinessLayer.Services;

public class AccessService
{
    private readonly ILogger<AccessService> _logger;

    public AccessService(ILogger<AccessService> logger)
    {
        _logger = logger;
    }

    public static void CheckAccessForLeadAndManager(int id, ClaimModel model)
    {
        if (claims is not null && claims.Id != id &&
            claims.Role != Role.Admin)
        {
            throw new AccessDeniedException($"Access denied");
        }
    }
}
