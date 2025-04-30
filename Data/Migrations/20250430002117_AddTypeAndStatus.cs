using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyExchange.Data.Migrations
{
    public partial class AddTypeAndStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "orders",
                newName: "UserName");

            migrationBuilder.AddColumn<int>(
                name: "OrderStatusID",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderTypeID",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "orderStatuses",
                columns: table => new
                {
                    OrderStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderStatuses", x => x.OrderStatusID);
                });

            migrationBuilder.CreateTable(
                name: "orderTypes",
                columns: table => new
                {
                    OrderTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderTypes", x => x.OrderTypeID);
                });

            migrationBuilder.InsertData(
                table: "orderStatuses",
                columns: new[] { "OrderStatusID", "Status" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "Partial" },
                    { 3, "Filled" },
                    { 4, "Cancelled" }
                });

            migrationBuilder.InsertData(
                table: "orderTypes",
                columns: new[] { "OrderTypeID", "Type" },
                values: new object[,]
                {
                    { 1, "Buy" },
                    { 2, "Sell" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_OrderStatusID",
                table: "orders",
                column: "OrderStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_OrderTypeID",
                table: "orders",
                column: "OrderTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_orderStatuses_OrderStatusID",
                table: "orders",
                column: "OrderStatusID",
                principalTable: "orderStatuses",
                principalColumn: "OrderStatusID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_orderTypes_OrderTypeID",
                table: "orders",
                column: "OrderTypeID",
                principalTable: "orderTypes",
                principalColumn: "OrderTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_orderStatuses_OrderStatusID",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_orderTypes_OrderTypeID",
                table: "orders");

            migrationBuilder.DropTable(
                name: "orderStatuses");

            migrationBuilder.DropTable(
                name: "orderTypes");

            migrationBuilder.DropIndex(
                name: "IX_orders_OrderStatusID",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_OrderTypeID",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "OrderStatusID",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "OrderTypeID",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "orders",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
