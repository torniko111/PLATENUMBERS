using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platenumbers.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class gsdkg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plateNumbers_OrderNumber_OrderNumberId",
                table: "plateNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderNumber",
                table: "OrderNumber");

            migrationBuilder.RenameTable(
                name: "OrderNumber",
                newName: "orderNumbers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderNumbers",
                table: "orderNumbers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_plateNumbers_orderNumbers_OrderNumberId",
                table: "plateNumbers",
                column: "OrderNumberId",
                principalTable: "orderNumbers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plateNumbers_orderNumbers_OrderNumberId",
                table: "plateNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderNumbers",
                table: "orderNumbers");

            migrationBuilder.RenameTable(
                name: "orderNumbers",
                newName: "OrderNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderNumber",
                table: "OrderNumber",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_plateNumbers_OrderNumber_OrderNumberId",
                table: "plateNumbers",
                column: "OrderNumberId",
                principalTable: "OrderNumber",
                principalColumn: "Id");
        }
    }
}
