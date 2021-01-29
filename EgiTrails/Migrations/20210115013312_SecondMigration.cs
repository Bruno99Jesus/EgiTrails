using Microsoft.EntityFrameworkCore.Migrations;

namespace EgiTrails.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Distancia",
                table: "Trilhos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LimMaxPes",
                table: "Trilhos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocFim",
                table: "Trilhos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocIni",
                table: "Trilhos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocInter",
                table: "Trilhos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distancia",
                table: "Trilhos");

            migrationBuilder.DropColumn(
                name: "LimMaxPes",
                table: "Trilhos");

            migrationBuilder.DropColumn(
                name: "LocFim",
                table: "Trilhos");

            migrationBuilder.DropColumn(
                name: "LocIni",
                table: "Trilhos");

            migrationBuilder.DropColumn(
                name: "LocInter",
                table: "Trilhos");
        }
    }
}
