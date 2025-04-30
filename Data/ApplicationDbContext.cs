using CurrencyExchange.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CurrencyExchange.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Wallet> wallets { get; set; } = null!;
        public DbSet<OrderType> orderTypes { get; set; } = null!;
        public DbSet<OrderStatus> orderStatuses { get; set; } = null!;
        public DbSet<Order> orders { get; set; } = null!;
        public DbSet<Transaction> transactions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed data for OrderType and OrderStatus
            builder.Entity<OrderType>().HasData(
                new OrderType { OrderTypeID = 1, Type = "Buy" },
                new OrderType { OrderTypeID = 2, Type = "Sell" }
            );
            builder.Entity<OrderStatus>().HasData(
                new OrderStatus { OrderStatusID = 1, Status = "Open" },
                new OrderStatus { OrderStatusID = 2, Status = "Partial" },
                new OrderStatus { OrderStatusID = 3, Status = "Filled" },
                new OrderStatus { OrderStatusID = 4, Status = "Cancelled" }
            );
        }
    }
}
