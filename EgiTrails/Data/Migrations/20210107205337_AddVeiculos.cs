using Microsoft.EntityFrameworkCore.Migrations;

namespace EgiTrails.Data.Migrations
{
    public partial class AddVeiculos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao2",
                table: "Veiculos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao2",
                table: "Veiculos");
        }
    }
}
