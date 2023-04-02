using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platenumbers.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reserveNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reserveNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "plateNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nchar", fixedLength: true, nullable: false),
                    ReserveNumberId = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plateNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_plateNumbers_reserveNumbers_ReserveNumberId",
                        column: x => x.ReserveNumberId,
                        principalTable: "reserveNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_plateNumbers_ReserveNumberId",
                table: "plateNumbers",
                column: "ReserveNumberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plateNumbers");

            migrationBuilder.DropTable(
                name: "reserveNumbers");
        }
    }
}
