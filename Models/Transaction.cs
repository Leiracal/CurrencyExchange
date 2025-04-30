using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyExchange.Models
{
    /// <summary>
    /// model for Transactions, when the virtual currency
    /// in a Sell Order is used to fulfill a Buy Order.
    /// </summary>
    public class Transaction
    {
        public int TransactionID { get; set; }

        public int OrderID { get; set; }

        // OrderID for buy order
        public int BuyOrderID { get; set; }

        // OrderID for sell order
        public int SellOrderID { get; set; }

        // Quantity of VC exchanged
        public int Quantity { get; set; }

        // Price per 1 VC
        [Column(TypeName = "decimal(8,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        // Date/time that transaction was completed
        public DateTime FulfilledAt => DateTime.Now;
    }
}
