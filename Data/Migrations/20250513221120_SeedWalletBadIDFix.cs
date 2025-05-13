using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyExchange.Data.Migrations
{
    public partial class SeedWalletBadIDFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "508f1f2c-21c8-42d9-806f-2cafc487bbc2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "829d1970-da2c-4e7b-91ef-8205b34620e7", "0846375b-8b4e-4fb6-9b67-4800f25ae922" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "606f3c31-f721-4faf-9cd9-ed96c8b11f72",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "595f3243-8bd4-46a0-bf93-325fd93859b2", "76262885-1b8f-43a1-9f06-d047de38157d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d9715bc-eecb-4135-8e0e-8a9efd3139e3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3a386b78-1608-4eb3-9aa4-766601a502c3", "3d8c59d5-5625-498d-9cf1-931ec905554b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "953c886e-ac7b-45cd-9f70-30eaca6a5890",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "031f46cd-c05b-4ad7-a4df-f09b27688bc2", "a05fa144-b85e-44cf-940a-662475bf95ad" });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "OrderID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UserID" },
                values: new object[] { new DateTime(2025, 5, 3, 8, 45, 0, 0, DateTimeKind.Unspecified), "508f1f2c-21c8-42d9-806f-2cafc487bbc2" });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "OrderID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UserID" },
                values: new object[] { new DateTime(2025, 5, 4, 16, 5, 0, 0, DateTimeKind.Unspecified), "6d9715bc-eecb-4135-8e0e-8a9efd3139e3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "508f1f2c-21c8-42d9-806f-2cafc487bbc2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a85d139e-a149-4541-8812-5af11cd46b78", "48cfdf1e-9481-4363-a9bf-e31ada4d0028" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "606f3c31-f721-4faf-9cd9-ed96c8b11f72",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b15a5afc-d7e8-4d77-8500-3a6674b4609a", "67727ec3-59ff-4f4f-8243-27ef90c8111b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d9715bc-eecb-4135-8e0e-8a9efd3139e3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "055d5a65-955e-4821-8135-6a370a568b68", "f6972106-c6b4-461d-a5e7-8314fa8d60d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "953c886e-ac7b-45cd-9f70-30eaca6a5890",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "37c2aa5e-46e7-44a6-a544-7822232f6057", "9b7e5ba9-b209-4c0e-91d3-cd753b37d781" });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "OrderID",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UserID" },
                values: new object[] { new DateTime(2025, 5, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "953c886e-ac7b-45cd-9f70-30eaca6a5890" });

            migrationBuilder.UpdateData(
                table: "orders",
                keyColumn: "OrderID",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UserID" },
                values: new object[] { new DateTime(2025, 5, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), "953c886e-ac7b-45cd-9f70-30eaca6a5890" });
        }
    }
}
