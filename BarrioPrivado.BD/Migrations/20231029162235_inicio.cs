using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarrioPrivado.BD.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Domicilios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lote = table.Column<int>(type: "int", nullable: false),
                    manzana = table.Column<int>(type: "int", nullable: false),
                    codigoDomicilio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domicilios", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Residentes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    codigoDomicilio = table.Column<int>(type: "int", nullable: false),
                    Domicilioid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residentes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Residentes_Domicilios_Domicilioid",
                        column: x => x.Domicilioid,
                        principalTable: "Domicilios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visitantes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DNI = table.Column<int>(type: "int", nullable: false),
                    ResidenteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitantes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Visitantes_Residentes_ResidenteId",
                        column: x => x.ResidenteId,
                        principalTable: "Residentes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "Codigo_Domicilio_UQ",
                table: "Domicilios",
                column: "codigoDomicilio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Residentes_Domicilioid",
                table: "Residentes",
                column: "Domicilioid");

            migrationBuilder.CreateIndex(
                name: "Residente_DNI_UQ",
                table: "Residentes",
                column: "DNI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visitantes_ResidenteId",
                table: "Visitantes",
                column: "ResidenteId");

            migrationBuilder.CreateIndex(
                name: "Visitante_DNI_UQ",
                table: "Visitantes",
                column: "DNI",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visitantes");

            migrationBuilder.DropTable(
                name: "Residentes");

            migrationBuilder.DropTable(
                name: "Domicilios");
        }
    }
}
