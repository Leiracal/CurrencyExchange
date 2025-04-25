using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CurrencyExchange.Models
{
    public class User : IdentityUser
    {
        // Active, unlocked Real Money balance
        public decimal RMTBalance { get; set; }

        // RMT balance locked in buy limit orders
        public decimal RMTLocked { get; set; }

        // Active, unlocked VC balance
        public int VCBalance { get; set; }

        // VC balance locked in sell limit orders
        public int VCLocked { get; set; }

    }
}
