using CurrencyExchange.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

            //Seed users and hash passwords
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "953c886e-ac7b-45cd-9f70-30eaca6a5890",
                    Email = "aardvark@abbatoir.com",
                    NormalizedEmail = "AARDVARK@ABBATOIR.COM",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    //This is the hash for the password "P@ssword2534"
                    PasswordHash = "AQAAAAEAACcQAAAAEM8DNhsKKQxKSgg7uwbHwLq89jZfLkeVfg+dWcEtUI6Cna+U8KLYMPb6c47ci5k5uA=="
                },
                new IdentityUser
                {
                    Id = "606f3c31-f721-4faf-9cd9-ed96c8b11f72",
                    Email = "aiko@aikowu.com",
                    NormalizedEmail = "AIKO@AIKOWU.COM",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    //This is the hash for the password "P@ssword2534"
                    PasswordHash = "AQAAAAEAACcQAAAAEM8DNhsKKQxKSgg7uwbHwLq89jZfLkeVfg+dWcEtUI6Cna+U8KLYMPb6c47ci5k5uA=="
                },
                new IdentityUser
                {
                    Id = "508f1f2c-21c8-42d9-806f-2cafc487bbc2",
                    Email = "kaneda@kuroda.com",
                    NormalizedEmail = "KANEDA@KURODA.COM",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    //This is the hash for the password "P@ssword2534"
                    PasswordHash = "AQAAAAEAACcQAAAAEM8DNhsKKQxKSgg7uwbHwLq89jZfLkeVfg+dWcEtUI6Cna+U8KLYMPb6c47ci5k5uA=="
                },
                new IdentityUser
                {
                    Id = "6d9715bc-eecb-4135-8e0e-8a9efd3139e3",
                    Email = "yuniq@epoch.com",
                    NormalizedEmail = "YUNIQ@EPOCH.COM",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D"),
                    //This is the hash for the password "P@ssword2534"
                    PasswordHash = "AQAAAAEAACcQAAAAEM8DNhsKKQxKSgg7uwbHwLq89jZfLkeVfg+dWcEtUI6Cna+U8KLYMPb6c47ci5k5uA=="
                }
                );

            builder.Entity<Wallet>().HasData(
                new Wallet
                {
                    WalletID = 1334,
                    UserID = "953c886e-ac7b-45cd-9f70-30eaca6a5890",
                    RMTBalance = 20000.0m,
                    RMTLocked = 10000.0m,
                    VCBalance = 1000,
                    VCLocked = 0,
                },
                new Wallet
                {
                    WalletID = 1335,
                    UserID = "606f3c31-f721-4faf-9cd9-ed96c8b11f72",
                    RMTBalance = 20000.0m,
                    RMTLocked = 5000.0m,
                    VCBalance = 1000,
                    VCLocked = 0,
                },
                new Wallet
                {
                    WalletID = 1336,
                    UserID = "508f1f2c-21c8-42d9-806f-2cafc487bbc2",
                    RMTBalance = 20000.0m,
                    RMTLocked = 0.0m,
                    VCBalance = 1000,
                    VCLocked = 50,
                },
                new Wallet
                {
                    WalletID = 1337,
                    UserID = "6d9715bc-eecb-4135-8e0e-8a9efd3139e3",
                    RMTBalance = 20000.0m,
                    RMTLocked = 0.0m,
                    VCBalance = 1000,
                    VCLocked = 50,
                }
                );

            builder.Entity<Order>().HasData(
                new Order
                {
                    OrderID = 1,
                    UserID = "953c886e-ac7b-45cd-9f70-30eaca6a5890",
                    OrderTypeID = 1,
                    Price = 200m,
                    Quantity = 50,
                    Remaining = 50,
                    OrderStatusID = 1,
                    CreatedAt = new DateTime(2025, 5, 1, 14, 30, 0)
                },
                new Order
                {
                    OrderID = 2,
                    UserID = "606f3c31-f721-4faf-9cd9-ed96c8b11f72",
                    OrderTypeID = 1,
                    Price = 100m,
                    Quantity = 50,
                    Remaining = 50,
                    OrderStatusID = 1,
                    CreatedAt = new DateTime(2025, 5, 2, 10, 15, 0)
                },
                new Order
                {
                    OrderID = 3,
                    UserID = "508f1f2c-21c8-42d9-806f-2cafc487bbc2",
                    OrderTypeID = 2,
                    Price = 300m,
                    Quantity = 50,
                    Remaining = 50,
                    OrderStatusID = 1,
                    CreatedAt = new DateTime(2025, 5, 3, 08, 45, 0)
                },
                new Order
                {
                    OrderID = 4,
                    UserID = "6d9715bc-eecb-4135-8e0e-8a9efd3139e3",
                    OrderTypeID = 2,
                    Price = 400m,
                    Quantity = 50,
                    Remaining = 50,
                    OrderStatusID = 1,
                    CreatedAt = new DateTime(2025, 5, 4, 16, 05, 0)
                }
                );
        }
    }
}
