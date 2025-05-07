using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CurrencyExchange.Data;
using CurrencyExchange.Models;
using SQLitePCL;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;


namespace CurrencyExchange.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Order
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.orders.Include(o => o.Type).Include(o => o.Status);
            return View(await applicationDbContext.ToListAsync());
            //return _context.orders != null ? 
            //              View(await _context.orders.ToListAsync()) :
            //              Problem("Entity set 'ApplicationDbContext.orders' is null.");
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.orders == null)
            {
                return NotFound();
            }

            var order = await _context.orders
                .Include(o => o.Type)
                .Include(o => o.Status)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            //get logged in user & pass to view for pre-filled form field
            //TODO: update this to work with new user registration
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            ViewBag.UserID = userId;
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,Type,Price,Quantity,Remaining,Status")] Order order)
        {
            // TODO: update this to work with new user registration #2
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            OrderType? orderType = _context.orderTypes.FirstOrDefault(o => o.Type == order.Type.Type);
            Wallet? wallet = await _context.wallets.FirstOrDefaultAsync(w => w.UserID == userId);
            decimal? realMoneyBalance = wallet.RMTBalance;
            int? bobcatBalance = wallet.VCBalance;
            decimal? realMoneyLocked = wallet.RMTLocked;
            int? bobcatLocked = wallet.VCLocked;

            decimal? realMoneyOrderTotal = order.Price * order.Quantity;
            int? bobcatOrderTotal = order.Quantity;


            // Check if the user has sufficient balance for the order
            if (orderType != null && orderType.Type == "Buy" && wallet.RMTBalance < realMoneyOrderTotal)
            {
                ModelState.AddModelError("Price", "Insufficient RMT balance for this order.");
            }
            else if (orderType != null && orderType.Type == "Sell" && bobcatBalance < bobcatOrderTotal)
            {
                ModelState.AddModelError("Price", "Insufficient VC balance for this order.");
            }
            if (ModelState.IsValid)
            {
                // Set the CreatedAt property to the current date and time
                order.CreatedAt = DateTime.UtcNow;

                // Remove real money or virtual currency from the user's wallet and lock it
                if (orderType != null && orderType.Type == "Buy")
                {
                    wallet.RMTBalance -= realMoneyOrderTotal;
                    wallet.RMTLocked += realMoneyOrderTotal;
                }
                else if (orderType != null && orderType.Type == "Sell")
                {
                    wallet.VCBalance -= bobcatOrderTotal;
                    wallet.VCLocked += bobcatOrderTotal;
                }

                order.Remaining = order.Quantity;
                ViewData["OrderTypeID"] = new SelectList(_context.orderTypes, "OrderTypeID", "Type", order.OrderTypeID);

                // Add the new order to the database
                _context.Add(order);
                await _context.SaveChangesAsync();

                // Redirect to the Index action after successful creation
                return RedirectToAction(nameof(Index));
            }

            // If the model is invalid, return to the Create view with the current data
            return View(order);
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.orders == null)
            {
                return NotFound();
            }

            var order = await _context.orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderID,UserID,Type,Price,Quantity,Remaining,Status,CreatedAt")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.orders == null)
            {
                return NotFound();
            }

            var order = await _context.orders
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.orders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.orders'  is null.");
            }
            var order = await _context.orders.FindAsync(id);
            if (order != null)
            {
                _context.orders.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return (_context.orders?.Any(e => e.OrderID == id)).GetValueOrDefault();
        }
    }
}
