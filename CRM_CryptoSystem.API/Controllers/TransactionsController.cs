﻿using AutoMapper;
using CRM_CryptoSystem.API.Extensions;
using CRM_CryptoSystem.API.Models.Requests;
using CRM_CryptoSystem.API.Models.Responses;
using CRM_CryptoSystem.BusinessLayer.Models;
using CRM_CryptoSystem.BusinessLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace CRM_CryptoSystem.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("[controller]")]
public class TransactionsController : Controller
{
    public ClaimModel _claims;
    private readonly ITransactionsService _transactionsService;
    private readonly ILogger<TransactionsController> _logger;
    private readonly IMapper _mapper;

    public TransactionsController(ITransactionsService transactionsService, ILogger<TransactionsController> logger, IMapper mapper)
    {
        _transactionsService = transactionsService;
        _logger = logger;
        _mapper = mapper;
    }

    [Authorize]
    [HttpPost("deposit")]
    [ProducesResponseType(typeof(long), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(void), StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<long>> AddDeposit([FromBody] TransactionRequest request)
    {
        _logger.LogInformation("Controllers: Add deposit");
        var claims = this.GetClaims();
        var transactionId = await _transactionsService.AddDeposit(_mapper.Map<TransactionRequestModel>(request));
        return Created($"{this.GetShemeAndHostString()}/transactions/{transactionId}", transactionId);
    }

    [Authorize]
    [HttpPost("withdraw")]
    [ProducesResponseType(typeof(long), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(void), StatusCodes.Status422UnprocessableEntity)]
    public async Task<ActionResult<long>> AddWithdraw([FromBody] TransactionRequest request)
    {
        _logger.LogInformation("Controllers: Add withdraw");
        var claims = this.GetClaims();
        var transactionId = await _transactionsService.AddWithdraw(_mapper.Map<TransactionRequestModel>(request));
        return Created($"{this.GetShemeAndHostString()}/transactions/{transactionId}", transactionId);
    }

    [Authorize]
    [HttpGet("{transactionId}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<TransactionResponse>> GetTransactionById(int transactionId)
    {
        _logger.LogInformation("Controllers: Get transaction by id");
        var claims = this.GetClaims();
        var transaction = await _transactionsService.GetTransactionById(transactionId);
        return Ok(_mapper.Map<TransactionResponse>(transaction));
    }

    [Authorize]
    [HttpGet("/byAccountId{accountId}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<List<TransactionResponse>>> GetTransactionsByAccountId(int accountId)
    {
        _logger.LogInformation("Controllers: Get transaction by account id");
        var claims = this.GetClaims();
        var transactions = await _transactionsService.GetTransactionsByAccountId(accountId);
        return Json(_mapper.Map<List<TransactionResponse>>(transactions));
    }

    [Authorize]
    [HttpGet("/accounts{accountId}/balance")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(void), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(void), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(void), StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<decimal>> GetBalanceByAccountsId(int accountId)
    {
        _logger.LogInformation("Controllers: Get balance by account id");
        var claims = this.GetClaims();
        var transactions = await _transactionsService.GetBalanceByAccountsId(accountId);
        return Json(transactions);
    }
}
