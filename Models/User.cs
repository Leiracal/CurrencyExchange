using System.ComponentModel.DataAnnotations;

namespace CurrencyExchange.Models
{
    public class User
    {
        public string? UserID { get; set; }

        [Required]
        public string? Email { get; set; }
        
        public string? Password { get; set; }

    }
}
