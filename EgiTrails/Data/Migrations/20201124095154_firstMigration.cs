using Microsoft.EntityFrameworkCore.Migrations;

namespace EgiTrails.Data.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trilhos",
                columns: table => new
                {
                    TrilhosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    TipoTrilho = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Trajeto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trilhos", x => x.TrilhosId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trilhos");
        }
    }
}
