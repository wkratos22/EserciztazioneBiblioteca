using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EserciztazioneBiblioteca.Migrations
{
    /// <inheritdoc />
    public partial class descrizioneInt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Descrizione",
                table: "Prestito",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descrizione",
                table: "Prestito",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
