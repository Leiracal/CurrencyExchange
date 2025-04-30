 using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyExchange.Models
{
    public class Order
    {
        [DisplayName("Order ID")]
        public int OrderID { get; set; }

        [DisplayName("User ID")]
        public string UserID { get; set; } = string.Empty;

        [DisplayName("User Name")]
        public string? UserName { get; set; } = string.Empty;   

        public int OrderTypeID { get; set; }
        public OrderType? Type { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal? Price { get; set; }

        [Required(ErrorMessage = "Enter a quantity")]
        public int Quantity { get; set; }
        public int Remaining { get; set; }

        public int OrderStatusID { get; set; }
        public OrderStatus? Status { get; set; }

        [DisplayName("Creation Date")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }  
}