using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CurrencyExchange.Models
{
    public class User : IdentityUser
    {

        // Active, unlocked Real Money balance
        private decimal RMTBalance { get; set; }

        // RMT balance locked in buy limit orders
        private decimal RMTLocked { get; set; }

        // Active, unlocked VC balance
        private int VCBalance { get; set; }
        
        // VC balance locked in sell limit orders
        private int VCLocked { get; set; }

    }
}
