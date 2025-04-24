namespace CurrencyExchange.Models
{
    public class Transaction
    {
        private int TransactionID { get; set; }

        // OrderID for buy order
        private int BuyOrderID { get; set; }

        // OrderID for sell order
        private int SellOrderID { get; set; }

        // Quantity of VC exchanged
        private int Quantity { get; set; }

        // Price per 1 VC
        private decimal Price { get; set; }

        // Date/time that transaction was completed
        private DateTime FulfilledAt { get; set; }
    }
}
