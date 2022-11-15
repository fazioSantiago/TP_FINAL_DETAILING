using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP_FINAL_DETAILING.Migrations
{
    public partial class actualizarTurno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Clientes_ClienteIdCliente",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_Servicios_ServicioIdServicio",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_ClienteIdCliente",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_ServicioIdServicio",
                table: "Turnos");

            migrationBuilder.RenameColumn(
                name: "ServicioIdServicio",
                table: "Turnos",
                newName: "idServicio");

            migrationBuilder.RenameColumn(
                name: "ClienteIdCliente",
                table: "Turnos",
                newName: "idCliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idServicio",
                table: "Turnos",
                newName: "ServicioIdServicio");

            migrationBuilder.RenameColumn(
                name: "idCliente",
                table: "Turnos",
                newName: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_ClienteIdCliente",
                table: "Turnos",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_ServicioIdServicio",
                table: "Turnos",
                column: "ServicioIdServicio");

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Clientes_ClienteIdCliente",
                table: "Turnos",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_Servicios_ServicioIdServicio",
                table: "Turnos",
                column: "ServicioIdServicio",
                principalTable: "Servicios",
                principalColumn: "IdServicio",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
