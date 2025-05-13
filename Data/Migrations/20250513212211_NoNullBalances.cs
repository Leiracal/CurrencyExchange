using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyExchange.Data.Migrations
{
    public partial class NoNullBalances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "VCLocked",
                table: "wallets",
                type: "decimal(8,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "VCBalance",
                table: "wallets",
                type: "decimal(8,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RMTLocked",
                table: "wallets",
                type: "decimal(8,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RMTBalance",
                table: "wallets",
                type: "decimal(8,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldNullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "VCLocked",
                table: "wallets",
                type: "decimal(8,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "VCBalance",
                table: "wallets",
                type: "decimal(8,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "RMTLocked",
                table: "wallets",
                type: "decimal(8,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "RMTBalance",
                table: "wallets",
                type: "decimal(8,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "508f1f2c-21c8-42d9-806f-2cafc487bbc2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e924827e-2b1a-4a11-85c5-baff4371b380", "356377c8-cce5-4e66-ba2e-21405afc3d63" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "606f3c31-f721-4faf-9cd9-ed96c8b11f72",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8e1081b4-d102-4c44-9341-ee42b67d59d1", "61affa9b-650e-47b6-a505-3d8f4d8860f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d9715bc-eecb-4135-8e0e-8a9efd3139e3",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cd06749a-9a11-41ab-8795-19c2945ed1a5", "80f0596f-d471-44bb-b649-2d2a5e8fd536" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "953c886e-ac7b-45cd-9f70-30eaca6a5890",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5554cb6e-e0a1-4e1b-87fd-7983bb8d8fec", "e7a2d67d-515a-4fd2-a4f8-f94384727f9b" });
        }
    }
}
