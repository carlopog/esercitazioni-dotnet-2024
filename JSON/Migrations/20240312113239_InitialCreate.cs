using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JSON.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tavoli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Capacita = table.Column<int>(type: "INTEGER", nullable: false),
                    Disponibile = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tavoli", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ordinazioni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id_Tavolo = table.Column<int>(type: "INTEGER", nullable: false),
                    TavoloId = table.Column<int>(type: "INTEGER", nullable: false),
                    Disponibile = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordinazioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordinazioni_Tavoli_TavoloId",
                        column: x => x.TavoloId,
                        principalTable: "Tavoli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Piatti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Descrizione = table.Column<string>(type: "TEXT", nullable: false),
                    Prezzo = table.Column<int>(type: "INTEGER", nullable: false),
                    Categoria = table.Column<string>(type: "TEXT", nullable: false),
                    Disponibile = table.Column<bool>(type: "INTEGER", nullable: false),
                    OrdinazioneId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piatti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Piatti_Ordinazioni_OrdinazioneId",
                        column: x => x.OrdinazioneId,
                        principalTable: "Ordinazioni",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordinazioni_TavoloId",
                table: "Ordinazioni",
                column: "TavoloId");

            migrationBuilder.CreateIndex(
                name: "IX_Piatti_OrdinazioneId",
                table: "Piatti",
                column: "OrdinazioneId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Piatti");

            migrationBuilder.DropTable(
                name: "Ordinazioni");

            migrationBuilder.DropTable(
                name: "Tavoli");
        }
    }
}
