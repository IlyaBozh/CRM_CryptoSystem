using CRM_CryptoSystem.BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM_CryptoSystem.API.Controllers;

[Authorize]
[ApiController]
[Produces("application/json")]
[Route("[controller]")]
public class LeadsController : ControllerBase
{
    private readonly ILeadsService _leadsService;
}
