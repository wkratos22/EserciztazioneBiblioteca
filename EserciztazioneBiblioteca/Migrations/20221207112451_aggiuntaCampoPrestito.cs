using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EserciztazioneBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class aggiuntaCampoPrestito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descrizione",
                table: "Prestito",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Prezzo",
                table: "Prestito",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descrizione",
                table: "Prestito");

            migrationBuilder.DropColumn(
                name: "Prezzo",
                table: "Prestito");
        }
    }
}
