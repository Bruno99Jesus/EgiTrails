using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EgiTrails.Migrations
{
    public partial class estado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataEstado",
                table: "Reservas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Reservas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataEstado",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Reservas");
        }
    }
}
