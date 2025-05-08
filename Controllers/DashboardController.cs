using CurrencyExchange.Data;
using CurrencyExchange.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DashboardController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if(user == null)
            {
                ViewData["Message"] += "To see your dashboard, please log in.";
                return View("../Home/Index");
            }
            var userId = user.Id;

            var wallets = await _context.wallets
                .Where(w => w.UserID == userId)
                .Select(w => new WalletViewModel
                {
                    WalletID = w.WalletID,
                    RMTBalance = w.RMTBalance,
                    RMTLocked = w.RMTLocked,
                    VCBalance = w.VCBalance,
                    VCLocked = w.VCLocked
                }).ToListAsync();

            var orders = await _context.orders
                .Where(o => o.UserID == userId)
                .Include(o => o.Status)
                .Include(o => o.Type)
                .Select(o => new OrderViewModel
                {
                    OrderID = o.OrderID,
                    Type = o.Type.Type,
                    Price = o.Price,
                    Quantity = o.Quantity,
                    Remaining = o.Remaining,
                    Status = o.Status.Status,
                    CreatedAt = o.CreatedAt
                }).ToListAsync();

            var transactions = await _context.transactions
                .Where(t => _context.orders.Any(o => o.UserID == userId && (o.OrderID == t.BuyOrderID || o.OrderID == t.SellOrderID)))
                .Select(t => new TransactionViewModel
                {
                    TransactionID = t.TransactionID,
                    BuyOrderID = t.BuyOrderID,
                    SellOrderID = t.SellOrderID,
                    Quantity = t.Quantity,
                    Price = t.Price,
                    FulfilledAt = t.FulfilledAt
                }).ToListAsync();

            var model = new DashboardViewModel
            {
                Wallets = wallets,
                Orders = orders,
                Transactions = transactions
            };

            return View(model);
        }
    }

}
