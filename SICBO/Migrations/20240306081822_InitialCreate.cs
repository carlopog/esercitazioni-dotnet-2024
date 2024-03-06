using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SICBO.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Giocatori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Eta = table.Column<int>(type: "INTEGER", nullable: false),
                    Bottino = table.Column<int>(type: "INTEGER", nullable: false),
                    Lastbet = table.Column<int>(type: "INTEGER", nullable: false),
                    Prestito = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giocatori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scommesse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Prezzo = table.Column<int>(type: "INTEGER", nullable: false),
                    Vincita = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scommesse", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Giocatori");

            migrationBuilder.DropTable(
                name: "Scommesse");
        }
    }
}
