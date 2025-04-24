using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyExchange.Models
{
    public class Order
    {
        int OrderID { get; set; }
        int UserID { get; set; }
        String? Type { get; set; }

        [Required(ErrorMessage = "Enter a price")]
        [Column(TypeName = "decimal(8,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        Decimal? Price { get; set; }

        [Required(ErrorMessage = "Enter a quantity")]
        int Quantity { get; set; }
        int Remaining { get; set; }
        String? Status { get; set; }
        DateTime CreatedAt => new DateTime()
    }
}
