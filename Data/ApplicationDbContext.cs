using CurrencyExchange.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> users { get; set; } = null;
        public DbSet<Order> orders { get; set; } = null;
        public DbSet<Transaction> transactions { get; set; } = null;
    }
}
