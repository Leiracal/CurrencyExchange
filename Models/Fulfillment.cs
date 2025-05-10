using CurrencyExchange.Data;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace CurrencyExchange.Models
{
    public class Fulfillment
    {
        private readonly ApplicationDbContext _context;

        public Fulfillment(ApplicationDbContext context)
        {
            _context = context;
        }

        //MatchOrders() runs the fulfillment cycle, filling market orders, then limit orders
        //returns an int for number of transactions processed
        public int MatchOrders()
        {
            int tx = 0;
            //query for any orders with null prices (market orders)
            //sorted by date ascending
            var marketOrders = _context.orders
            .Where(o => o.Price == null && o.Remaining > 0 && o.OrderStatusID < 3)
            .OrderBy(o => o.CreatedAt)
            .ToList();

            //work through buy/sell market orders, oldest first
            foreach (var order in marketOrders)
            {
                if (order.OrderTypeID == 1) //Buy
                {
                    tx += MatchMarketBuyOrder(order); //see method below
                }
                else if (order.OrderTypeID == 2) //Sell
                {
                    tx += MatchMarketSellOrder(order); //see method below
                }
            }

            //after market orders, check limit orders
            //query for list of "open" and "partial" buy orders (OrderStatusID < 3)
            //sorted first by price decending, then date ascending
            var buyLimitOrders = _context.orders
                .Where(o => o.Price != null && o.OrderTypeID == 1 && o.Remaining > 0 && o.OrderStatusID < 3)
                .OrderByDescending(o => o.Price)
                .ThenBy(o => o.CreatedAt)
                .ToList();

            //query for list of "open" and "partial" sell orders
            //sorted first by price decending, then date ascending
            var sellLimitOrders = _context.orders
                .Where(o => o.Price != null && o.OrderTypeID == 2 && o.Remaining > 0 && o.OrderStatusID < 3)
                .OrderBy(o => o.Price)
                .ThenBy(o => o.CreatedAt)
                .ToList();

            int buyIndex = 0;
            int sellIndex = 0;

            //start a loop that continues as long as orders of both types remain to be processed
            while (buyIndex < buyLimitOrders.Count && sellIndex < sellLimitOrders.Count)
            {
                var buy = buyLimitOrders[buyIndex];
                var sell = sellLimitOrders[sellIndex];

                //if highest buy order >= lowest sell order, start matching
                if (buy.Price >= sell.Price)
                {
                    tx += CreateTransaction(buy.OrderID, sell.OrderID); //see method below
                    // If an order is filled, move on to the next order of that type
                    if (buy.Remaining == 0)
                    {
                        buyIndex++;
                    }
                    if (sell.Remaining == 0)
                    {
                        sellIndex++;
                    }
                }
                //if highest buy limit order < lowest sell order, then stop the loop.
                else break;
            }

            //at the end of fulfillment, save all changes to the database.
            _context.SaveChanges();

            return tx;
        }

        //MatchMarketBuyOrder() fills a given buy order with the list of sell orders
        //returns number of transactions issued
        private int MatchMarketBuyOrder(Order buyOrder)
        {
            int tx = 0;
            //if buy, compare remaining quantity with lowest sell orders
            var sellOrders = _context.orders
                .Where(o => o.OrderTypeID == 2 && o.Remaining > 0
                    && o.OrderStatusID < 3 && o.Price != null)
                .OrderBy(o => o.Price)
                .ThenBy(o => o.CreatedAt)
                .ToList();

            foreach (var sellOrder in sellOrders)
            {
                //if buy quantity == 0 then we're done
                if (buyOrder.Remaining == 0)
                {
                    break;
                }
                //else generate this transaction (this BuyOrderID, given SellOrder ID)
                tx += CreateTransaction(buyOrder.OrderID, sellOrder.OrderID); //see method below
            }

            return tx;
        }

        //MatchMarketSellOrder() fills a given sell order with the list of buy orders
        private int MatchMarketSellOrder(Order sellOrder)
        {
            int tx = 0;
            //if sell, compare quantity with lowest buy orders
            var buyOrders = _context.orders
                .Where(o => o.OrderTypeID == 1 && o.Remaining > 0 && o.OrderStatusID < 3 && o.Price != null)
                .OrderByDescending(o => o.Price)
                .ThenBy(o => o.CreatedAt)
                .ToList();

            foreach (var buyOrder in buyOrders)
            {
                //if sell quantity == 0 then we're done
                if (sellOrder.Remaining == 0)
                {
                    break;
                }
                //else generate this transaction (given BuyOrderID, this SellOrder ID)
                tx += CreateTransaction(buyOrder.OrderID, sellOrder.OrderID);
            }

            return tx;
        }

        //CreateTransaction exchanges VC and RMT and creates a transaction table entry.
        private int CreateTransaction(int buyOrderID, int sellOrderID)
        {
            var buy = _context.orders.Find(buyOrderID);
            var sell = _context.orders.Find(sellOrderID);

            //if we're somehow missing a buy or sell order, this transaction is void
            if (buy == null || sell == null) return 0;

            //if we have a valid buy and sell order, get the users' wallets
            var buyer = _context.wallets.FirstOrDefault(w => w.UserID == buy.UserID);
            var seller = _context.wallets.FirstOrDefault(w => w.UserID == sell.UserID);

            //compare quantity of the two orders, note lowest
            //generate transaction (this BuyOrderID and SellOrderID,
            //lower quantity), then refer to which order zeroed out;
            //compare next buy order if buy was lowest, and vice versa.
            decimal price;
            decimal priceDiff = 0.0m;

            if (buy.Price.HasValue && sell.Price.HasValue)
            {
                price = Math.Min(buy.Price.Value, sell.Price.Value);
                if (price < buy.Price.Value)
                {
                    priceDiff = buy.Price.Value - price;
                }
            }
            else if (buy.Price.HasValue)
            {
                price = buy.Price.Value;
            }
            else if (sell.Price.HasValue)
            {
                price = sell.Price.Value;
            }
            else
                throw new InvalidOperationException("Cannot match two market orders with no price.");

            var quantity = Math.Min(buy.Remaining, sell.Remaining);

            // identify buyer/seller and exchange RMT
            // buyer funds should be in RMTLocked
            buyer.RMTLocked -= quantity * price;
            seller.RMTBalance += quantity * price;

            //If price < buy.Price, unlock the difference * quantity for buyer
            if(priceDiff > 0)
            {
                buyer.RMTLocked -= quantity * priceDiff;
                buyer.RMTBalance += quantity * priceDiff;
            }

            //decrement VC needed from each order and close out any empty order
            buy.Remaining -= quantity;
            sell.Remaining -= quantity;

            if(buy.Remaining == 0)
            {
                buy.OrderStatusID = 3;
            } else
            {
                buy.OrderStatusID = 2;
            }

            if (sell.Remaining == 0)
            {
                sell.OrderStatusID = 3;
            } else
            {
                sell.OrderStatusID = 2;
            }

            var transaction = new Transaction
            {
                BuyOrderID = buy.OrderID,
                SellOrderID = sell.OrderID,
                Quantity = quantity,
                Price = price,
                //FulfilledAt = DateTime.UtcNow
            };

            _context.transactions.Add(transaction);

            return 1;
        }
    }
}
