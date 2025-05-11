using System.Diagnostics;
using CurrencyExchange.Data;
using CurrencyExchange.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Controllers
{
    public class HomeController : Controller
    {
        /* TODO: create a method that accepts user inputs to create a new account and add it to the AspNetUsers database using IdentityUser methods.
         * DO NOT USE BUILT-IN REGISTER BUTTON BECAUSE IT WON'T ACCEPT USERNAMES */
        private readonly UserManager<IdentityUser> _userManager;
        /* TODO: use _context to connect */
        private readonly ApplicationDbContext _context; 


        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser([Bind("Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                var userIdentity = new IdentityUser(user.Email)
                {
                    Email = user.Email
                };
                string userPassword = user.Password;
                IdentityResult checkUser = await _userManager.CreateAsync(userIdentity, userPassword);
                
                //if create user, don't actually bind user and wallet, let the user.id match to the wallet.userID
                if (checkUser.Succeeded)
                {
                    //new users have new wallets
                    Wallet wallet = new Wallet
                    {
                        RMTBalance = 10000m,
                        RMTLocked = 0.0m,
                        VCBalance = 1000,
                        VCLocked = 0,
                        UserID = userIdentity.Id,
                    };
                    _context.Add(wallet);
                    await _context.SaveChangesAsync();
                    ViewData["Message"] += "User registered. ";
                }
                else
                {
                    ViewData["Message"] += "There was a problem! User could not be registered! ";
                }
            }

            return View(nameof(Index));
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
