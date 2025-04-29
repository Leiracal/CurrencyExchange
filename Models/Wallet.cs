using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyExchange.Models
{
    public class Wallet
    {
        public int WalletID { get; set; }

        // Foreign key to user
        public string UserID { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal RMTBalance { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal RMTLocked {  get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Column(TypeName = "decimal(8,2)")]
        public int VCBalance { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [Column(TypeName = "decimal(8,2)")]
        public int VCLocked { get; set; }
    }
}
