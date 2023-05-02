using Microsoft.AspNetCore.Mvc;

namespace CRM_CryptoSystem.API.Controllers;

[ApiController]
[Produces("application/json")]
[Route("[controller]")]
public class TransactionsController : Controller
{
    /*public ClaimModel _claims;*/
    /*private readonly ITransactionsService _transactionsService;*/
    private readonly ILogger<TransactionsController> _logger;

    public TransactionsController(ILogger<TransactionsController> logger)
    {
        _logger = logger;
    }


}
