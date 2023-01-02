using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EserciztazioneBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class LibroPrestito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LibroPrestito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrestitoId = table.Column<int>(type: "int", nullable: false),
                    LibroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroPrestito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibroPrestito_Libro_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibroPrestito_Prestito_PrestitoId",
                        column: x => x.PrestitoId,
                        principalTable: "Prestito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibroPrestito_LibroId",
                table: "LibroPrestito",
                column: "LibroId");

            migrationBuilder.CreateIndex(
                name: "IX_LibroPrestito_PrestitoId",
                table: "LibroPrestito",
                column: "PrestitoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibroPrestito");
        }
    }
}
