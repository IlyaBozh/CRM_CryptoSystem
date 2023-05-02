using Microsoft.AspNetCore.Mvc;

namespace CRM_CryptoSystem.API.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
