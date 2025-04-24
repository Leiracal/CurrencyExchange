using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyExchange.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public string? Type { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public Decimal? Price { get; set; }

        [Required(ErrorMessage = "Enter a quantity")]
        public int Quantity { get; set; }
        public int Remaining { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
