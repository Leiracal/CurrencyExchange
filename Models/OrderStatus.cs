using System.ComponentModel;

namespace CurrencyExchange.Models
{
    public class OrderStatus
    {
        public int OrderStatusID { get; set; }

        [DisplayName("Order Status")]
        public string Status { get; set; } = string.Empty;
       
    }
}
