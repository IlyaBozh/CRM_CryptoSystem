﻿using AutoMapper;
using CRM_CryptoSystem.API.Enums;
using CRM_CryptoSystem.API.Extensions;
using CRM_CryptoSystem.API.Infastructure;
using CRM_CryptoSystem.API.Models.Requests;
using CRM_CryptoSystem.API.Models.Responses;
using CRM_CryptoSystem.BusinessLayer.Infrastructure;
using CRM_CryptoSystem.BusinessLayer.Services.Interfaces;
using CRM_CryptoSystem.DataLayer.Models;
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
        _logger.LogInformation($"Controller: Lead registration: {request.FirstName}, {request.LastName}, {request.Patronymic}, {request.Birthday}, {request.Phone.MaskNumber()}, " +
            $"{request.Email.MaskEmail()}, {request.Login}");

        var result = await _leadsService.Add(_mapper.Map<LeadDto>(request));

        return Created($"{this.GetUrl()}/{result}", result);
    }

    [Authorize]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(LeadAllInfoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(void), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LeadAllInfoResponse>> GetById(int id)
    {
        var claims = this.GetClaims();
        var lead = await _leadsService.GetById(id, claims);

        _logger.LogInformation($"Controller: Get lead by id {id}: {lead.FirstName}, {lead.LastName}, {lead.Patronymic}, {lead.Birthday}, {lead.Phone.MaskNumber()}, " +
            $", {lead.Email.MaskEmail()}, {lead.Login}");

        if (lead is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(_mapper.Map<LeadAllInfoResponse>(lead));
        }
    }

    [AuthorizeByRole(Role.Admin)]
    [HttpGet]
    [ProducesResponseType(typeof(List<LeadMainInfoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<List<LeadMainInfoResponse>>> GetAll()
    {
        _logger.LogInformation("Controller: Get all leads");
        var leads = await _leadsService.GetAll();
        return Ok(_mapper.Map<List<LeadAllInfoResponse>>(leads));
    }

    [Authorize]
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(void), StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult> Update([FromBody] LeadUpdateRequest request, int id)
    {
        _logger.LogInformation($"Controller: Update lead by id: {id}: {request.FirstName}, {request.LastName}, {request.Patronymic}, {request.Birthday}, {request.Phone.MaskNumber()}");
        var claims = this.GetClaims();

        await _leadsService.Update(_mapper.Map<LeadDto>(request), id, claims);
        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> Remove(int id)
    {
        var claims = this.GetClaims();

        var lead = await _leadsService.GetById(id, claims);
        _logger.LogInformation($"Controller: Remove lead by id {id}:{lead.FirstName}, {lead.LastName}, {lead.Patronymic}, {lead.Birthday}, {lead.Phone.MaskNumber()}, " +
            $"{lead.Email.MaskEmail()}, {lead.Login}");
        
        await _leadsService.DeleteOrRestore(id, true, claims);

        return NoContent();
    }

    [AuthorizeByRole(Role.Admin)]
    [HttpPatch("{id}/restore")]
    [ProducesResponseType(typeof(void), StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult> Restore(int id)
    {
        var claims = this.GetClaims();
        var lead = await _leadsService.GetById(id, claims);
        _logger.LogInformation($"Controller: Restore lead by id {id}: {lead.FirstName}, {lead.LastName}, {lead.Patronymic}, {lead.Birthday}, {lead.Phone.MaskNumber()}, " +
            $"{lead.Email.MaskEmail()}, {lead.Login}");
        
        await _leadsService.DeleteOrRestore(id, false, claims);

        return NoContent();
    }
}

