using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyExchange.Data.Migrations
{
    public partial class RemoveUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "508f1f2c-21c8-42d9-806f-2cafc487bbc2",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "e924827e-2b1a-4a11-85c5-baff4371b380", null, "356377c8-cce5-4e66-ba2e-21405afc3d63", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "606f3c31-f721-4faf-9cd9-ed96c8b11f72",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "8e1081b4-d102-4c44-9341-ee42b67d59d1", null, "61affa9b-650e-47b6-a505-3d8f4d8860f9", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d9715bc-eecb-4135-8e0e-8a9efd3139e3",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "cd06749a-9a11-41ab-8795-19c2945ed1a5", null, "80f0596f-d471-44bb-b649-2d2a5e8fd536", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "953c886e-ac7b-45cd-9f70-30eaca6a5890",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "5554cb6e-e0a1-4e1b-87fd-7983bb8d8fec", null, "e7a2d67d-515a-4fd2-a4f8-f94384727f9b", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "508f1f2c-21c8-42d9-806f-2cafc487bbc2",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "7256f9ba-4552-4e95-bdc9-19d6516c3912", "KANEDA@KURODA.COM", "cc089dbd-4cbf-4f76-bbfd-889a7c3852f4", "kaneda@kuroda.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "606f3c31-f721-4faf-9cd9-ed96c8b11f72",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "4e5fe064-5c20-4b19-b133-09b5f864ba86", "AIKO@AIKOWU.COM", "5a685e2a-889f-466e-9681-6beaf5d29e92", "aiko@aikowu.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d9715bc-eecb-4135-8e0e-8a9efd3139e3",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "63ad35d1-0818-4484-b5b3-8db9a224320d", "YUNIQ@EPOCH.COM", "e3d8a4f2-dad4-444c-b0e9-6ebc4993b163", "yuniq@epoch.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "953c886e-ac7b-45cd-9f70-30eaca6a5890",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "SecurityStamp", "UserName" },
                values: new object[] { "23e36ad9-ad77-46cd-8d71-0d22e07c0b81", "AARDVARK@ABBATOIR.COM", "cfde48ad-34cb-4818-a44d-72b70479da69", "aardvark@abbatoir.com" });
        }
    }
}
