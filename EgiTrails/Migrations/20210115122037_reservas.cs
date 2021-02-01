using Microsoft.EntityFrameworkCore.Migrations;

namespace EgiTrails.Migrations
{
    public partial class reservas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Reservas");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Reservas",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Reservas",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Telemovel",
                table: "Reservas",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoVeiculo",
                table: "Reservas",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Telemovel",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "TipoVeiculo",
                table: "Reservas");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Reservas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

        }
    }
}
