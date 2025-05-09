using Humanizer;
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
        [Range(0.01, 1000000, ErrorMessage = "Price must be between $0.01 and $1,000,000")]
        public Decimal? Price { get; set; }

        [Required(ErrorMessage = "Enter a quantity")]
        [Range(1, 1000000, ErrorMessage = "Quantity must be between 1 and 1,000,000")]
        public int Quantity { get; set; }

        // Fix: Change Remaining to a property with a getter that calculates its value dynamically  
        // Tranasaction will update this value so it has to be a property
        public int Remaining { get; set; }

        public int OrderStatusID { get; set; }
        public OrderStatus? Status { get; set; }

        [DisplayName("Creation Date")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}