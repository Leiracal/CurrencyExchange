using System.ComponentModel;

namespace CurrencyExchange.Models
{
    public class OrderType
    {
        public int OrderTypeID { get; set; }

        [DisplayName("Order Type")]
        public string Type { get; set; } = string.Empty;
    }
}
