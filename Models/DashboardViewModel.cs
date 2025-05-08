namespace CurrencyExchange.Models
{
    public class DashboardViewModel
    {
        public List<WalletViewModel> Wallets { get; set; }
        public List<OrderViewModel> Orders { get; set; }
        public List<TransactionViewModel> Transactions { get; set; }
    }
}
