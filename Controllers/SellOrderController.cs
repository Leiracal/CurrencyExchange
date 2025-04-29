using CurrencyExchange.Data;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.Controllers
{
    public class SellOrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IActionResult Index()
        {
            return View();
        }
    }
}
