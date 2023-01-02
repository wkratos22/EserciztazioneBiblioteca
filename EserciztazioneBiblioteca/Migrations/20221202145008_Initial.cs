using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EserciztazioneBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Annodinascita = table.Column<DateTime>(name: "Anno_di_nascita", type: "datetime2", nullable: false),
                    Luogodinascita = table.Column<string>(name: "Luogo_di_nascita", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autore", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Casa_editrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeeditore = table.Column<string>(name: "nome_editore", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casa_editrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codicefisc = table.Column<string>(name: "Codice_fisc", type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datadinascita = table.Column<DateTime>(name: "Data_di_nascita", type: "datetime2", nullable: false),
                    Numerocellulare = table.Column<int>(name: "Numero_cellulare", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genere",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genere", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prestito",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datainizio = table.Column<DateTime>(name: "Data_inizio", type: "datetime2", nullable: false),
                    Datafine = table.Column<DateTime>(name: "Data_fine", type: "datetime2", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestito_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Annodipubblicazione = table.Column<DateTime>(name: "Anno_di_pubblicazione", type: "datetime2", nullable: false),
                    Lingua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Formato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isbn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenereId = table.Column<int>(type: "int", nullable: false),
                    AutoreId = table.Column<int>(type: "int", nullable: false),
                    CasaeditriceId = table.Column<int>(name: "Casa_editriceId", type: "int", nullable: false),
                    PrestitoId = table.Column<int>(type: "int", nullable: true),
                    Prezzo = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Libro_Autore_AutoreId",
                        column: x => x.AutoreId,
                        principalTable: "Autore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libro_Casa_editrice_Casa_editriceId",
                        column: x => x.CasaeditriceId,
                        principalTable: "Casa_editrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libro_Genere_GenereId",
                        column: x => x.GenereId,
                        principalTable: "Genere",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libro_Prestito_PrestitoId",
                        column: x => x.PrestitoId,
                        principalTable: "Prestito",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libro_AutoreId",
                table: "Libro",
                column: "AutoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_Casa_editriceId",
                table: "Libro",
                column: "Casa_editriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_GenereId",
                table: "Libro",
                column: "GenereId");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_PrestitoId",
                table: "Libro",
                column: "PrestitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestito_ClienteId",
                table: "Prestito",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Autore");

            migrationBuilder.DropTable(
                name: "Casa_editrice");

            migrationBuilder.DropTable(
                name: "Genere");

            migrationBuilder.DropTable(
                name: "Prestito");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
