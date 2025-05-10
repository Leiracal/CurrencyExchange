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
using Microsoft.AspNetCore.Authorization;


namespace CurrencyExchange.Controllers
{
    [Authorize]
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
            var currentUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(currentUserId))
            {
                return Unauthorized();
            }

            var userOrders = _context.orders
                .Where(o => o.UserID == currentUserId)
                .Include(o => o.Type)
                .Include(o => o.Status);

            return View(await userOrders.ToListAsync());
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
            //get order types for dropdowns
            ViewData["OrderTypeID"] = new SelectList(_context.orderTypes, "OrderTypeID", "Type");   
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,UserID,OrderTypeID,Price,Quantity,Remaining,Status")] Order order)
        {

            // Get current logged-in user object
            var currentUser = User.Identity;
            if (currentUser != null && currentUser.IsAuthenticated)
            {
                order.UserID = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                order.UserName = User.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value;
            }
            else
            {
                ModelState.AddModelError("UserID", "User is not authenticated.");
            }

            // Updated code to handle potential null reference for 'wallet'
            Wallet? wallet = await _context.wallets.FirstOrDefaultAsync(w => w.UserID == order.UserID);

            decimal? realMoneyBalance = 0;
            int? bobcatBalance = 0;
            decimal? realMoneyLocked = 0;
            int? bobcatLocked = 0;
            decimal? realMoneyOrderTotal = 0;
            int? bobcatOrderTotal = 0;

            if (wallet != null)
            {
                realMoneyBalance = wallet!.RMTBalance ?? 0;
                bobcatBalance = wallet.VCBalance ?? 0;
                realMoneyLocked = wallet.RMTLocked ?? 0;
                bobcatLocked = wallet.VCLocked ?? 0;

                realMoneyOrderTotal = order.Price * order.Quantity;
                bobcatOrderTotal = order.Quantity;
            }
            else
            {
                ModelState.AddModelError("Wallet", "Wallet not found for the current user.");
            }

            // Check if the user has sufficient balance for the order
            // ordertype 1 = buy, ordertype 2 = sell
            if (order.OrderTypeID != null && order.OrderTypeID == 1 && realMoneyBalance < realMoneyOrderTotal)
            {
                ModelState.AddModelError("Price", "Insufficient RMT balance for this order.");
            }
            else if (order.OrderTypeID != null && order.OrderTypeID == 2 && bobcatBalance < bobcatOrderTotal)
            {
                ModelState.AddModelError("Price", "Insufficient VC balance for this order.");
            }
            if (ModelState.IsValid)
            {
                // Set the CreatedAt property to the current date and time
                order.CreatedAt = DateTime.Now;

                // Remove real money or virtual currency from the user's wallet and lock it
                if (order.OrderTypeID != null && order.OrderTypeID == 1) //buy
                {
                    wallet.RMTBalance -= realMoneyOrderTotal;
                    wallet.RMTLocked += realMoneyOrderTotal;
                }
                else if (order.OrderTypeID != null && order.OrderTypeID == 2) //sell
                {
                    wallet.VCBalance -= bobcatOrderTotal;
                    wallet.VCLocked += bobcatOrderTotal;
                }

                // Set the Remaining property to the Quantity
                order.Remaining = order.Quantity;

                // Set Order Status to "Open"
                order.Status = await _context.orderStatuses.FirstOrDefaultAsync(s => s.Status == "Open");

                // Add the new order to the database
                _context.Add(order);
                await _context.SaveChangesAsync();

                // Run Fulfillment so that orders are matched
                var fulfillment = new Fulfillment(_context);
                int txProcessed = fulfillment.MatchOrders();
                if (txProcessed == 0)
                {
                    ViewData["Message"] += "Order placed. Check Dashboard later to see if your order gets filled. ";
                } else if (txProcessed == null)
                {
                    ViewData["Message"] += "There was a problem running Fulfillment. ";
                } else
                {
                    ViewData["Message"] += "Order placed. There were " + txProcessed.ToString()
                        + "transactions completed as a result of your order. " +
                        "Please check Dashboard for more information.";
                }
                ViewBag.txProcessed = txProcessed;

                // Redirect to the Index action after successful creation
                return RedirectToAction(nameof(Index));
            }

            // If the model is invalid, return to the Create view with the current data
            // and the order type list for the dropdown
            ViewData["OrderTypeID"] = new SelectList(_context.orderTypes, "OrderTypeID", "Type", order.OrderTypeID);
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

            //If the currently logged in UserID is not the Order's UserID, they can't edit it            
            var currentUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (order.UserID != currentUserId)
            {
                return Forbid();
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

            // Authentication checking: we're pulling up the original order to make sure it's yours
            var existingOrder = await _context.orders.AsNoTracking().FirstOrDefaultAsync(o => o.OrderID == id);
            var currentUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (existingOrder == null || existingOrder.UserID != currentUserId)
            {
                return Forbid(); // Or return Unauthorized();
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

            //If the currently logged in UserID is not the Order's UserID, they can't delete it            
            var currentUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (order.UserID != currentUserId)
            {
                return Forbid();
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

            // Authentication checking: we're pulling up the original order to make sure it's yours
            var existingOrder = await _context.orders.FindAsync(id);
            var currentUserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (existingOrder == null || existingOrder.UserID != currentUserId)
            {
                return Forbid(); // Or return Unauthorized();
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
