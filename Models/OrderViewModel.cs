namespace CurrencyExchange.Models
{
    public class OrderViewModel
    {
        public int OrderID { get; set; }
        public string? Type { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
        public int Remaining { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
