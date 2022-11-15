using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_FINAL_DETAILING.Migrations
{
    public partial class actualizarTurno2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstaAbonado",
                table: "Turnos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstaAbonado",
                table: "Turnos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
