namespace CurrencyExchange.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }

        // OrderID for buy order
        public int BuyOrderID { get; set; }

        // OrderID for sell order
        public int SellOrderID { get; set; }

        // Quantity of VC exchanged
        public int Quantity { get; set; }

        // Price per 1 VC
        public decimal Price { get; set; }

        // Date/time that transaction was completed
        public DateTime FulfilledAt => DateTime.Now;
    }
}
