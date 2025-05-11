using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyExchange.Models
{
    public class OrderViewModel
    {
        [DisplayName("Order ID")]
        public int OrderID { get; set; }
        
        public string? Type { get; set; }
        
        [Column(TypeName = "decimal(8,2)")]
        [DisplayFormat(DataFormatString = "{0:C}", NullDisplayText = "Market")]
        public decimal? Price { get; set; }
        
        public int Quantity { get; set; }
        
        public int Remaining { get; set; }
        
        public string? Status { get; set; }

        [DisplayName("Creation Date")]
        public DateTime CreatedAt { get; set; }
    }
}
