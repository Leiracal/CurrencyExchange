using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace CurrencyExchange.Models
{
    public class Fulfillment
    {
        public void MatchOrders()
        {
            //query for any orders with null prices (market orders)
            //sorted by date ascending

            //take oldest buy/sell market order
            //if buy, compare remaining quantity with lowest sell orders
            //if buy quantity <= lowest remaining sell order,
            //this is the last transaction for this market buy order;
            //else generate this transaction (this BuyOrderID,
            //given SellOrder ID, lower quantity between the two)
            //and proceed to next lowest buy order price

            //if sell, compare quantity with lowest buy orders
            //if sell quantity <= lowest remaining buy order,
            //this is the last transaction for this market sell order;
            //else generate this transaction (this SellOrderID,
            //given BuyOrder ID, lower quantity between the two)
            //and proceed to next lowest buy order price

            //after market orders, check limit orders
            //query for list of "open" and "partial" buy orders
            //sorted first by price decending, then date ascending
            //query for list of "open" and "partial" sell orders
            //sorted first by price decending, then date ascending
            //if highest buy order >= lowest sell order, start matching

            //compare quantity of the two orders, note lowest
            //generate transaction (this BuyOrderID and SellOrderID,
            //lower quantity), then refer to which order zeroed out;
            //compare next buy order if buy was lowest, and vice versa.

            //continue until time highest buy limit order <
            //lowest sell order, then stop.
        }
        public void CreateTransaction(int BuyOrderID, int SellOrderID)
        {
            //compare prices, use lower one as transaction price
            //compare remaining quantities, note which order is lower

            //decrement buyer RMTLocked by above (quantity * price)
            //increment seller RMTBalance by same
            
            //lower quantity order:
            //decrement remaining quantity to zero
            //mark 'status' as 'filled'

            //other order:
            //decrement remaining quantity by transaction quantity
            //if remaining == 0, mark 'status' as 'filled'
            //else if 'status' == 'open', mark 'status' as 'partial'


            //generate transaction table entry with above data
        }
    }
}
