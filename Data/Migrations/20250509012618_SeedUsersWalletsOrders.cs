using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyExchange.Data.Migrations
{
    public partial class SeedUsersWalletsOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "508f1f2c-21c8-42d9-806f-2cafc487bbc2", 0, "7256f9ba-4552-4e95-bdc9-19d6516c3912", "kaneda@kuroda.com", true, false, null, "KANEDA@KURODA.COM", "KANEDA@KURODA.COM", "AQAAAAEAACcQAAAAEM8DNhsKKQxKSgg7uwbHwLq89jZfLkeVfg+dWcEtUI6Cna+U8KLYMPb6c47ci5k5uA==", null, false, "cc089dbd-4cbf-4f76-bbfd-889a7c3852f4", false, "kaneda@kuroda.com" },
                    { "606f3c31-f721-4faf-9cd9-ed96c8b11f72", 0, "4e5fe064-5c20-4b19-b133-09b5f864ba86", "aiko@aikowu.com", true, false, null, "AIKO@AIKOWU.COM", "AIKO@AIKOWU.COM", "AQAAAAEAACcQAAAAEM8DNhsKKQxKSgg7uwbHwLq89jZfLkeVfg+dWcEtUI6Cna+U8KLYMPb6c47ci5k5uA==", null, false, "5a685e2a-889f-466e-9681-6beaf5d29e92", false, "aiko@aikowu.com" },
                    { "6d9715bc-eecb-4135-8e0e-8a9efd3139e3", 0, "63ad35d1-0818-4484-b5b3-8db9a224320d", "yuniq@epoch.com", true, false, null, "YUNIQ@EPOCH.COM", "YUNIQ@EPOCH.COM", "AQAAAAEAACcQAAAAEM8DNhsKKQxKSgg7uwbHwLq89jZfLkeVfg+dWcEtUI6Cna+U8KLYMPb6c47ci5k5uA==", null, false, "e3d8a4f2-dad4-444c-b0e9-6ebc4993b163", false, "yuniq@epoch.com" },
                    { "953c886e-ac7b-45cd-9f70-30eaca6a5890", 0, "23e36ad9-ad77-46cd-8d71-0d22e07c0b81", "aardvark@abbatoir.com", true, false, null, "AARDVARK@ABBATOIR.COM", "AARDVARK@ABBATOIR.COM", "AQAAAAEAACcQAAAAEM8DNhsKKQxKSgg7uwbHwLq89jZfLkeVfg+dWcEtUI6Cna+U8KLYMPb6c47ci5k5uA==", null, false, "cfde48ad-34cb-4818-a44d-72b70479da69", false, "aardvark@abbatoir.com" }
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "OrderID", "CreatedAt", "OrderStatusID", "OrderTypeID", "Price", "Quantity", "Remaining", "UserID", "UserName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, 1, 200m, 50, 50, "953c886e-ac7b-45cd-9f70-30eaca6a5890", "" },
                    { 2, new DateTime(2025, 5, 2, 10, 15, 0, 0, DateTimeKind.Unspecified), 1, 1, 100m, 50, 50, "606f3c31-f721-4faf-9cd9-ed96c8b11f72", "" },
                    { 3, new DateTime(2025, 5, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, 2, 300m, 50, 50, "953c886e-ac7b-45cd-9f70-30eaca6a5890", "" },
                    { 4, new DateTime(2025, 5, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, 2, 400m, 50, 50, "953c886e-ac7b-45cd-9f70-30eaca6a5890", "" }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "WalletID", "RMTBalance", "RMTLocked", "UserID", "VCBalance", "VCLocked" },
                values: new object[,]
                {
                    { 1334, 20000.0m, 10000.0m, "953c886e-ac7b-45cd-9f70-30eaca6a5890", 1000m, 0m },
                    { 1335, 20000.0m, 5000.0m, "606f3c31-f721-4faf-9cd9-ed96c8b11f72", 1000m, 0m },
                    { 1336, 20000.0m, 0.0m, "508f1f2c-21c8-42d9-806f-2cafc487bbc2", 1000m, 50m },
                    { 1337, 20000.0m, 0.0m, "6d9715bc-eecb-4135-8e0e-8a9efd3139e3", 1000m, 50m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "508f1f2c-21c8-42d9-806f-2cafc487bbc2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "606f3c31-f721-4faf-9cd9-ed96c8b11f72");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d9715bc-eecb-4135-8e0e-8a9efd3139e3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "953c886e-ac7b-45cd-9f70-30eaca6a5890");

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumn: "OrderID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumn: "OrderID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumn: "OrderID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "orders",
                keyColumn: "OrderID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "wallets",
                keyColumn: "WalletID",
                keyValue: 1334);

            migrationBuilder.DeleteData(
                table: "wallets",
                keyColumn: "WalletID",
                keyValue: 1335);

            migrationBuilder.DeleteData(
                table: "wallets",
                keyColumn: "WalletID",
                keyValue: 1336);

            migrationBuilder.DeleteData(
                table: "wallets",
                keyColumn: "WalletID",
                keyValue: 1337);
        }
    }
}
