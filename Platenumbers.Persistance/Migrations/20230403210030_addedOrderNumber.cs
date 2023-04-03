using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platenumbers.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class addedOrderNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderNumberId",
                table: "plateNumbers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderNumber",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNumber", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_plateNumbers_OrderNumberId",
                table: "plateNumbers",
                column: "OrderNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_plateNumbers_OrderNumber_OrderNumberId",
                table: "plateNumbers",
                column: "OrderNumberId",
                principalTable: "OrderNumber",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plateNumbers_OrderNumber_OrderNumberId",
                table: "plateNumbers");

            migrationBuilder.DropTable(
                name: "OrderNumber");

            migrationBuilder.DropIndex(
                name: "IX_plateNumbers_OrderNumberId",
                table: "plateNumbers");

            migrationBuilder.DropColumn(
                name: "OrderNumberId",
                table: "plateNumbers");
        }
    }
}
