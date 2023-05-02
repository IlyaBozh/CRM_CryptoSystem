using AutoMapper;
using CRM_CryptoSystem.API.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM_CryptoSystem.API.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AccountsController : Controller
{
    /*private readonly IAccountService _accountService;*/
    private readonly IMapper _mapper;
    private readonly ILogger<AccountsController> _logger;

    public AccountsController (IMapper mapper, ILogger<AccountsController> logger)
    {
        _mapper = mapper;
        _logger = logger;
    }

    [Authorize]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(AccountResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AccountResponse>> GetAccount(int id)
    {
        _logger.LogInformation($"Controller: Get an account by id {id}");
/*        var claim = this.GetClaims();
        var result = await _accountService.GetAccountById(id, claim);*/
        var result = new AccountResponse();
        if (result == null)
            return NotFound();
        else
            /*return Ok(_mapper.Map<AccountResponse>(result));*/
            return Ok(result);
    }

    [Authorize]
    [HttpGet("/leads/{leadId}/accounts")]
    [ProducesResponseType(typeof(AccountResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<List<AccountResponse>>> GetAllAccountsByLeadId(int leadId)
    {
        _logger.LogInformation($"Controller: Get all accounts by lead id {leadId}");
       /* var claim = this.GetClaims();
        var result = await _accountService.GetAllAccountsByLeadId(leadId, claim);*/
        var result = new List<AccountResponse>();
        /*return Ok(_mapper.Map<List<AccountResponse>>(result));*/
        return Ok(result);
    }
}
