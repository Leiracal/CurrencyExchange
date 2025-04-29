using System.Diagnostics;
using CurrencyExchange.Data;
using CurrencyExchange.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyExchange.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        /* TODO: create a method that accepts user inputs to create a new account and add it to the AspNetUsers database using IdentityUser methods.
         * DO NOT USE BUILT-IN REGISTER BUTTON BECAUSE IT WON'T ACCEPT USERNAMES */
        private readonly UserManager<IdentityUser> _userManager;
        /* TODO: use _context to connect */
        private readonly ApplicationDbContext _context; 


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
