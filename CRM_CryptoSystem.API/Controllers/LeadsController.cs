using AutoMapper;
using CRM_CryptoSystem.API.Models.Requests;
using CRM_CryptoSystem.BusinessLayer.Services;
using CRM_CryptoSystem.BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CRM_CryptoSystem.API.Controllers;

[Authorize]
[ApiController]
[Produces("application/json")]
[Route("[controller]")]
public class LeadsController : ControllerBase
{
    private readonly ILeadsService _leadsService;
    private readonly IMapper _mapper;
    private readonly ILogger<LeadsController> _logger;

    public LeadsController(ILeadsService leadsService, IMapper mapper, ILogger<LeadsController> logger)
    {
        _leadsService = leadsService;
        _mapper = mapper;
        _logger = logger;
    }

    [AllowAnonymous]
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status409Conflict)]
    [ProducesResponseType(typeof(void), StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<int>> Register([FromBody] LeadRegistrationRequest request)
    {
        _logger.LogInformation($"Controller: Lead registration: {request.FirstName}, {request.LastName}, {request.Patronymic}, {request.Birthday}, {request.Phone}, " +
            $"{request.Email}, {request.Passport}");

        return Created("create", 1);
    }
}
