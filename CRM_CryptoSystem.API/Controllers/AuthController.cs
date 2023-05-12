using CRM_CryptoSystem.API.Models.Requests;
using CRM_CryptoSystem.BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM_CryptoSystem.API.Controllers;

[AllowAnonymous]
[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    public async Task<ActionResult<string>> Login([FromBody] LoginRequest loginRequest)
    {
        var user = await _authService.Login(loginRequest.Email, loginRequest.Password);

        _logger.LogInformation($"Controllers: Login is successful for {loginRequest.Email}");

        return Ok(_authService.GetToken(user));
    }
}
