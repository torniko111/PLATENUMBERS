using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platenumbers.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class nullablereserveID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plateNumbers_reserveNumbers_ReserveNumberId",
                table: "plateNumbers");

            migrationBuilder.AlterColumn<int>(
                name: "ReserveNumberId",
                table: "plateNumbers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_plateNumbers_reserveNumbers_ReserveNumberId",
                table: "plateNumbers",
                column: "ReserveNumberId",
                principalTable: "reserveNumbers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_plateNumbers_reserveNumbers_ReserveNumberId",
                table: "plateNumbers");

            migrationBuilder.AlterColumn<int>(
                name: "ReserveNumberId",
                table: "plateNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_plateNumbers_reserveNumbers_ReserveNumberId",
                table: "plateNumbers",
                column: "ReserveNumberId",
                principalTable: "reserveNumbers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
