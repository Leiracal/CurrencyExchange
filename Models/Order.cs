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
        public string Type { get; set; } = string.Empty;

        [Column(TypeName = "decimal(8,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal? Price { get; set; }

        [Required(ErrorMessage = "Enter a quantity")]
        public int Quantity { get; set; }
        public int Remaining { get; set; }
        public string Status { get; set; } = string.Empty;

        [DisplayName("Creation Date")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }  
}