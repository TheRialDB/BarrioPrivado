using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarrioPrivado.BD.Migrations
{
    /// <inheritdoc />
    public partial class relaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Domicilios_ResidenteId",
                table: "Domicilios");

            migrationBuilder.CreateIndex(
                name: "Domicilio_ResidenteId_UQ",
                table: "Domicilios",
                column: "ResidenteId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Domicilio_ResidenteId_UQ",
                table: "Domicilios");

            migrationBuilder.CreateIndex(
                name: "IX_Domicilios_ResidenteId",
                table: "Domicilios",
                column: "ResidenteId");
        }
    }
}
