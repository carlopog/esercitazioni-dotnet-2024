using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JSON.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Piatti_Ordinazioni_OrdinazioneId",
                table: "Piatti");

            migrationBuilder.DropIndex(
                name: "IX_Piatti_OrdinazioneId",
                table: "Piatti");

            migrationBuilder.DropColumn(
                name: "OrdinazioneId",
                table: "Piatti");

            migrationBuilder.CreateTable(
                name: "OrdinazionePiatto",
                columns: table => new
                {
                    OrdinazioniId = table.Column<int>(type: "INTEGER", nullable: false),
                    PiattiId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdinazionePiatto", x => new { x.OrdinazioniId, x.PiattiId });
                    table.ForeignKey(
                        name: "FK_OrdinazionePiatto_Ordinazioni_OrdinazioniId",
                        column: x => x.OrdinazioniId,
                        principalTable: "Ordinazioni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdinazionePiatto_Piatti_PiattiId",
                        column: x => x.PiattiId,
                        principalTable: "Piatti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdinazionePiatto_PiattiId",
                table: "OrdinazionePiatto",
                column: "PiattiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdinazionePiatto");

            migrationBuilder.AddColumn<int>(
                name: "OrdinazioneId",
                table: "Piatti",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Piatti_OrdinazioneId",
                table: "Piatti",
                column: "OrdinazioneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Piatti_Ordinazioni_OrdinazioneId",
                table: "Piatti",
                column: "OrdinazioneId",
                principalTable: "Ordinazioni",
                principalColumn: "Id");
        }
    }
}
