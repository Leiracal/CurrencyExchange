namespace CurrencyExchange.Models
{
    public class Wallet
    {
        public int WalletID { get; set; }

        // Foreign key to user
        public int UserID { get; set; }

        public decimal RMTBalance { get; set; }
        public decimal RMTLocked {  get; set; }

        public int VCBalance { get; set; }
        public int VCLocked { get; set; }
    }
}
