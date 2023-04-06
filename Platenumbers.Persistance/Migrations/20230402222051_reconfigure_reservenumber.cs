using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platenumbers.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class reconfigure_reservenumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "reserveNumbers");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "reserveNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "reserveNumbers");

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "reserveNumbers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
