using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.Controllers
{
    public class UserController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
