namespace CurrencyExchange.Models
{
    public class WalletViewModel
    {
        public int WalletID { get; set; }
        public decimal? RMTBalance { get; set; }
        public decimal? RMTLocked { get; set; }
        public int? VCBalance { get; set; }
        public int? VCLocked { get; set; }
    }
}
