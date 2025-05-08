namespace CurrencyExchange.Models
{
    public class TransactionViewModel
    {
        public int TransactionID { get; set; }
        public int BuyOrderID { get; set; }
        public int SellOrderID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime FulfilledAt { get; set; }
    }
}
