using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platenumbers.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "reserveNumbers");

            migrationBuilder.RenameColumn(
                name: "DateEnd",
                table: "reserveNumbers",
                newName: "ExpireDate");

            migrationBuilder.RenameColumn(
                name: "DateEnd",
                table: "plateNumbers",
                newName: "DateUpdate");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdate",
                table: "reserveNumbers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateUpdate",
                table: "reserveNumbers");

            migrationBuilder.RenameColumn(
                name: "ExpireDate",
                table: "reserveNumbers",
                newName: "DateEnd");

            migrationBuilder.RenameColumn(
                name: "DateUpdate",
                table: "plateNumbers",
                newName: "DateEnd");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "reserveNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
