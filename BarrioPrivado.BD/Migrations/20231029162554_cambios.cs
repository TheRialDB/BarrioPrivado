using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarrioPrivado.BD.Migrations
{
    /// <inheritdoc />
    public partial class cambios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Codigo_Domicilio_UQ",
                table: "Domicilios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "Codigo_Domicilio_UQ",
                table: "Domicilios",
                column: "codigoDomicilio",
                unique: true);
        }
    }
}
